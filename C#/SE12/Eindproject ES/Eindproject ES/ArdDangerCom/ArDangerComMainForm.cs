using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;

namespace ArdDangerCom
{
    public partial class ArDangerComMainForm : Form
    {
        /// <summary>
        /// The speed of the serial connection (bytes per second).
        /// TODO: make sure that the speed in the Arduino program is set to the same value!
        /// Note: You can set this to a higher value like 57600 or 115200, 
        /// but data loss is possible then.
        /// </summary>
        private const int connectionSpeed = 38400;

        /// <summary>
        /// Marker to mark the start of a message.
        /// TODO: You can adapt this value to your own needs.
        /// </summary>
        private const String messageBeginMarker = "#";

        /// <summary>
        /// Marker to mark the end of a message.
        /// TODO: You can adapt this value to your own needs.
        /// </summary>
        private const String messageEndMarker = "%";

        /// <summary>
        /// Serial port used for the connection.
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// Buffer that is used to store data (text) that is received from the Arduino.
        /// Messages that a recevied can be retrieved from the messageBuilder.
        /// </summary>
        private MessageBuilder messageBuilder;
        private int huidigeSom;

        public ArDangerComMainForm()
        {
            InitializeComponent();
            huidigeSom = 0;
            FillSerialPortSelectionBoxWithAvailablePorts();
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            // Choose: 9600, 19200 or 38400. Getting errors? Choose lower speed.
            // Also be sure that you set the speed on the arduino to the same value!

            messageBuilder = new MessageBuilder(messageBeginMarker, messageEndMarker);
            UpdateUserInterface();
        }



        /// <summary>
        /// This method is called when a message is received.
        /// </summary>
        /// <param name="message">The received message</param>
        private void MessageReceived(String message)
        {
            // TODO: Put code here to handle the received message.
            //       The received message is contained in the message parameter.
            //
            // Watch it! received messages can be with or without parameters.
            //   Like E.g. "#SHOW_BUTTON_1_CLICKED%" (no parameters)
            //        or   "#SET_SLIDER_B_VALUE:7%"  (has an number parameter at the end,
            //                                        that notes the new value for slider B)
            // Hints: 
            //  - You can use the String methods to parse the message and (if present) its parameters.
            //    See: http://msdn.microsoft.com/en-us/library/system.string.aspx
            //     for help on available String methods like
            //     - String.StartsWith(...)
            //     - String.Substring(...)
            //     - String.IndexOf(...)
            //     - etc
            //  - Convert.ToInt32(...) can be used to convert strings to an integer.
            //  - Sliders have a 'Value' property which can be used to get/set the position of the slider.
            Console.WriteLine(message);

        }

        //====================================================================================
        // Please read the code below this comment block! 
        // There are methods in it you can use, like sendMessage(..). 
        // 
        // Also read the code in the 'MessageBuilder' class.
        // (see MessageBuilder.cs file in the project)
        // 
        // There is no need to change code below this comment block.
        // Please do not add code below this comment block.
        //====================================================================================

