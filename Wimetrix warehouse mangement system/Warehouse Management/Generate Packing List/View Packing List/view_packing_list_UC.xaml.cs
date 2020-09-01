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
using Wimetrix_warehouse_mangement_system.Warehouse_Management.view_Packing_List;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Generate_Packing_List.View_Packing_List
{
    /// <summary>
    /// Interaction logic for view_packing_list_UC.xaml
    /// </summary>
    public partial class view_packing_list_UC : UserControl
    {
        List<String> goods_code_list = new List<String>();
        static ObservableCollection<packing_list_model> packing_list = new ObservableCollection<packing_list_model>();
        public view_packing_list_UC()
        {
            InitializeComponent();
            notification_disptachter();
            populateGoodsCode();
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
        public void populateGoodsCode()
        {
            combo_goods.SelectedIndex = -1;
            goods_code_list.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.get_goods_code);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Goods").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String goods_code = root.GetValue("goods_code").ToString();
                    goods_code_list.Add(goods_code);
                }
                combo_goods.ItemsSource = goods_code_list;
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please check IP or server");
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
                    ShowError("Unexpected Response from Server File");
                }
            }
        }
        public void load_packing_list_for_goods_code(String goods_code)
        {
            grid_packing_list.ItemsSource = null;
            grid_packing_list.Items.Clear();
            packing_list.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("goods_code", goods_code);

            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_packing_list_for_goods_code);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Packing_List"); // parse as array  
                foreach (JObject root in objects)
                {
                    goods_code = root.GetValue("Goods Code").ToString();
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
                    packing_list.Add(new packing_list_model(item_code, Io_no, customer_Code, vendor_name, fabric_type_code, yarn_supplier, yarn_lot_no, fabric_lot_code, color_code, weight, roll_id, gsm, goods_code, igp_date, igp_no, dcn_no, supllier_code,fabric_content));
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
        private void combo_goods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_goods.SelectedIndex > -1)
            {
                load_packing_list_for_goods_code(combo_goods.SelectedItem.ToString());
            }
        
        }
        private void btn_delete_packing_list_Click(object sender, RoutedEventArgs e)
        {
            if (combo_goods.SelectedIndex > -1)
            {
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                reqarm.Add("goods_code", combo_goods.SelectedItem.ToString());
                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request(reqarm, Http.api_files.delete_packing_list);
                if (result.getresultFlag())
                {
                    grid_packing_list.ItemsSource = null;
                    grid_packing_list.Items.Clear();
                    packing_list.Clear();
                    showSuccess("Packing list has been deleted");
                    populateGoodsCode();
                }
                else
                {
                    if (result.geterrorCode() == "server001")
                    {
                        ShowError("Please Check IP Or Server");
                    }
                    else
                    {
                        ShowError("Unable To Delete Packing List");
                    }
                }
            }
            else
            {
                ShowError("Select Packing List");
            }
          
        }
    }
}
