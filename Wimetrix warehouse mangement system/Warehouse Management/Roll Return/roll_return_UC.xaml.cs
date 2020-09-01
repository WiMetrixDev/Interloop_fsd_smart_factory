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
using Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Roll_Return
{
    /// <summary>
    /// Interaction logic for roll_return_UC.xaml
    /// </summary>
    public partial class roll_return_UC : UserControl
    {
        List<stocking_model> roll_return_list = new List<stocking_model>();
        public roll_return_UC()
        {
            InitializeComponent();
            notification_disptachter();
            fetch_data_for_selected_filters();
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
        private void DataGridColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            if (grid_issuance.ItemsSource != null)
            {
               String column = grid_issuance.Columns[0].Header.ToString();
                if(column=="Select All")
                {
                    foreach (stocking_model stock_item in grid_issuance.ItemsSource)
                    {
                        grid_issuance.ItemsSource = null;
                        stock_item.Select = true;
                    }
                    grid_issuance.Columns[0].Header = "UnSelect All";
                    grid_issuance.ItemsSource = roll_return_list;
                }
                else
                {
                    if(column == "UnSelect All")
                    {
                        foreach (stocking_model stock_item in grid_issuance.ItemsSource)
                        {
                            grid_issuance.ItemsSource = null;                        
                            stock_item.Select = false;                       
                     
                        }
                        grid_issuance.Columns[0].Header = "Select All";
                        grid_issuance.ItemsSource = roll_return_list;
                    }
                }
           
            }
        

        }
        public void fetch_data_for_selected_filters()
        {
            grid_issuance.ItemsSource = null;
            grid_issuance.Items.Clear();
            roll_return_list.Clear();
           var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_roll_return_get_rolls);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Roll_Data").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String Roll = root.GetValue("Roll Code").ToString();
                    String Order = root.GetValue("Order Code").ToString();
                    String Weight = root.GetValue("Weight").ToString();
                    String Color = root.GetValue("Color").ToString();
                    String Vendor = root.GetValue("Vendor Code").ToString();
                    String Fabric_Lot = root.GetValue("Fabric Lot Code").ToString();
                    String Fabric_Type = root.GetValue("Fabric Type Code").ToString();
                    roll_return_list.Add(new stocking_model(false, Order, Roll, Color, Weight, Vendor, Fabric_Lot, Fabric_Type,""));
                }
                grid_issuance.ItemsSource = roll_return_list;
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please Check IP Or Server");
                }

                if (result.geterrorCode() == "API-001")
                {
                    ShowError(result.getDescription());
                }

                if (result.geterrorCode() == "HTTP")
                {
                    ShowError("HTTP Request Error");
                }

                if (result.geterrorCode() == "API")
                {
                    ShowError("Unexpected Response From Server File");
                }


            }
        }
        private void btn_return_roll_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int upload_count = 0;
            foreach (stocking_model stock_item in grid_issuance.ItemsSource)
            {
                if (stock_item.Select)
                {
                    var reqarm = new System.Collections.Specialized.NameValueCollection();
                    reqarm.Add("roll_id", stock_item.Roll_ID);
                    reqarm.Add("status", "1");
                    Http.http_request request = new Http.http_request();
                    Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.insert_roll_return);
                    count++;
                    if (result.getresultFlag())
                    {
                        upload_count++;
                    }

                }

            }

            if (upload_count == count)
            {
                showSuccess("Selected rolls returned to warehouse");
                grid_issuance.ItemsSource = null;
                grid_issuance.Items.Clear();
                roll_return_list.Clear();
            }
            else
            {
                ShowError("Failed to return some or all selected rolls to warehouse");
            }

            fetch_data_for_selected_filters();
        }

        private void btn_roll_reject_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int upload_count = 0;
            foreach (stocking_model stock_item in grid_issuance.ItemsSource)
            {
                if (stock_item.Select)
                {
                    var reqarm = new System.Collections.Specialized.NameValueCollection();
                    reqarm.Add("roll_id", stock_item.Roll_ID);
                    reqarm.Add("status", "0");
                    Http.http_request request = new Http.http_request();
                    Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.insert_roll_return);
                    count++;
                    if (result.getresultFlag())
                    {
                        upload_count++;
                    }

                }

            }

            if (upload_count == count)
            {
                showSuccess("Selected rolls rejected from Warehouse");
                grid_issuance.ItemsSource = null;
                grid_issuance.Items.Clear();
                roll_return_list.Clear();
            }
            else
            {
                ShowError("Failed to reject some or all selected rolls to warehouse");
            }

            fetch_data_for_selected_filters();
        }
    }
}

