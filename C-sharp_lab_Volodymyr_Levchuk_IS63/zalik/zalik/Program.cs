using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zalik
{
    class Program
    {
        static DB db = new DB();
        static void Main(string[] args)
        {
           
            bool repeat = true;
            do
            {
                db.OpenConnection();
                Console.WriteLine("TEST Volodymyr Levchuk IS-63 v-9");
                Console.WriteLine("Select number task:1-4");
                Console.WriteLine("Click 5 to exit");
                int number;
                string input = Console.ReadLine();
                if (!int.TryParse(input, out number) && number>0 && number <6)
                {
                    //repeat = true;
                    Console.WriteLine();
                    Console.WriteLine("Input number isn't correct");
                    Console.WriteLine();

                }
                else
                {
                    if (number == 5)
                    {
                        repeat = false;
                    }
                    else
                    {
                        db.Show(number);
                        db.CloseConnection();
                    }
                    
                }
                //Console.Clear();
            } while (repeat);
            
           

//            Console.ReadKey();
        }
    }
}
