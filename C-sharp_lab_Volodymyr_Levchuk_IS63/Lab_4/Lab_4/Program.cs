using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Program
    {
        static List<Car> Cars = new List<Car>
        {
            new Car("BMW",20,new DateTime(1998,10,1),new DateTime(2003,2,19),"AC132","1a"),
            new Car("AUDI",22,new DateTime(1999,6,13),new DateTime(2004,1,12),"AT233","2a"),
            new Car("MAN",32,new DateTime(1998,4,11),new DateTime(2001,2,15),"BK232","3a"),
            new Car("SCANIA",13,new DateTime(2004,11,4),new DateTime(2014,7,13),"AH323","3a"),
            new Car("RENO",8,new DateTime(2000,1,7),new DateTime(2013,5,11),"AA222","1a"),
            new Car("MAN",9,new DateTime(2006,1,6),new DateTime(2016,1,10),"AS231","2a"),
            new Car("TESLA",40,new DateTime(1998,10,3),new DateTime(2014,4,9),"AZ231","4a")
        };

        static List<Taxi> Taxis = new List<Taxi>
        {
            new Taxi("RENO",4, new DateTime(2010,2,13),"AC321","4a"),
            new Taxi("BMW",5, new DateTime(2003,6,24),"AC321","3a"),
            new Taxi("AUDI",3, new DateTime(2009,5,12),"AC321","2a"),
            new Taxi("MERCEDES",5, new DateTime(2015,1,12),"AC321","1a"),
            new Taxi("OPEL",4, new DateTime(2010,3,13),"AC321","3a")
        };
        static List<Fleet> Fleets = new List<Fleet>
        {
            new Fleet("NewMotoe","Kyiv",100,"1a"),
            new Fleet("DreaSea","Odessa",230,"2a"),
            new Fleet("ModenCity","Lviv",40,"3a"),
            new Fleet("Future","Lutsk",140,"4a")
        };
        static void Main(string[] args)
        {
            Console.WriteLine("1.Простая выборка грузовых автомобилей");
            var query1 = from x in Cars
                     select x;
            foreach (var x in query1)
                Console.WriteLine(x.model+ " "+ x.productionDate.ToShortDateString());

            Console.WriteLine("2.Выборка автомобилей по шифру автопарку");
            var query2 = from x in Cars where x.vehicleFleet == "1a" select x;
            foreach (var x in query2)
                Console.WriteLine(x.model + " " + x.vehicleFleet);

            Console.WriteLine("3.Сортування автомобилей по шифру автопарку");
            var query3 = from x in Taxis orderby x.vehicleFleet descending select x;
            foreach (var x in query3)
                Console.WriteLine(x.model + " " + x.vehicleFleet);

            Console.WriteLine("4.Групировка автомобилей по шифру автопарку");
            var query4 = from x in Cars group x by x.vehicleFleet into g select new { key = g.Key, value = g};
            foreach (var x in query4)
            {
                Console.WriteLine("vehicleFleet: "+x.key);
                foreach(var g in x.value)
                {
                    Console.WriteLine("      "+g.model);
                }
            }
            Console.WriteLine("5.Обьеденение грузовых автомобилей з парком автомобилей");
            var query5 = from x in Fleets
                         join f in Cars on x.vehicleFleet equals f.vehicleFleet into g
                         orderby x.vehicleFleet select new {name = x.name, model = g};
            foreach (var x in query5)
            {
                Console.WriteLine("Name: " + x.name);
                foreach (var t in x.model)
                {
                    Console.WriteLine("    " + t.model);
                }
            }
            Console.WriteLine("6.Обьеденение выборки автомобилей шифр которых начинается с 1 или 2");
            
            var query6 = from x in Cars
                     where x.vehicleFleet.StartsWith("2")
                     select x;
            var query7 = from y in Cars
                     where y.vehicleFleet.StartsWith("1")
                     select y;
            
            ////
            foreach(var x in query6.Concat(query7))
            {
                Console.WriteLine(x.model +" " + x.vehicleFleet);
            }
            Console.WriteLine("6.Обьеденение выборки уникальных автомобилей шифр которых начинается с 2 ");
            foreach (var x in query6.Union(query6))
            {
                 Console.WriteLine(x.model +" " + x.vehicleFleet);
            }

            Console.ReadKey();

        }
    }
    public class Car
    {
        public string model;
        public double capacity;
        public DateTime productionDate;
        public DateTime repairDate;
        public string govermentalNumber;
        public string vehicleFleet;
        public Car(string model,double capacity, DateTime productionDate, DateTime repairDate, string govermentalNumber, string vehicleFleet)
        {
            this.model = model;
            this.capacity = capacity;
            this.productionDate = productionDate;
            this.repairDate = repairDate;
            this.govermentalNumber = govermentalNumber;
            this.vehicleFleet = vehicleFleet;
        }
    }

    public class Taxi
    {
        public string model;
        public int passengersCapacity;
        public DateTime productionDate;
        public string govermentalNumber;
        public string vehicleFleet;
        public Taxi(string model, int passengersCapacity, DateTime productionDate, string govermentalNumber, string vehicleFleet)
        {
            this.model = model;
            this.passengersCapacity = passengersCapacity;
            this.productionDate = productionDate;
            this.govermentalNumber = govermentalNumber;
            this.vehicleFleet = vehicleFleet;
        }
    }

    public class Fleet
    {
        public string name;
        public string address;
        public double area;
        public string vehicleFleet;
        public Fleet(string name, string address, double area, string vehicleFleet)
        {
            this.name = name;
            this.address = address;
            this.area = area;
            this.vehicleFleet = vehicleFleet;
        }
    }
    
}
