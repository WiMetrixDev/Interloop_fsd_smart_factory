using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking.Stock_IN
{
    /// <summary>
    /// Interaction logic for stock_in_uc.xaml
    /// </summary>
    public partial class stock_in_uc : UserControl
    {
        static List<stock_in_model> stock_list = new List<stock_in_model>();
        public stock_in_uc()
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
            notifier.Foreground = Brushes.White;
            notifier.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
        }
        public void showSuccess(String text)
        {
            notifier.Text = text;
            notifier.Background = Brushes.LimeGreen;
            notifier.Foreground = Brushes.White;
            notifier.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
        }
        private void combo_orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            load_data_for_order();
        }
        public void load_data_for_order()
        {
            if (combo_orders.Text != "")
            {
                grid_stock_in.ItemsSource = null;
                stock_list.Clear();
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                reqarm.Add("order_id", combo_orders.Text.ToString());
                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_rolls_list_for_order_IN);
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
                        String Card_status = root.GetValue("Card Status").ToString();
                        stock_list.Add(new stock_in_model(false, Order_code, Roll, Color, Weight,vendor,Fabric_lot,Fabric_type,Card_status));
                    }
                    grid_stock_in.ItemsSource = stock_list;
                }
                else
                {
                    if (result.geterrorCode() == "server001")
                    {
                        ShowError("Please Check IP Or Server");
                    }

                    if (result.geterrorCode() == "API-001")
                    {
                        ShowError("No Rolls Avaialble For Stock IN Against The Selected Order");
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
        private void btn_stock_in_Click(object sender, RoutedEventArgs e)
        {
            String RFID = null;
            if (grid_stock_in.ItemsSource != null)
            {
                int count = 0;
                int upload_count = 0;

                foreach (stock_in_model stock_item in grid_stock_in.ItemsSource)
                {
                    if (stock_item.Select)
                    {
                        if(assign_rfid(stock_item.Roll_ID, stock_item.Weight))
                        {
                            if (Stock_IN(stock_item.Roll_ID, stock_item.Weight))
                            {
                                DataGridRow row = grid_stock_in.ItemContainerGenerator.ContainerFromIndex(count) as DataGridRow;
                                row.Foreground = Brushes.Green;
                                upload_count++;
                            }
                            else
                            {
                                DataGridRow row = grid_stock_in.ItemContainerGenerator.ContainerFromIndex(count) as DataGridRow;
                                row.Foreground = Brushes.IndianRed;
                            }
                            count++;
                        }                    
                    }                 
                }
                if (upload_count == count)
                {
                    showSuccess("Rolls Stocked IN Successfully");
                }
                load_data_for_order();
            }
        }
        //public Boolean generate_RFID(String rollID,String order)
        //{
        //    var reqarm = new System.Collections.Specialized.NameValueCollection();
        //    Http.http_request request = new Http.http_request();
        //    Http.HttpResult result = request.send_request(reqarm, Http.api_files.generate_rfid_for_roll);
        //    if (result.getresultFlag())
        //    {
        //       String  RFID = result.getjsonResult().GetValue("Rfid Tag").ToString();
        //        // MessageBox.Show(RFID + stock_item.Roll_ID);
        //       if(Assign_RFID(rollID, order, RFID))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        if (result.geterrorCode() == "server001")
        //        {
        //            ShowError("Please check IP or server");
        //        }
        //        else
        //        {
        //            ShowError("Error Generating RFID");
        //        }
        //        return false;
        //    }
        //}
      //public Boolean Assign_RFID(String roll_ID,String order_ID,String RFID)
      //  {
      //      var reqarm = new System.Collections.Specialized.NameValueCollection();
      //      reqarm.Add("rfid_tag",RFID);
      //      reqarm.Add("roll_id",roll_ID);
      //      reqarm.Add("io_no",order_ID);
      //      Http.http_request request = new Http.http_request();
      //      Http.HttpResult result = request.send_request(reqarm, Http.api_files.assign_rfid_to_roll);
      //      if (result.getresultFlag())
      //      {
      //          //if (Stock_IN(RFID))
      //          //{
      //          //    return true;
      //          //}
      //          return false;
      //      }
      //      else
      //      {
      //          if (result.geterrorCode() == "server001")
      //          {
      //              ShowError("Please check IP or server");
      //          }
      //          else
      //          {
      //              ShowError("Error assigning RFID to Roll");
      //          }
      //          return false;
      //      }
      //  }
        public bool Stock_IN(String RFID,String WEIGHT)
        {
            bool flag = false;
            if (allocate_location(RFID, WEIGHT))
            {
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                reqarm.Add("card_epc", RFID);

                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request(reqarm, Http.api_files.stock_in);
                String errorCode = result.geterrorCode();
                String description = result.geterrorCode();
                if (result.getresultFlag())
                {
                    flag = true;
                }
                else
                {
                    if (result.geterrorCode() == "server001")
                    {
                        ShowError("Please Check IP Or server");
                    }
                    else
                    {
                        ShowError("Error Stocking IN");
                    }
                    flag = false;
                }
            }    
            return flag;                     
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
        public bool assign_rfid(String RFID, String WEIGHT)
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("card_epc", RFID);
            reqarm.Add("flag", "2");
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.insert_assign_tag);
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
                    ShowError("Failed to Assign RFID");
                }
                return false;
            }
        }

    }
}

