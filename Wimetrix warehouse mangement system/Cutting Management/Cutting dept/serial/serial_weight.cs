using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Wimetrix_warehouse_mangement_system.Cutting_Management.Cutting_dept.serial
{
    class serial_weight
    {
        SerialPort serial;
        string recieved_data;
        bool serial_flag = false;
        public serial_weight()
        {
           
        }
        public void disconnectSerial()
        {
            if (serial_flag)
            {
                if (serial.IsOpen)
                {
                    serial_flag = false;
                    serial.Close();
                }
            }           
        }
        public void connectSerial()
        {
            disconnectSerial();
            if (!serial_flag)
            {
                serial = new SerialPort("COM100", 9600, Parity.None, 8, StopBits.One)
                {
                    DtrEnable = true,
                    RtsEnable = true,
                    Handshake = System.IO.Ports.Handshake.None,
                    Parity = Parity.None,
                    DataBits = 8,
                    StopBits = StopBits.One,
                    ReadTimeout = 10000,
                    WriteTimeout = 500
                };
                try
                {
                    if (!serial.IsOpen)
                    {
                        try
                        {
                            serial.Open();
                            serial_flag = true;                     
                            serial.DataReceived += new SerialDataReceivedEventHandler(Recieve);
                            Wimetrix_warehouse_mangement_system.Cutting_Management.Cutting_dept.cutting_UC us = Wimetrix_warehouse_mangement_system.Cutting_Management.Cutting_dept.cutting_UC.Instance;
                            us.showSuccess("Weight Scale Connected");

                        }
                        catch (Exception ex)
                        {
                            serial_flag = false;
                            Wimetrix_warehouse_mangement_system.Cutting_Management.Cutting_dept.cutting_UC us = Wimetrix_warehouse_mangement_system.Cutting_Management.Cutting_dept.cutting_UC.Instance;
                            us.ShowError("Failed to Connect to Weight Scale");
                        }

                    }


                }
                catch (Exception ex)
                {
                    //    index_toast.ShowError(ex.Message.ToString());
                }
            }
      
        }
        private delegate void UpdateUiTextDelegate(string text);
        private void Recieve(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // Collecting the characters received to our 'buffer' (string).
            try
            {

                recieved_data = serial.ReadLine();
                // Console.WriteLine(recieved_data);
                if (recieved_data.Contains("kg")) ;
                WriteData(recieved_data);
                  //Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(WriteData), recieved_data);
            }
            catch (Exception ex)
            {
                //  index_toast.ShowError(ex.Message.ToString());
            }
        }
        private void WriteData(string text)
        {
            String[] weight = text.Split(',');
            if (weight.Count() >= 1)
            {
                Wimetrix_warehouse_mangement_system.Cutting_Management.Cutting_dept.cutting_UC us = Wimetrix_warehouse_mangement_system.Cutting_Management.Cutting_dept.cutting_UC.Instance;

                try
                {
                    if (weight[2].Contains("-"))
                    {
                        us.weight_receiver("0.00");
                    }
                    else
                    {
                           string weight_value = Regex.Replace(weight[2], "[^0-9.]", "");
                           float final_weight = float.Parse(weight_value);
                        Console.WriteLine(final_weight.ToString());
                           us.weight_receiver(final_weight.ToString());
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        }
    }
