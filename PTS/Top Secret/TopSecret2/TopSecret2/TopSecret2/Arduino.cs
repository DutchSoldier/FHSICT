using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.IO.Ports;
using System.Diagnostics;

namespace TopSecret2
{
    class Arduino
    {
        private const int connectionSpeed = 38400;
        private SerialPort serialPort;
        private string code = "";

        public Arduino(int compoort)
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            string port = "COM" + Convert.ToString(compoort);
            try
            {
                serialPort.PortName = port;
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                }
            }
            catch
            {
            }
        }

        public bool checkCode()
        {
            if (serialPort.IsOpen&& serialPort.BytesToRead > 0)
            {
                try
                {
                    if (code.Length >= 3)
                    {
                        code = "";
                    }

                    String dataFromSocket = serialPort.ReadExisting();
                    code += dataFromSocket;

                    if (code.Contains("159"))
                    {
                        code = "";
                        serialPort.Close();
                        return true;
                    }
                }
                catch
                {
                }
            }
            return false;
        }

        public string returnCode()
        {
            return code;
        }
    }
}
