using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Methode1();
        }
        
        public static void Methode1()
        {
            Console.WriteLine("Dit is methode1");
            Methode2();
        }

        public static void Methode2()
        {
            Console.WriteLine("Dit is methode2");
            Methode3();
        }

        public static void Methode3()
        {
            Console.WriteLine("En dit is methode3");
            Console.ReadLine();
        }

    }
}
