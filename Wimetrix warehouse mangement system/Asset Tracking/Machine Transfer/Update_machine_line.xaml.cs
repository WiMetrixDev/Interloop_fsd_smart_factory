using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal.View_Assets;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Machine_Transfer
{
    /// <summary>
    /// Interaction logic for Update_machine_line.xaml
    /// </summary>
    public partial class Update_machine_line : UserControl
    {
        static ObservableCollection<admin_view_asset_model> Asset_list = new ObservableCollection<admin_view_asset_model>();
        static ObservableCollection<String> line_list = new ObservableCollection<String>();
        public Update_machine_line()
        {
            InitializeComponent();
            notification_disptachter();
            fetch_machine_details();
            fetch_lines();
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
        public void fetch_machine_details()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.Asset_get_goods_complete_data);
            if (result.getresultFlag())
            {
                Asset_list.Clear();
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Goods").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String good_id = root.GetValue("Good_id").ToString();
                    String Machine = root.GetValue("Machine_Code").ToString();
                    String Machine_Type = root.GetValue("Machine_Type_Code").ToString();
                    String Department_code = root.GetValue("Dept_Code").ToString();
                    String Brand_code = root.GetValue("Brand_Code").ToString();
                    String Floor_code = root.GetValue("Floor_Code").ToString();
                    String RFID = root.GetValue("RFID_Code").ToString();
                    String Remarks = root.GetValue("Remarks").ToString();
                    String Country = root.GetValue("Country").ToString();
                    String Machine_sub_type = root.GetValue("Machine_sub_type").ToString();
                    String Model_code = root.GetValue("Model_code").ToString();
                    String Vendor_code = root.GetValue("Vendor_code").ToString();
                    String Supplier_code = root.GetValue("Supplier_code").ToString();
                    String module_code = root.GetValue("module_code").ToString();
                    String price = root.GetValue("Price").ToString();
                    String igp_date = root.GetValue("igp_date").ToString();
                    String manufacturing_year = root.GetValue("manufacturing_year").ToString();
                    String installation_date = root.GetValue("installation_date").ToString();
                    String Line = root.GetValue("Line").ToString();
                    string RFID_Code = RFID;
                    if (RFID_Code != "")
                    {
                        try
                        {
                            // RFID_Code.Remove(0);
                            Char[] machine_serail = RFID_Code.ToCharArray();
                            Char[] machine_serail_format = new char[2];
                            machine_serail_format[0] = machine_serail[1];
                            machine_serail_format[1] = '-';
                            string serial_number_starting_part = new string(machine_serail_format);
                            string serial_number_ending_part = RFID_Code.Substring(4);
                            String Machine_number = serial_number_starting_part + serial_number_ending_part;
                            Asset_list.Add(new admin_view_asset_model(good_id, Machine, Machine_Type, Floor_code, price, Machine_number, Country, Machine_sub_type, Model_code, Vendor_code, Supplier_code, Brand_code, module_code, igp_date, manufacturing_year, installation_date, Line));
                        }
                        catch (Exception ex)
                        {

                        }
                    }


                }
                combo_machine.ItemsSource = Asset_list;
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
        private void combo_machine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_machine.SelectedIndex > -1)
            {
                int pos = combo_machine.SelectedIndex;
                admin_view_asset_model machine = Asset_list[pos];
                text_current_line.Text = machine.Line;
            }
            else
            {
                text_current_line.Text = "";
            }
 
        }
        public void fetch_lines()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_lines);
            if (result.getresultFlag())
            {
                line_list.Clear();
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Lines").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String Line = root.GetValue("Line_ID").ToString();
                    line_list.Add(Line);
                }
                combo_line.ItemsSource = line_list;
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

        private void btn_update_line_Click(object sender, RoutedEventArgs e)
        {
            if(combo_line.SelectedIndex>-1 && combo_machine.SelectedIndex>-1)
            {
                int pos = combo_machine.SelectedIndex;
                admin_view_asset_model machine = Asset_list[pos];
                Update_machines_line(machine.Good_id, combo_line.Text);
            }
            else
            {
                ShowError("Select Machine and Line");
            }
        }

        public void Update_machines_line(String machine,String line)
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("machine", machine);
            reqarm.Add("line", line);

            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.update_machine_line);
            if (result.getresultFlag())
            {
                showSuccess("Line has been Updated");
                fetch_machine_details();
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

    }
}
