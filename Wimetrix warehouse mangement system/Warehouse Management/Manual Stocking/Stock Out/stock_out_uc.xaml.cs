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

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking.Stock_Out
{
    /// <summary>
    /// Interaction logic for stock_out_uc.xaml
    /// </summary>
    public partial class stock_out_uc : UserControl
    {
        static List<stock_out_model> stock_list = new List<stock_out_model>();
        public stock_out_uc()
        {
            InitializeComponent();
            notification_disptachter();
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

        private void progress_bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        public void load_data_for_order()
        {
            if (combo_orders.Text != "")
            {
                grid_out.ItemsSource = null;
                stock_list.Clear();
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                reqarm.Add("order_id", combo_orders.Text.ToString());
                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_rolls_list_for_order_OUT);
                if (result.getresultFlag())
                {
                    JObject json = result.getjsonResult();
                    var objects = JArray.Parse(json.GetValue("Roll_Data").ToString()); // parse as array  
                    foreach (JObject root in objects)
                    {
                        String Roll = root.GetValue("Roll Code").ToString();
                        String Order_code = root.GetValue("Order Code").ToString();
                        String Color = root.GetValue("Color").ToString();
                        String Weight = root.GetValue("Weight").ToString();
                        String Fabric_type = root.GetValue("Fabric Type Code").ToString();
                        String Fabric_lot = root.GetValue("Fabric Lot Code").ToString();
                        String vendor = root.GetValue("Vendor Code").ToString();
                        String location = root.GetValue("To Location").ToString();

                        stock_list.Add(new stock_out_model(false, Order_code, Roll, Color, Weight, vendor, Fabric_lot, Fabric_type,location));
                    }
                    grid_out.ItemsSource = stock_list;
                }
                else
                {
                    if (result.geterrorCode() == "server001")
                    {
                        ShowError("Please Check IP Or Server");
                    }

                    if (result.geterrorCode() == "API-001")
                    {
                        ShowError("No Rolls Available For Stock Out Against The Selected Order");
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
            else
            {
                ShowError("Please Select Order");
            }
        }
        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            load_data_for_order();
        }
        private void btn_stock_out_Click(object sender, RoutedEventArgs e)
        {
            String RFID = null;
            if (grid_out.ItemsSource != null)
            {
                int count = 0;
                int upload_count = 0;
                foreach (stock_out_model stock_item in grid_out.ItemsSource)
                {
                  
                    if (stock_item.Select)
                    {
                        if (Stock_IN(stock_item.Roll_ID, stock_item.Weight))
                        {
                            upload_count++;
                        }
                        count++;

                    }
                   
                }
                if (upload_count == count)
                {
                    showSuccess("Rolls Stocked Out Successfully");
                }
                load_data_for_order();
            }
        }
        public bool Stock_IN(String RFID,String WEIGHT)
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("card_epc", RFID);
         
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.stock_out);
            String errorCode = result.geterrorCode();
            String description = result.geterrorCode();
            if (result.getresultFlag())
            {
                if (allocate_location(RFID, WEIGHT))
                {
                    return true;
                }
                else
                {
                    return false; 
                }
               
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please Check IP Or Server");
                }
                else
                {
                    ShowError("Error Stocking OUT");
                }
                return false;
            }
        }

        public bool allocate_location(String RFID, String WEIGHT)
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("roll_id", RFID);
            reqarm.Add("location_id", "102");
            reqarm.Add("weight", WEIGHT);

            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.for_issuance_insert_department_issuance);
            String errorCode = result.geterrorCode();
            String description = result.geterrorCode();
            if (result.getresultFlag())
            {
                return true;
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please Check IP Or Server");
                }
                else
                {
                    ShowError("Error Stocking IN");
                }
                return false;
            }
        }
    }
}
