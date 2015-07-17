using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ConsoleApplication3
{
    public delegate void MessageHandler(string messageText);

    class Connection
    {
        public event MessageHandler messageArrived;
        private Timer pollTimer;

        public Connection()
        {
            pollTimer = new Timer(100);//0.1 seconde pollen
            pollTimer.Elapsed+=new ElapsedEventHandler(CheckForMessage);
        }

        public void Connect()
        {
            pollTimer.Start();
        }

        public void Disconnect()
        {
            pollTimer.Stop();
        }

        private static Random random = new Random();

        private void CheckForMessage(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Checking for new messages.");
            if((random.Next(9)==0)&&(messageArrived!=null))
                messageArrived("Hoi Mam");
        }

    }

    public class Display
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine("Message arrived: {0}", message);
        }
    }


}
