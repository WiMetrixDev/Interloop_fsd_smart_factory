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
using Wimetrix_warehouse_mangement_system.Asset_Tracking.Asset_Allocation;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal.View_Assets
{
    /// <summary>
    /// Interaction logic for view_assets_UC.xaml
    /// </summary>
    public partial class view_assets_UC : UserControl
    {
        static ObservableCollection<admin_view_asset_model> asset_list = new ObservableCollection<admin_view_asset_model>();
        static ObservableCollection<admin_view_asset_model> All_Asset_list = new ObservableCollection<admin_view_asset_model>();
        // static List<admin_view_asset_model> asset_list = new List<admin_view_asset_model>();
        public view_assets_UC()
        {
            InitializeComponent();
            notification_disptachter();
            fetch_machine_details();
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
        private void Btn_load_machines_Click(object sender, RoutedEventArgs e)
        {
   
        }
        public void fetch_machine_details()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.Asset_get_goods_complete_data);
            if (result.getresultFlag())
            {
                grid_update_location.ItemsSource = null;
                grid_update_location.Items.Clear();
                asset_list.Clear();
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
                            asset_list.Add(new admin_view_asset_model(good_id, Machine, Machine_Type, Floor_code, price, Machine_number, Country,Machine_sub_type,Model_code,Vendor_code,Supplier_code,Brand_code, module_code,igp_date,manufacturing_year,installation_date,Line));
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                }
                grid_update_location.ItemsSource = asset_list;
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
        private void Text_operation_KeyUp(object sender, KeyEventArgs e)
        {

           
        }
        private void Grid_issuance_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            DataGrid datagrid = sender as DataGrid;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (e.Column is DataGridBoundColumn)
                {
                    DataGridBoundColumn column = (DataGridBoundColumn)e.Column;
                    if (column.Header.ToString() == "Price")
                    {
                        string oldValue = e.Row.DataContext.GetType().GetProperty("Price")
                                           .GetValue(e.Row.DataContext).ToString();
                        TextBox element = e.EditingElement as TextBox;
                        string newValue = element.Text;

                        int oldSize = int.Parse(oldValue);
                        try
                        {
                            int newSize = int.Parse(newValue);
     
                        }
                        catch (Exception ex)
                        {
                            element.Text = oldValue;
                            e.Cancel = true;
                        }

                    }
                }
            }
        }
        private void text_operation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void text_rfid_search_KeyUp(object sender, KeyEventArgs e)
        {

            grid_update_location.ItemsSource = null;
            grid_update_location.Items.Clear();
            All_Asset_list.Clear();
            var filtered = asset_list.Where(asset_allocation_model => asset_allocation_model.RFID.StartsWith(text_rfid_search.Text.ToString()));
            foreach (admin_view_asset_model stock_item in filtered)
            {
                All_Asset_list.Add(stock_item);
            }
            grid_update_location.ItemsSource = All_Asset_list;
        }
        private void btn_update_price_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int upload_count = 0;
            foreach (admin_view_asset_model stock_item in grid_update_location.ItemsSource)
            {
                if (stock_item.Select)
                {
                    var reqarm = new System.Collections.Specialized.NameValueCollection();
                    reqarm.Add("goods_id", stock_item.Good_id);
                    reqarm.Add("price", stock_item.Price);
                    Http.http_request request = new Http.http_request();
                    Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.update_price);
                    count++;
                    if (result.getresultFlag())
                    {
                        upload_count++;
                    }
                }
            }
            if (upload_count == count)
            {
                showSuccess("Price updated");
                fetch_machine_details();
            }
            else
            {
                showSuccess("Unable to update prices for some machines");
            }

        }
        private void btn_update_machine_lines_Click(object sender, RoutedEventArgs e)
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.auto_update_machine_locations);
 
            if (result.getresultFlag())
            {
                fetch_machine_details();
            }
            else
            {
                ShowError("Unable to refresh machine locations");
            }
        }
    }
}