        /// <summary>
        /// Sends the given message to the serial port.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>true if the message was send, false otherwise.</returns>
        private bool SendMessage(String message)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(message);
                    return true;
                }
                catch (Exception exception) // Not very nice to catch Exception...but for now it's good enough.
                {
                    Debug.WriteLine("Could not write to serial port: " + exception.Message);
                }
            }
            return false;
        }

        /// <summary>
        /// Reads data from the serial port and get received messages from that data.
        /// Called on each tick of the messageReceiveTimer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void messageReceiveTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen
                && serialPort.BytesToRead > 0)
            {
                try
                {
                    String dataFromSocket = serialPort.ReadExisting();
                    DisplayReceivedRawData(dataFromSocket);
                    messageBuilder.Append(dataFromSocket);

                    ProcessMessages();

                    }
                
                catch (Exception exception) // Not very nice to catch Exception...but for now it's good enough.
                {
                    Debug.WriteLine("Could not read from serial port: " + exception.Message);
                }
            }
        }

        /// <summary>
        /// Find and process all buffered messages .
        /// </summary>
        private void ProcessMessages()
       {
            String message = messageBuilder.FindAndRemoveNextMessage();
            while (message != null)
            {
                MessageReceived(message);
                message = messageBuilder.FindAndRemoveNextMessage();
            }
        }

        /// <summary>
        /// Display a message in the 'received messages' UI box.
        /// </summary>
        /// <param name="message">The message to displayed</param>


        /// </summary>
        /// <param name="message">The message to displayed</param>


        /// <summary>
        /// Display received raw data in the 'Received raw data' UI box.
        /// </summary>
        /// <param name="data">The data to displayed</param>
        private void DisplayReceivedRawData(String data)
        {
            receivedRawDataTextBox.AppendText(data);
        }

        /// <summary>
        /// Close the serial connection when the form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArDangerComMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            readMessageTimer.Enabled = false;
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        /// <summary>
        /// Detect the serial ports when the refresh button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshSerialPortsButton_Click(object sender, EventArgs e)
        {
            FillSerialPortSelectionBoxWithAvailablePorts();
        }

        /// <summary>
        /// Set the selected serial port after leaving the selection box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPortSelectionBox_Leave(object sender, EventArgs e)
        {
            serialPortSelectionBox.Text = serialPortSelectionBox.Text.ToUpper();
        }

        /// <summary>
        /// Connect / disconnect the serial port when the connect button is pressed.
        /// And update the UI widgets.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                readMessageTimer.Enabled = false;
                serialPort.Close();
            }
            else
            {
                String port = serialPortSelectionBox.Text;
                try
                {
                    serialPort.PortName = port;
                    serialPort.Open();
                    if (serialPort.IsOpen)
                    {
                        serialPort.DiscardInBuffer();
                        serialPort.DiscardOutBuffer();
                    }
                    readMessageTimer.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Could not connect to the given serial port: " + exception.Message);
                }
            }

            UpdateUserInterface();
        }

        /// <summary>
        /// Clear message data from textboxes and from the messageUnderConstruction buffer.
        /// </summary>


        /// <summary>
        /// Enable / Disable UI widgets depending on the connected state of the serial port.
        /// </summary>
        private void UpdateUserInterface()
        {
            bool isConnected = serialPort.IsOpen;
            if (isConnected)
            {
                connectButton.Text = "Disconnect";
            }
            else
            {
                connectButton.Text = "Connect";
            }
            refreshSerialPortsButton.Enabled = !isConnected;
            serialPortSelectionBox.Enabled = !isConnected;
            receivedRawDataGroupBox.Enabled = isConnected;
        }

        /// <summary>
        /// Put all detected serial ports in the serial port selection box.
        /// </summary>
        private void FillSerialPortSelectionBoxWithAvailablePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);

            serialPortSelectionBox.Items.Clear();
            foreach (String port in ports)
            {
                serialPortSelectionBox.Items.Add(port);
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            huidigeSom = 1;
            lSom1.Enabled = true;
            lSom2.Enabled = false;
            lSom3.Enabled = false;
            lSom4.Enabled = false;
            lSom5.Enabled = false;
            lSom6.Enabled = false;
            lSom7.Enabled = false;
            lSom8.Enabled = false;
            checkSom();
        }

        private void bControleer_Click(object sender, EventArgs e)
        {
            if(huidigeSom == 1)
            {
                if (receivedRawDataTextBox.Text == lAntwoord1.Text)
                {
                    serialPort.Write("1");
                    lAntwoord1.Visible = true;
                    receivedRawDataTextBox.Clear();
                }
                else
                {
                    serialPort.WriteLine("2");
                    receivedRawDataTextBox.Clear();
                }
            }

            if (huidigeSom == 2)
            {
                if (receivedRawDataTextBox.Text == lAntwoord2.Text)
                {
                    serialPort.WriteLine("1");
                    lAntwoord2.Visible = true;
                    receivedRawDataTextBox.Clear();
                }
                else
                {
                    serialPort.WriteLine("2");
                    receivedRawDataTextBox.Clear();
                }
            }

            if (huidigeSom == 3)
            {
                if (receivedRawDataTextBox.Text == lAntwoord3.Text)
                {
                    serialPort.WriteLine("1");
                    lAntwoord3.Visible = true;
                    receivedRawDataTextBox.Clear();
                }
                else
                {
                    serialPort.WriteLine("2");
                    receivedRawDataTextBox.Clear();
                }
            }

            if (huidigeSom == 4)
            {
                if (receivedRawDataTextBox.Text == lAntwoord4.Text)
                {
                    serialPort.WriteLine("1");
                    lAntwoord4.Visible = true;
                    receivedRawDataTextBox.Clear();
                }
                else
                {
                    serialPort.WriteLine("2");
                    receivedRawDataTextBox.Clear();
                }
            }

            if (huidigeSom == 5)
            {
                if (receivedRawDataTextBox.Text == lAntwoord5.Text)
                {
                    serialPort.WriteLine("1");
                    lAntwoord5.Visible = true;
                    receivedRawDataTextBox.Clear();
                }
                else
                {
                    serialPort.WriteLine("2");
                    receivedRawDataTextBox.Clear();
                }
            }

            if (huidigeSom == 6)
            {
                if (receivedRawDataTextBox.Text == lAntwoord6.Text)
                {
                    serialPort.WriteLine("1");
                    lAntwoord6.Visible = true;
                    receivedRawDataTextBox.Clear();
                }
                else
                {
                    serialPort.WriteLine("2");
                    receivedRawDataTextBox.Clear();
                }
            }

            if (huidigeSom == 7)
            {
                if (receivedRawDataTextBox.Text == lAntwoord7.Text)
                {
                    serialPort.WriteLine("1");
                    lAntwoord7.Visible = true;
                    receivedRawDataTextBox.Clear();
                }
                else
                {
                    serialPort.WriteLine("2");
                    receivedRawDataTextBox.Clear();
                }
            }

            if (huidigeSom == 8)
            {
                if (receivedRawDataTextBox.Text == lAntwoord8.Text)
                {
                    serialPort.WriteLine("1");
                    lAntwoord8.Visible = true;
                    receivedRawDataTextBox.Clear();
                }
                else
                {
                    serialPort.WriteLine("2");
                    receivedRawDataTextBox.Clear();
                }
            }
            

        }

        private void bVolgende_Click(object sender, EventArgs e)
        {
            if (huidigeSom == 1)
            {
                huidigeSom = 2;
                lSom2.Enabled = true;
                checkSom();
                return;
            }

            if (huidigeSom == 2)
            {
                huidigeSom = 3;
                lSom3.Enabled = true;
                checkSom();
                return;
            }

            if (huidigeSom == 3)
            {
                huidigeSom = 4;
                lSom4.Enabled = true;
                checkSom();
                return;
            }

            if (huidigeSom == 4)
            {
                huidigeSom = 5;
                lSom5.Enabled = true;
                checkSom();
                return;
            }

            if (huidigeSom == 5)
            {
                huidigeSom = 6;
                lSom6.Enabled = true;
                checkSom();
                return;
            }

            if (huidigeSom == 6)
            {
                huidigeSom = 7;
                lSom7.Enabled = true;
                checkSom();
                return;
            }

            if (huidigeSom == 7)
            {
                huidigeSom = 8;
                lSom8.Enabled = true;
                checkSom();
                return;
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            receivedRawDataTextBox.Clear();
        }

        private void bVorige_Click(object sender, EventArgs e)
        {
            huidigeSom = huidigeSom - 1;
            checkSom();
        }

        private void checkSom()
        {
            if (huidigeSom > 0)
            {
                label10.Text = Convert.ToString(huidigeSom);
            }
        }

    }
}
