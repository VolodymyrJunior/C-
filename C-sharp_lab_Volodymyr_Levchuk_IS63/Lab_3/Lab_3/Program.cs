using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Payment payment = new Payment("Оплата покупки", 1000, new TypicalPayment());
            payment.CheckPayment();
            payment.DownPercent();
            payment.Confirm();
            Console.WriteLine();

            Payment payment2 = new Payment("Пожертвування грошей", 2000, new PrivilegePayment());
            payment2.CheckPayment();
            payment2.DownPercent();
            payment2.Confirm();
            Console.WriteLine();

            Payment payment3 = new Payment("Виплата зарплати", 3000, new GovermentalPayment());
            payment3.CheckPayment();
            payment3.DownPercent();
            payment3.Confirm();
            Console.WriteLine();

            Payment payment4 = new Payment("Переказ грошей на карту", 4000, new InsidePayment());
            payment4.CheckPayment();
            payment4.DownPercent();
            payment4.Confirm();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
    interface TypePayment
    {
        string AddPayment(string name);
        void CheckPayment(string name);
        double DownPercent(double value);
        bool Confirm(string name, double value);
    }

    class TypicalPayment : TypePayment
    {
        public string AddPayment(string name)
        {
            Console.WriteLine("Typecal payment " + name + " is created");
            return name;
        }
        public void CheckPayment(string name)
        {
            Console.WriteLine(name+" is checked");
        }
        public double DownPercent(double value)
        {
            return value -=value*0.02;
        }
        public bool Confirm(string name, double value)
        {
            Console.WriteLine("Payment: "+ name + " - " + value +" is confirmed");
            return true;
        }
    }

    class PrivilegePayment : TypePayment
    {
        public string AddPayment(string name)
        {
            Console.WriteLine("Privilege payment " + name + " is created");
            return name;
        }
        public void CheckPayment(string name)
        {
            Console.WriteLine(name + " is checked");
        }
        public double DownPercent(double value)
        {
            return value -= value * 0.01;
        }
        public bool Confirm(string name, double value)
        {
            Console.WriteLine("Privilege payment: " + name + " - " + value + " is confirmed");
            return true;
        }
    }
    class GovermentalPayment : TypePayment
    {
        public string AddPayment(string name)
        {
            Console.WriteLine("Govermental payment " + name + " is created");
            return name;
        }
        public void CheckPayment(string name)
        {
            Console.WriteLine(name + " is checked");
        }
        public double DownPercent(double value)
        {
            return value -= value * 0.03;
        }
        public bool Confirm(string name, double value)
        {
            Console.WriteLine("Govermental payment: " + name + " - " + value + " is confirmed");
            return true;
        }
    }
    class InsidePayment : TypePayment
    {
        public string AddPayment(string name)
        {
            Console.WriteLine("Inside payment " + name + " is created");
            return name;
        }
        public void CheckPayment(string name)
        {
            Console.WriteLine(name + " is checked");
        }
        public double DownPercent(double value)
        {
            return value;
        }
        public bool Confirm(string name, double value)
        {
            Console.WriteLine("Inside payment: " + name + " - " + value + " is confirmed");
            return true;
        }
    }

    class Payment
    {
        protected string name;
        protected double value;
        protected bool confirm;
        protected TypePayment payment;
        public Payment(string name, double value, TypePayment payment){
            this.payment = payment;
            this.name = this.payment.AddPayment(name);
            this.value = value;
            this.confirm = false;
        }
        public void CheckPayment()
        {
            this.payment.CheckPayment(this.name);
        }
        public void DownPercent()
        {
            this.value = payment.DownPercent(this.value);
        }
        public void Confirm()
        {
            this.confirm = this.payment.Confirm(this.name, this.value);
        }

    }
}
