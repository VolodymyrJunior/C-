using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    abstract class SystemCoder
    { 
        public string name {get;set;}
        public SystemCoder(string name)
        {
            this.name = name;
        }
        abstract public Coder Decode(string data);
        abstract public Coder Encode(string data);
    }
    abstract class Coder
    {  }

    class FirstTypeCoder
    {
     
    }

    class ShiftCoder : Coder
    {
        private string data;

        public void Decode(string data)
        {

        }

        public void Encode(string data)
        {

        }
    }
}
