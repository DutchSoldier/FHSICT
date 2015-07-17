/* - PHSensor simple -
 ****************************************************************************************
 * This simple example simply opens a PH sensor phidget and waits for one to be attached. 
 * The program will then wait for user input to terminate.  While waiting it will display 
 * the data generated by the events, such as the PH change event which will display the 
 * currently measured PH without sensitivity modifications.  For a more detailed example 
 * where sensitivity can be adjusted and all the functionalities of a PH sensor are 
 * demonstrated, see PHSensor-full example.
 * 
 * Please note that this example was designed to work with only one Phidget PHSensor 
 * connected. 
 * For an example showing how to use two Phidgets of the same time concurrently, please see the
 * Servo-multi example in the Servo Examples.
 *
 * Copyright 2007 Phidgets Inc.  
 * This work is licensed under the Creative Commons Attribution 2.5 Canada License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/2.5/ca/
 */
using System;
using System.Collections.Generic;
using System.Text;
//Needed for the PHSensor class, Phidget base classes, and the PhidgetException class
using Phidgets;  
//Needed for the Phidget event handler classes
using Phidgets.Events; 

namespace PHSensor_simple
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PHSensor ph_sensor = new PHSensor(); //Declare a PHSensor object

                //hook the basic event handlers
                ph_sensor.Attach += new AttachEventHandler(ph_sensor_Attach);
                ph_sensor.Detach += new DetachEventHandler(ph_sensor_Detach);
                ph_sensor.Error += new ErrorEventHandler(ph_sensor_Error);

                //hook the phidget specific event handlers
                ph_sensor.PHChange += new PHChangeEventHandler(ph_sensor_PHChange);

                //open the phidget object to allow connections with phidget PH sensor 
                //devices
                ph_sensor.open();

                //Make the program wait for a Phidget PHSensor to be attached before 
                //trying to communicate with one If we try and call the methods of the 
                //ph_sensor object without a PHSensor device attached, a PhidgetException
                //will be thrown
                Console.WriteLine("Waiting for PHSensor to be attached....");
                ph_sensor.waitForAttachment();

                //Get the program to wait for user input to continue so that we can see 
                //some events fire and console output to be displayed
                Console.WriteLine("Hit any key to end the program....");
                Console.Read();

                //Since user input was read, we'll terminate the program, so close the 
                //ph_sensor object
                ph_sensor.close();

                //null he object to clear it from memory
                ph_sensor = null;

                //If no exceptions were thrown at this point, the program is ok to
                //terminate
                Console.WriteLine("ok");
            }
            catch (PhidgetException ex)
            {
                Console.WriteLine(ex.Description);
            } 
        }

        //Attach event handler...we'll display the serial number of the PHSensor device
        //that was attached to the console
        static void ph_sensor_Attach(object sender, AttachEventArgs e)
        {
            Console.WriteLine("PH Sensor {0} attached!", 
                                    e.Device.SerialNumber.ToString());
        }

        //Detach event handler...we'll display the serial number of the PHSensor 
        //device that was detached to the console
        static void ph_sensor_Detach(object sender, DetachEventArgs e)
        {
            Console.WriteLine("PH Sensor {0} detached!", 
                                    e.Device.SerialNumber.ToString());
        }

        //Error event handler...we'll display the error description to the console
        static void ph_sensor_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.Description);
        }

        //PH Changed event handler...display the current measured PH to the console.
        static void ph_sensor_PHChange(object sender, PHChangeEventArgs e)
        {
            Console.WriteLine("PH measured: {0}", e.PH.ToString());
        }
    }
}
