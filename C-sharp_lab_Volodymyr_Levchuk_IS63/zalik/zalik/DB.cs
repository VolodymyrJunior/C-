using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zalik
{
    class DB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        DataSet dataSet = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlConnection connection;
        SqlCommand command = new SqlCommand();

        public DB()
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            connection.Open();
        }
        public void CloseConnection()
        {
            connection.Close();
        }
        public void Show(int numberTask)
        {
            bool repeat = false;

            command.Connection = connection;
            do
            {
                switch (numberTask)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter type wacth: 0 - quartz, 1 - mechanical;");
                            int type;
                            string input = Console.ReadLine();
                            if (!int.TryParse(input, out type) || (type != 1 && type != 0))
                            {
                                repeat = true;
                                Console.WriteLine();
                                Console.WriteLine("Input number isn't correct");
                                Console.WriteLine();

                            }
                            else
                            {
                                repeat = false;
                                command.CommandText = sqlTask1(type);
                            }


                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter price limit;");
                            double price;
                            string input = Console.ReadLine();
                            if (!Double.TryParse(input, out price))
                            {
                                repeat = true;
                                Console.WriteLine();
                                Console.WriteLine("Input price isn't correct");
                                Console.WriteLine();

                            }
                            else
                            {
                                repeat = false;
                                command.CommandText = sqlTask2(price);
                            }
                            break;
                        }
                    case 3:
                        {
                            repeat = false;
                            Console.WriteLine("Enter country;");
                            string input = Console.ReadLine();
                            input = "'" + input + "'";//екранування пробілів
                            command.CommandText = sqlTask3(input);
                            break;
                        }
                    case 4:
                        {
                            repeat = false;
                            Console.WriteLine("Enter price limit;");
                            double price;
                            string input = Console.ReadLine();
                            if (!Double.TryParse(input, out price))
                            {
                                repeat = true;
                                Console.WriteLine();
                                Console.WriteLine("Input price isn't correct");
                                Console.WriteLine();

                            }
                            else
                            {
                                command.CommandText = sqlTask4(price);
                            }
                            break;
                        }
                }
            } while (repeat);
            SqlDataReader reader = command.ExecuteReader();


            Console.Write("No.\t");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write("{0,-20}", reader.GetName(i));
            }
            Console.WriteLine();

            if (reader.HasRows)
            {

                int index = 0;
                while (reader.Read())
                {
                    index++;
                    Console.Write(index + "\t");
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write("{0,-20}", reader.GetValue(i));
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Table is empty");
            }

        }

        private string CreateSQL()
        {
            return "Select * From watch w LEFT JOIN manufacturer m ON(w.manufacturer_id = m.manufacturer_id )";
        }
        private string sqlTask1(int type)
        {
            return "SELECT * FROM watch WHERE type= " + type.ToString();
        }
        private string sqlTask2(double price)
        {
            return "SELECT * FROM watch WHERE price<" + price.ToString();
        }
        private string sqlTask3(string country)
        {
            return "SELECT w.model FROM watch w LEFT JOIN manufacturer m ON(w.manufacturer_id = m.manufacturer_id) WHERE m.country=" + country;
        }
        private string sqlTask4(double price)
        {
            return "SELECT w.manufacturer_id FROM watch w LEFT JOIN manufacturer m ON(w.manufacturer_id = m.manufacturer_id) WHERE w.quantity>0 GROUP BY w.manufacturer_id HAVING(SUM(w.price)) >" + price.ToString();
        }
    }
}
