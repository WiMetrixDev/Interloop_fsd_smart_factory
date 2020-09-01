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

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.view_Packing_List
{
    /// <summary>
    /// Interaction logic for view_packinglist_UC.xaml
    /// </summary>
    public partial class view_packinglist_UC : UserControl
    {
        static ObservableCollection<packing_list_model> packing_list = new ObservableCollection<packing_list_model>();
        public view_packinglist_UC()
        {
            InitializeComponent();
            notification_disptachter();
            load_upload_dates();
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

        public void load_upload_dates()
        {        
                combo_date.Items.Clear();
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_dates);
                if (result.getresultFlag())
                {
                    JObject json = result.getjsonResult();
                    var objects = JArray.Parse(json.GetValue("Dates").ToString()); // parse as array  
                    foreach (JObject root in objects)
                    {
                        String Date = root.GetValue("Date").ToString();
                        combo_date.Items.Add(Date);
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
                        ShowError("Unable to fetch dates");
                    }
            }          
        }
        public void load_dcn_for_dates(String date)
        {
            combo_dcn.Items.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("date", date);
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_dcn_for_dates);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("DCN").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String DCN = root.GetValue("dcn_no").ToString();
                    combo_dcn.Items.Add(DCN);
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
                    ShowError("Unable to fetch DCN for date");
                }
            }
        }
        public void load_orders_date_dcn(String date,String dcn)
        {
            combo_orders.Items.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("date", date);
            reqarm.Add("dcn_no", dcn);
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_orders_for_dcn_date);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Orders").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String order_number = root.GetValue("order_code").ToString();
                    combo_orders.Items.Add(order_number);
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
                    ShowError("Unable to load orders for date and dcn");
                }
            }

        }
   
        public void load_packing_list_for_order(String date,String dcn,String order)
        {
            grid_packing_list.ItemsSource = null;
            grid_packing_list.Items.Clear();
            packing_list.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", order);
            reqarm.Add("date", date);
            reqarm.Add("DCN", dcn);

            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_packing_list_for_order);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Packing_List"); // parse as array  
                foreach (JObject root in objects)
                {
                    String goods_code = root.GetValue("Goods Code").ToString();
                    String Io_no = root.GetValue("Io No").ToString();
                    String fabric_lot_code = root.GetValue("Fabric Lot Code").ToString();
                    String fabric_type_code = root.GetValue("Fabric Type Code").ToString();
                    String vendor_name = root.GetValue("Vendor Name").ToString();
                    String customer_Code = root.GetValue("Customer Code").ToString();
                    String color_code = root.GetValue("Color Code").ToString();
                    String dcn_no = root.GetValue("DCN Code").ToString();
                    String weight = root.GetValue("Weight").ToString();
                    String gsm = root.GetValue("GSM").ToString();
                    String yarn_lot_no = root.GetValue("Yarn Lot No").ToString();
                    String yarn_supplier = root.GetValue("Yarn Supplier").ToString();
                    String igp_date = root.GetValue("IGP Date").ToString();
                    String igp_no = root.GetValue("IGP NO").ToString();
                    String roll_id = root.GetValue("Roll ID").ToString();
                    String item_code = root.GetValue("Item Code").ToString();
                    String supllier_code = root.GetValue("Suplier Code").ToString();
                    String fabric_content = root.GetValue("Fabric Content").ToString();
                    packing_list.Add(new packing_list_model(item_code, Io_no, customer_Code, vendor_name, fabric_type_code, yarn_supplier, yarn_lot_no, fabric_lot_code, color_code, weight, roll_id, gsm, goods_code, igp_date,igp_no, dcn_no,supllier_code,fabric_content));
                }
                grid_packing_list.ItemsSource = packing_list;
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please Check IP Or Server");
                }
                else
                {
                    ShowError("Unable To Fetch Packing List Data");
                }
            }
        }    
        private void Btn_view_Packing_Click(object sender, RoutedEventArgs e)
        {
            if(combo_orders.Text.ToString()!="" && combo_date.Text.ToString() != "")
            {
              //  load_packing_list_for_order(combo_orders.Text.ToString(), combo_date.Text.ToString());
            }
        }
        private void Combo_date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_date.SelectedIndex > -1)
            {
                load_dcn_for_dates(combo_date.SelectedValue.ToString());
                load_packing_list_for_order(combo_date.SelectedValue.ToString(), "", "");

            }
        }

        private void Combo_dcn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_date.SelectedIndex > -1 && combo_dcn.SelectedIndex>-1)
            {
                load_orders_date_dcn(combo_date.SelectedValue.ToString(),combo_dcn.SelectedValue.ToString());
                load_packing_list_for_order(combo_date.SelectedValue.ToString(), combo_dcn.SelectedValue.ToString() , "");
            }
        }

        private void Combo_orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_date.SelectedIndex > -1 && combo_dcn.SelectedIndex > -1 && combo_orders.SelectedIndex>-1)
            {
                load_packing_list_for_order(combo_date.SelectedValue.ToString(), combo_dcn.SelectedValue.ToString(), combo_orders.SelectedValue.ToString());
            }
        }
    }
}
