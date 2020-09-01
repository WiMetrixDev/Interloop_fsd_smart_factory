using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Assign_Rfid
{
    /// <summary>
    /// Interaction logic for assign_rfid.xaml
    /// </summary>
    public partial class assign_rfid : UserControl
    {
        private SerialPort serial;
        string recieved_data;
        bool serial_flag = false;
        public assign_rfid()
        {
            InitializeComponent();
            populateComboPorts();
            populateOrders();
        }
        public void populateComboPorts()
        {
            combo_serial.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {                
            combo_serial.Items.Add(port);
            }

        }

        public void populateOrders()
        {
            combo_order.Items.Add("ABC1");
            combo_order.Items.Add("ABC2");
            combo_order.Items.Add("ABC3");
            combo_order.Items.Add("ABC4");

        }

        public void populateRolls()
        {
            combo_roll.Items.Add("Roll 1");
            combo_roll.Items.Add("Roll 2");
            combo_roll.Items.Add("Roll 3");
            combo_roll.Items.Add("Roll 4");
            combo_roll.Items.Add("Roll 5");
        }

        private void combo_serial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Selection");
        }

        private void combo_order_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_order.Text.ToString()!=" "){
                populateRolls();
            }
        }
        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            text_rfid.Text = "00000001";
        }
        private void grid_packing_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btn_connect_Click(object sender, RoutedEventArgs e)
        {
            if (btn_connect.Content.ToString() == "Connect")
            {
                connect_serial();
                if (serial_flag)
                {
                    btn_connect.Content = "Disconnect";
                }
           
            }
            else
            {
                if (btn_connect.Content.ToString() == "Disconnect")
                {
                    disconnect_serial();
                    populateComboPorts();
                    if (!serial_flag)
                    {
                        btn_connect.Content = "Connect";
                    }
                    
                }
            }
        }
        private void connect_serial()
        {
            String s = combo_serial.Text;
            if (!s.Equals(""))
            {
                serial = new SerialPort(s, 115200, Parity.None, 8, StopBits.One)
                {
                    DtrEnable = true,
                    RtsEnable = true,
                    Handshake = System.IO.Ports.Handshake.None,
                    Parity = Parity.None,
                    DataBits = 8,
                    StopBits = StopBits.Two,
                    ReadTimeout = 200,
                    WriteTimeout = 50
                };
                try
                {
                    if (!serial.IsOpen)
                    {
                        serial.Open();
                        serial_flag = true;
                        serial.DataReceived += new SerialDataReceivedEventHandler(Recieve);
                        combo_serial.IsEnabled = false;
                    }


                }
                catch (Exception ex)
                {
                }

            }
        }
        private delegate void UpdateUiTextDelegate(string text);
        private void Recieve(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // Collecting the characters received to our 'buffer' (string).
            try
            {
                recieved_data = serial.ReadExisting();
                Console.Write("reading:");
                Console.WriteLine(recieved_data);
                // Console.WriteLine(recieved_data);
                // if (recieved_data.Contains("{") || recieved_data.Contains("<"))
                Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Send, new UpdateUiTextDelegate(WriteData), recieved_data);
            }
            catch (Exception ex)
            {
                //  index_toast.ShowError(ex.Message.ToString());
            }
        }
        private void WriteData(string recieved_data)
        {

        }
        public void sendData(String data)
        {
            if (serial.IsOpen)
            {
                serial.Write(data + "\r\n");
            }
        }
        private void disconnect_serial()
        {
            if (serial.IsOpen)
            {
                try
                {
                    serial.Close();
                    //login_toast.Dispose();
                    //login_toast.ShowSuccess("Successfully Disconnected");
                    serial_flag = false;
                    combo_serial.IsEnabled = true;
                }
                catch (Exception ex)
                {

                }

            }
        }

    }
}
