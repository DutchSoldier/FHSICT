using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ConsoleApplication2
{
    class Program
    {
        static int counter =0;

        static string displayString="Dit programma laat steeds een letter van deze string zien. ";

        static void Main(string[] args)
        {
            Timer myTimer=new Timer(100);
            myTimer.Elapsed+=new ElapsedEventHandler(WriteChar);
            myTimer.Start();
            Console.ReadKey();
        }

        static void WriteChar(object source, ElapsedEventArgs e)
        {
            Console.Write(displayString[counter++ %displayString.Length]);

        }
    }
}
