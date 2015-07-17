using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        delegate double RekenDelegate(double param1, double param2);


        static double Maal(double param1, double param2)
        {
            return param1 * param2;
        }


        static double Deel(double param1, double param2)
        {
            return param1 / param2;
        }

        static double VoerUit(RekenDelegate bereken)
        {
            return bereken(2, 3);

        }
       

     
        static void Main(string[] args)
        {
          
            RekenDelegate bereken;
            Console.WriteLine("Voer 2 getallen in gescheiden door een komma:");
            string input = Console.ReadLine();
            int kommapos=input.IndexOf(',');
            double param1 = Convert.ToDouble(input.Substring(0, kommapos));
            double param2 = Convert.ToDouble(input.Substring(kommapos+1,input.Length-kommapos-1));
            Console.WriteLine("Voer M in voor Maal of D voor Deel: ");

            input=Console.ReadLine();
            if (input == "M")
                bereken = new RekenDelegate(Maal);
            else
                bereken = new RekenDelegate(Deel);
            Console.WriteLine("Resultaat: {0}", bereken(param1, param2));
            Console.ReadKey();
            Console.WriteLine(VoerUit(bereken));
            Console.ReadKey();

        }
    }
}
