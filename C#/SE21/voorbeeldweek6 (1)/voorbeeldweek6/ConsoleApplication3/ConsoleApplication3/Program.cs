using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ConsoleApplication3
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Connection myConnection = new Connection();
            Display myDisplay = new Display();
            myConnection.messageArrived+=new MessageHandler(myDisplay.DisplayMessage);
            myConnection.Connect();
            Console.ReadKey();
        }
    }
}
