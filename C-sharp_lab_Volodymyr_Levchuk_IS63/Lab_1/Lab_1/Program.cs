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
            SystemCoder firstCoder = new FirstTypeCoder("Перший кодер");
            Coder firstTypeCoding = firstCoder.CreateCoder();

            SystemCoder secondCoder = new SecondTypeCoder("Другий кодер");
            Coder secondTypeCoding = secondCoder.CreateCoder();



            while (true)
            {

                Console.Write("Enter string: ");
                string enterString = Console.ReadLine();
                // type first
                string decoded = firstTypeCoding.Encode(enterString);

                Console.WriteLine("Fisrt type coding");
                Console.WriteLine(" Encoded string: " + decoded);
                Console.WriteLine(" Decoded string: " + firstTypeCoding.Decode(decoded));
                //second type

                Console.WriteLine("Second type coding");

                decoded = secondTypeCoding.Encode(enterString);

                Console.WriteLine(" Encoded string: " + decoded);
                Console.WriteLine(" Decoded string: " + secondTypeCoding.Decode(decoded));
            }
        }
    }
    /// <summary>
    /// Абстрактний клас виконавця
    /// </summary>
    abstract class SystemCoder
    { 
        public string name {get;set;}
        public SystemCoder(string name)
        {
            this.name = name;
        }
        abstract public Coder CreateCoder();
       // abstract public Coder Encode();
    }
    /// <summary>
    /// Клас фабрики кодування
    /// </summary>
    abstract class Coder
    {
        abstract public string Decode(string data);
        abstract public string Encode(string data);
    }
    /// <summary>
    /// Клас першого виковця
    /// </summary>
    class FirstTypeCoder : SystemCoder
    {
      public FirstTypeCoder(string name):base(name)
        { }

      public override Coder CreateCoder()
      {
          return new ShiftCoder();
      }
    }
    /// <summary>
    /// Клас другого виконавця
    /// </summary>
    class SecondTypeCoder : SystemCoder
    {
        public SecondTypeCoder(string name)
            : base(name)
        { }

        public override Coder CreateCoder()
        {
            return new SwapCoder();
        }
    }
    /// <summary>
    /// Клас кодування зсувом ASCII коду символу
    /// </summary>
    class ShiftCoder : Coder
    {   
        public override string Decode(string data)
        {
            string trueString = string.Empty;
            int temp;
            foreach(char symbol in data){
                temp = (int)symbol;
                trueString += Convert.ToChar(--temp).ToString();
            }
            return trueString;
        }
        public override string Encode(string data)
        {
            string codedString = string.Empty;
            int temp;
            for (int i = 0; i < data.Length; i++)
            {
                temp = (int)data[i];
                codedString += Convert.ToChar(temp+1).ToString();
            }
            return codedString;
        }
    }
    /// <summary>
    /// Кодування переставляння парних з непарними символами
    /// </summary>
    class SwapCoder : Coder
    {
        public override string Decode(string data)
        {
            string codedString = string.Empty;
            for (int i = 0; i < data.Length; i += 2)
            {
                //Console.WriteLine(data[i]);
                if (data.Length == i + 1)
                {
                    codedString += data[i];
                }
                else
                {
                    codedString += data[i + 1];
                    codedString += data[i];
                }
                //Console.WriteLine(codedString);

            }
            
            return codedString;
        }

        public override string Encode(string data)
        {
            string codedString = string.Empty;
            for (int i = 0; i < data.Length; i += 2)
            {
                //Console.WriteLine(data[i]);
                if (data.Length == i + 1)
                {
                    codedString += data[i];
                }
                else
                {
                    codedString += data[i + 1];
                    codedString += data[i];
                }
                //Console.WriteLine(codedString);

            }
                return codedString;
        }
    }
}
