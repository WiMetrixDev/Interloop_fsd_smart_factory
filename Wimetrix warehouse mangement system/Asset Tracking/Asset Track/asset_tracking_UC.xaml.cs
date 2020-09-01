using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Asset_Track
{
    public partial class asset_tracking_UC : UserControl
    {
        static List<asset_track_model> ground_floor_machines = new List<asset_track_model>();
        static List<asset_track_model> first_floor_machines = new List<asset_track_model>();
        static List<asset_track_model> basement_machines = new List<asset_track_model>();
        static List<asset_track_model> maintenance_machines = new List<asset_track_model>();
        static List<asset_allocation_log_model> asset_allocation_log_list = new List<asset_allocation_log_model>();
        public asset_tracking_UC()
        {
            InitializeComponent();
            notification_disptachter();
            fetch_assets_tracking_detail();
        }
        private DispatcherTimer dispatcherTimer;
        public void notification_disptachter()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            notifier.Visibility = System.Windows.Visibility.Collapsed;

            //Disable the timer
            dispatcherTimer.IsEnabled = false;
        }
        public void ShowError(String text)
        {
            notifier.Text = text;
            notifier.Background = Brushes.IndianRed;
            notifier.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
        }
        public void showSuccess(String text)
        {
            notifier.Text = text;
            notifier.Background = Brushes.LimeGreen;
            notifier.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
        }
        public void fetch_assets_tracking_detail()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.Asset_get_goods_complete_data);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Goods").ToString()); // parse as array  
                grid_floor_1.ItemsSource = null;
                grid_floor_1.Items.Clear();
                grid_floor_2.ItemsSource = null;
                grid_floor_2.Items.Clear();
                grid_floor_3.ItemsSource = null;
                grid_floor_3.Items.Clear();
                grid_floor_4.ItemsSource = null;
                grid_floor_4.Items.Clear();
                ground_floor_machines.Clear();
                first_floor_machines.Clear();
                basement_machines.Clear();
                maintenance_machines.Clear();

                foreach (JObject root in objects)
                {
                    String Machine = root.GetValue("Machine_Code").ToString();
                    String Machine_Type = root.GetValue("Machine_Type_Code").ToString();
                    String Department_code = root.GetValue("Dept_Code").ToString();
                    String Brand_code = root.GetValue("Brand_Code").ToString();
                    String Floor_code = root.GetValue("Floor_ID").ToString();
                    String Remarks = root.GetValue("Remarks").ToString();
                    String RFID_Code = root.GetValue("RFID_Code").ToString();
                    if (RFID_Code != "")
                    {
                        //RFID_Code.Remove(0);
                        Char[] machine_serail = RFID_Code.ToCharArray();
                        Char[] machine_serail_format = new char[2];

                        machine_serail_format[0] = machine_serail[1];
                        machine_serail_format[1] = '-';
                        string serial_number_starting_part = new string(machine_serail_format);

                        string serial_number_ending_part = RFID_Code.Substring(4);
                        String Machine_number = serial_number_starting_part + serial_number_ending_part;
                        if (Floor_code == "GROUND FLOOR")
                        {
                            ground_floor_machines.Add(new asset_track_model(Machine_number, Machine_Type, Remarks));
                        }
                        else
                        {
                            if (Floor_code == "FIRST FLOOR")
                            {
                                first_floor_machines.Add(new asset_track_model(Machine_number, Machine_Type, Remarks));
                            }
                            else
                            {
                                if (Floor_code == "BASEMENT")
                                {
                                    basement_machines.Add(new asset_track_model(Machine_number, Machine_Type, Remarks));
                                }
                                else
                                {
                                    if (Floor_code == "MAINTENANCE")
                                    {
                                        maintenance_machines.Add(new asset_track_model(Machine_number, Machine_Type, Remarks));
                                    }
                                }
                            }
                        }
                    }

              

                }
                grid_floor_1.ItemsSource = basement_machines;
                grid_floor_2.ItemsSource = ground_floor_machines;
                grid_floor_3.ItemsSource = first_floor_machines;
                grid_floor_4.ItemsSource = maintenance_machines;

                text_floor1_count.Content = basement_machines.Count.ToString();
                text_floor2_count.Content = ground_floor_machines.Count.ToString();
                text_floor3_count.Content = first_floor_machines.Count.ToString();
                text_floor4_count.Content = maintenance_machines.Count.ToString();
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please check IP or server");
                }
                else
                {
                    if (result.geterrorCode() == "API-001")
                    {
                        ShowError("No Data found");
                    }
                }
            }

        }
        private void Grid_floor_1_MouseClick(object sender, MouseButtonEventArgs e)
        {          
            try
            {
                asset_track_model classObj = grid_floor_1.SelectedItem as asset_track_model;
                string id = classObj.Machine;
                get_allocation_log_list(id);
            }
            catch(Exception ex)
            {

            }
        }
        private void Grid_floor_2_MouseClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                asset_track_model classObj = grid_floor_2.SelectedItem as asset_track_model;
                string id = classObj.Machine;
                get_allocation_log_list(id);
            }
            catch (Exception ex)
            {

            }
        }
        private void Grid_floor_3_MouseClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                asset_track_model classObj = grid_floor_3.SelectedItem as asset_track_model;
                string id = classObj.Machine;
                get_allocation_log_list(id);
            }
            catch (Exception ex)
            {

            }
        }
        public void get_allocation_log_list(String machine)
        {
            //grid_popup.ItemsSource = null;
            //grid_popup.Items.Clear();
            //asset_allocation_log_list.Clear();

            //asset_allocation_log_list.Add(new asset_allocation_log_model(machine, "29-3-2019", "Floor 1", "Basement"));
            //asset_allocation_log_list.Add(new asset_allocation_log_model(machine, "29-3-2019", "Floor 2", "Floor 1"));
            //asset_allocation_log_list.Add(new asset_allocation_log_model(machine, "29-3-2019", "Floor 1", "Floor 2"));
            //asset_allocation_log_list.Add(new asset_allocation_log_model(machine, "29-3-2019", "Floor 2", "Floor 1"));

            //grid_popup.ItemsSource = asset_allocation_log_list;
            //asset_tracking_machine_status.IsOpen = true;
        }
        private void btn_popup_ok_Click(object sender, RoutedEventArgs e)
        {
            //asset_tracking_machine_status.IsOpen = false;
        }

        private void Btn_reload_Click(object sender, RoutedEventArgs e)
        {
            fetch_assets_tracking_detail();
        }
    }
}
