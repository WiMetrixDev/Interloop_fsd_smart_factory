using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking;
using Wimetrix_warehouse_mangement_system.Warehouse_Management.Upload_Excel;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Generate_Packing_List.Add_Packing_List
{
    /// <summary>
    /// Interaction logic for add_packing_list_UC.xaml
    /// </summary>
    public partial class add_packing_list_UC : UserControl
    {
        private static readonly Regex _regex = new Regex("[^0-9]+");
        List<String> order_list = new List<String>();
        List<String> customer_list = new List<String>();
        List<String> vendor_list = new List<String>();
        List<String> fabric_lot_list = new List<String>();
        List<String> color_list = new List<String>();
        List<upload_excel_model> rolls_list = new List<upload_excel_model>();
        List<upload_excel_model> final_packing_list = new List<upload_excel_model>();
        static List<uploaded_excel_model> uploading_status_list = new List<uploaded_excel_model>();
        int upload_count = 0;

        public add_packing_list_UC()
        {
            InitializeComponent();
            notification_disptachter();
            populateOrders();
            populateCustomers();
            populateVendors();
            populateFabricTypes();
            populateColors();
            populateFabricContent();
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
        public void populateOrders()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.get_orders_for_generate_packing_list);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Orders").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String order_number = root.GetValue("Order_Code").ToString();
                    combo_order.Items.Add(order_number);
                }
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
        public void populateCustomers()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.get_customers_for_generate_packing_list);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Customers").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String customer_code = root.GetValue("customer_code").ToString();
                    combo_customer.Items.Add(customer_code);
                }
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
        public void populateVendors()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.get_vendors_for_generate_packing_list);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Supplier").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String supplier_code = root.GetValue("supplier_code").ToString();
                    combo_supplier.Items.Add(supplier_code);
                }
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
        public void populateFabricTypes()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.get_fabric_type_for_generate_packing_list);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Fabric_types").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String fabric_type_code = root.GetValue("fabric_type_code").ToString();
                    combo_fabric_type.Items.Add(fabric_type_code);
                }
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
        public void populateColors()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.get_colors_for_generate_packing_list);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Colors").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String fabric_color_code = root.GetValue("fabric_color_code").ToString();
                    combo_color.Items.Add(fabric_color_code);
                }
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
 
        public void populateFabricContent()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.get_fabric_content);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Fabric_content").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String fabric_content = root.GetValue("fabric_content").ToString();
                    combo_fabric_content.Items.Add(fabric_content);
                }
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


        private void btn_generate_rolls_Click(object sender, RoutedEventArgs e)
        {
            if(combo_order.Text !="" && combo_customer.Text != "" && combo_supplier.Text != "" && combo_fabric_type.Text != "" && combo_color.Text != "")
            {
                if(text_DCN.Text!="" && text_fabric_lot.Text!="" && text_supplier_lot.Text != "" && text_no_rolls.Text != "")
                {
                    generate_rolls();
                }
                else
                {
                    ShowError("Provide DCN, Fabric Lot code, Supplier Lot and Number of Rolls");
                }
            }
            else
            {
                ShowError("Select Order, Customer, Vendor, Fabric Type and Color first");
            }
        }
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsTextAllowed(text_no_rolls.Text))
            {

            }
            else
            {
                ShowError("Invalid number of rolls");
                text_no_rolls.Text = "";
            }
        }
        public  void generate_rolls()
        {
            grid_generate_packing_list_rolls.ItemsSource = null;
            rolls_list.Clear();
            int rolls = Int32.Parse(text_no_rolls.Text);
            for(int i = 0; i < rolls; i++)
            {
                var ERP_Item_Code = "";
                var ERP_Item_Description = "";
                var IGP_Date = "";
                var IGP_No = "";
                var Internal_Order_No = combo_order.Text.ToString();
                var Customer_Name = combo_customer.Text.ToString();
                var Customer_code = "";
                var DCN_No = text_DCN.Text.ToString();
                var Vendor_Name = combo_supplier.Text.ToString();
                var Fabric_Type = combo_fabric_type.Text.ToString();
                var Yarn_Supplier = "";
                var Yarn_Lot_No = "";
                var Fabric_Lot_No = text_fabric_lot.Text.ToString();
                var Color_Code = combo_color.Text.ToString();
                var Fabric_width = text_width.Text.ToString();
                var Weight = "0";
                var Pcs = "";
                var Roll_Identification = "";
                var Transaction_Type = "";
                var Roll_ID = (i + 1).ToString();
                var Fabric_length = "";
                var goods_code = "";
                var supplier_lot = text_supplier_lot.Text.ToString();
                var fabric_GSM = text_fabric_GSM.Text.ToString();
                var fabric_content = combo_fabric_content.Text.ToString();
                rolls_list.Add(new upload_excel_model(ERP_Item_Code.ToString(),
                         ERP_Item_Description.ToString(),
                         IGP_Date,
                         IGP_No.ToString(),
                         Internal_Order_No.ToString(),
                         Customer_Name.ToString(),
                         Customer_code.ToString(),
                         DCN_No.ToString(),
                         Vendor_Name.ToString(),
                         Fabric_Type.ToString(),
                         Yarn_Supplier.ToString(),
                         Yarn_Lot_No.ToString(),
                         Fabric_Lot_No.ToString(),
                         Color_Code.ToString(),
                         fabric_GSM.ToString(),
                         Fabric_width.ToString(),
                         Weight.ToString(),
                         Pcs.ToString(),
                         Roll_Identification.ToString(),
                         Transaction_Type.ToString(),
                         Roll_ID.ToString(),
                         Fabric_length.ToString(),
                         goods_code.ToString(),
                        supplier_lot.ToString(),
                        fabric_content.ToString()

                        )); ;
            }
            grid_generate_packing_list_rolls.ItemsSource = rolls_list;
            int total_rolls = 0;
            float total_weight = 0;
            foreach (upload_excel_model stock_item in rolls_list)
            {
                float weight = float.Parse(stock_item.weight);
                total_weight = total_weight + weight;
                total_rolls++;
            }
            generate_roll_total_rolls_text.Content = total_rolls;
            generate_roll_total_weight_text.Content = total_weight;
            showSuccess("Rolls Generated, provide weight for all the rolls");
        }
        public void add_to_packing_list()
        {
          foreach(upload_excel_model roll_item in grid_generate_packing_list_rolls.ItemsSource)
            {
                final_packing_list.Add((upload_excel_model)roll_item);
            }
            grid_generate_packing_list_rolls.ItemsSource = null;
            rolls_list.Clear();
            showSuccess("Rolls added to packing list");
        }
        public void show_final_packing_list()
        {
            grid_final_packing_list.ItemsSource = null;
            int total_rolls = 0;
            float total_weight = 0;
            foreach (upload_excel_model stock_item in final_packing_list){
                float weight = float.Parse(stock_item.weight);
                total_weight = total_weight + weight;
                total_rolls++;
            }
            total_rolls_text.Content = total_rolls;
            total_weight_text.Content = total_weight;
            grid_final_packing_list.ItemsSource = final_packing_list;
            popup_view_final_packing_list.IsOpen = true;
        }
        private void grid_generate_packing_list_rolls_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid datagrid = sender as DataGrid;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (e.Column is DataGridBoundColumn)
                {
                    DataGridBoundColumn column = (DataGridBoundColumn)e.Column;
                    if (column.Header.ToString() == "Weight")
                    {
                        string oldValue = e.Row.DataContext.GetType().GetProperty("weight")
                                           .GetValue(e.Row.DataContext).ToString();
                        TextBox element = e.EditingElement as TextBox;
                        string newValue = element.Text;
                        int total_rolls = 0;
                        float total_weight = 0;
                        foreach (upload_excel_model roll_item in grid_generate_packing_list_rolls.ItemsSource)
                        {
                            float roll_weight = float.Parse(roll_item.weight);
                            total_weight = total_weight + roll_weight;
                        }
                        float oldSize = float.Parse(oldValue);
                        try
                        {
                            float newSize = float.Parse(newValue);
                            total_weight = total_weight - oldSize + newSize;
                        }
                        catch (Exception ex)
                        {
                            element.Text = oldValue;
                            e.Cancel = true;
                        }
                        generate_roll_total_weight_text.Content = Math.Round(total_weight, 2);

                    }
                }
            }
        }
        private void btn_add_to_packing_list_Click(object sender, RoutedEventArgs e)
        {
            if (combo_order.Text != "" && combo_customer.Text != "" && combo_supplier.Text != "" && combo_fabric_type.Text != "" && combo_color.Text != "" && combo_fabric_content.Text != "")
            {
                if (text_DCN.Text != "" && text_fabric_lot.Text != "" && text_supplier_lot.Text != "" && text_no_rolls.Text != "" && text_fabric_GSM.Text != "" && text_width.Text != "")
                {
                    if (rolls_list.Count > 0)
                    {
                        add_to_packing_list();
                    }
                    else
                    {
                        ShowError("No rolls generated yet");
                    }
                }
                else
                {
                    ShowError("Provide DCN, GSM, Fabric Width, Fabric Lot code and Number of Rolls");
                }
            }
            else
            {
                ShowError("Select Order, Customer, Vendor, Fabric Type, Fabric Content and Color first");
            }
        }
        private void btn_upload_packing_list_Click(object sender, RoutedEventArgs e)
        {
            if (combo_order.Text != "" && combo_customer.Text != "" && combo_supplier.Text != "" && combo_fabric_type.Text != "" && combo_color.Text != "") { 
                if (text_DCN.Text != "" && text_fabric_lot.Text != "" && text_no_rolls.Text != "")
                {
                        if (final_packing_list.Count > 0)
                        {
                            show_final_packing_list();
                        }
                        else
                        {
                            ShowError("No rolls added to packing list");
                        }
                }
                else
                {
                    ShowError("Provide DCN, Fabric Lot code and Number of Rolls");
                }
            }
            else
            {
                ShowError("Select Order, Customer, Vendor, Fabric Type and Color first");
            }
        }
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            grid_final_packing_list.ItemsSource = null;
            popup_view_final_packing_list.IsOpen = false;
        }
        private void grid_final_packing_list_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid datagrid = sender as DataGrid;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (e.Column is DataGridBoundColumn)
                {
                    DataGridBoundColumn column = (DataGridBoundColumn)e.Column;
                    string oldValue;
                    TextBox element;
                    string newValue;

                    var order_number = "";
                    var customer_name="";
                    var vendor_name = "";
                    var fabric_type = "";
                    var color_code = "";
                    var dcn_no = "";
                    var fabric_lot_no = "";
                    var fabric_content = "";
                    oldValue = e.Row.DataContext.GetType().GetProperty("order_no")
                             .GetValue(e.Row.DataContext).ToString();
                    order_number = e.Row.DataContext.GetType().GetProperty("order_no")
                         .GetValue(e.Row.DataContext).ToString();
                    customer_name = e.Row.DataContext.GetType().GetProperty("customer_name")
                             .GetValue(e.Row.DataContext).ToString();
                    vendor_name = e.Row.DataContext.GetType().GetProperty("vendor_name")
                           .GetValue(e.Row.DataContext).ToString();
                    fabric_type = e.Row.DataContext.GetType().GetProperty("fabric_type")
                           .GetValue(e.Row.DataContext).ToString();
                    color_code = e.Row.DataContext.GetType().GetProperty("color_code")
                           .GetValue(e.Row.DataContext).ToString();
                    dcn_no = e.Row.DataContext.GetType().GetProperty("dcn_no")
                           .GetValue(e.Row.DataContext).ToString();
                    fabric_lot_no = e.Row.DataContext.GetType().GetProperty("fabric_lot_no")
                         .GetValue(e.Row.DataContext).ToString();
                    fabric_content = e.Row.DataContext.GetType().GetProperty("fabric_content")
                     .GetValue(e.Row.DataContext).ToString();
                    switch (column.Header.ToString()){                
                        case "Weight":
                             oldValue = e.Row.DataContext.GetType().GetProperty("weight")
                                           .GetValue(e.Row.DataContext).ToString();
                             element = e.EditingElement as TextBox;
                             newValue = element.Text;
                             int total_rolls = 0;
                            float total_weight = float.Parse(total_weight_text.Content.ToString());
                            float oldSize = float.Parse(oldValue);
                            try
                            {
                                float newSize = float.Parse(newValue);
                                total_weight = total_weight - oldSize + newSize;
                            }
                            catch (Exception ex)
                            {
                                element.Text = oldValue;
                                e.Cancel = true;
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                           
                
      
                           
                            total_rolls_text.Content = total_rolls;
                            total_weight_text.Content = Math.Round(total_weight, 2);
                            break;
                        case "Order":
                     
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                               if(roll_item.order_no == oldValue && roll_item.customer_name == customer_name && roll_item.vendor_name == vendor_name
                                    && roll_item.fabric_type == fabric_type && roll_item.color_code == color_code && roll_item.dcn_no == dcn_no &&
                                    roll_item.fabric_lot_no==fabric_lot_no && roll_item.fabric_content == fabric_content)
                                {
                                    roll_item.order_no = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;                           
                            break;
 
                        case "Customer":
                            oldValue = e.Row.DataContext.GetType().GetProperty("customer_name")
                            .GetValue(e.Row.DataContext).ToString();
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                                if (roll_item.customer_name == oldValue  && roll_item.order_no == order_number  && roll_item.vendor_name == vendor_name
                                    && roll_item.fabric_type == fabric_type && roll_item.color_code == color_code && roll_item.dcn_no == dcn_no &&
                                    roll_item.fabric_lot_no == fabric_lot_no && roll_item.fabric_content == fabric_content)
                                {
                                    roll_item.customer_name = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                            break;
                        case "Vendor":
                            oldValue = e.Row.DataContext.GetType().GetProperty("vendor_name")
                            .GetValue(e.Row.DataContext).ToString();
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                                if (roll_item.vendor_name == oldValue && roll_item.order_no == order_number && roll_item.customer_name == customer_name
                                    && roll_item.fabric_type == fabric_type && roll_item.color_code == color_code && roll_item.dcn_no == dcn_no &&
                                    roll_item.fabric_lot_no == fabric_lot_no && roll_item.fabric_content == fabric_content)
                                {
                                    roll_item.vendor_name = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                  
                            break;
                        case "Fabric Type":
                            oldValue = e.Row.DataContext.GetType().GetProperty("fabric_type")
                            .GetValue(e.Row.DataContext).ToString();
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                                if (roll_item.fabric_type == oldValue && roll_item.order_no == order_number && roll_item.vendor_name == vendor_name
                                    && roll_item.customer_name == customer_name && roll_item.color_code == color_code && roll_item.dcn_no == dcn_no &&
                                    roll_item.fabric_lot_no == fabric_lot_no && roll_item.fabric_content == fabric_content)
                                {
                                    roll_item.fabric_type = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                            break;
                        case "Color":
                            oldValue = e.Row.DataContext.GetType().GetProperty("color_code")
                 .GetValue(e.Row.DataContext).ToString();
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                                if (roll_item.color_code == oldValue && roll_item.order_no == order_number && roll_item.vendor_name == vendor_name
                                    && roll_item.customer_name == customer_name && roll_item.fabric_type == fabric_type && roll_item.dcn_no == dcn_no &&
                                    roll_item.fabric_lot_no == fabric_lot_no && roll_item.fabric_content == fabric_content)
                                {
                                    roll_item.color_code = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                            break;
                        case "DCN":
                            oldValue = e.Row.DataContext.GetType().GetProperty("dcn_no")
                            .GetValue(e.Row.DataContext).ToString();
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                                if (roll_item.dcn_no == oldValue && roll_item.order_no == order_number && roll_item.vendor_name == vendor_name
                                    && roll_item.customer_name == customer_name && roll_item.fabric_type == fabric_type && roll_item.color_code == color_code &&
                                    roll_item.fabric_lot_no == fabric_lot_no && roll_item.fabric_content == fabric_content)
                                {
                                    roll_item.dcn_no = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                            break;
                        case "Fabric Lot":
                            oldValue = e.Row.DataContext.GetType().GetProperty("fabric_lot_no")
                   .GetValue(e.Row.DataContext).ToString();
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                                if (roll_item.fabric_lot_no == oldValue && roll_item.order_no == order_number && roll_item.vendor_name == vendor_name
                                    && roll_item.customer_name == customer_name && roll_item.fabric_type == fabric_type && roll_item.dcn_no == dcn_no &&
                                    roll_item.color_code == color_code && roll_item.fabric_content == fabric_content)
                                {
                                    roll_item.fabric_lot_no = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                            break;
                        case "Supplier Lot":
                            oldValue = e.Row.DataContext.GetType().GetProperty("supplier_lot")
                   .GetValue(e.Row.DataContext).ToString();
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                                if (roll_item.supplier_lot == oldValue && roll_item.order_no == order_number && roll_item.vendor_name == vendor_name
                                    && roll_item.customer_name == customer_name && roll_item.fabric_type == fabric_type && roll_item.dcn_no == dcn_no 
                                    && roll_item.color_code == color_code && roll_item.fabric_lot_no == fabric_lot_no && roll_item.fabric_content == fabric_content)
                                {
                                    roll_item.supplier_lot = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                            break;
                        case "Fabric Content":
                            oldValue = e.Row.DataContext.GetType().GetProperty("fabric_content").GetValue(e.Row.DataContext).ToString();
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                                if (roll_item.fabric_content == oldValue && roll_item.order_no == order_number && roll_item.customer_name == customer_name && roll_item.vendor_name == vendor_name
                                     && roll_item.fabric_type == fabric_type && roll_item.color_code == color_code && roll_item.dcn_no == dcn_no &&
                                     roll_item.fabric_lot_no == fabric_lot_no )
                                {
                                    roll_item.fabric_content = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                            break;
                        case "Fabric GSM":
                            oldValue = e.Row.DataContext.GetType().GetProperty("gsm").GetValue(e.Row.DataContext).ToString();
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                                if (roll_item.gsm == oldValue && roll_item.order_no == order_number && roll_item.customer_name == customer_name && roll_item.vendor_name == vendor_name
                                     && roll_item.fabric_type == fabric_type && roll_item.color_code == color_code && roll_item.dcn_no == dcn_no &&
                                     roll_item.fabric_lot_no == fabric_lot_no && roll_item.fabric_content == fabric_content)
                                {
                                    roll_item.gsm = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                            break;
                        case "Fabric Width":
                            oldValue = e.Row.DataContext.GetType().GetProperty("fabric_width").GetValue(e.Row.DataContext).ToString();
                            element = e.EditingElement as TextBox;
                            newValue = element.Text;
                            grid_final_packing_list.ItemsSource = null;
                            foreach (upload_excel_model roll_item in final_packing_list)
                            {
                                if (roll_item.fabric_width == oldValue && roll_item.order_no == order_number && roll_item.customer_name == customer_name && roll_item.vendor_name == vendor_name
                                     && roll_item.fabric_type == fabric_type && roll_item.color_code == color_code && roll_item.dcn_no == dcn_no &&
                                     roll_item.fabric_lot_no == fabric_lot_no && roll_item.fabric_content == fabric_content)
                                {
                                    roll_item.fabric_width = newValue;
                                }
                            }
                            grid_final_packing_list.ItemsSource = final_packing_list;
                            break;


                    }
                }
            }
        }
        private void btn_popup_upload_Click(object sender, RoutedEventArgs e)
        {
            popup_view_final_packing_list.IsOpen = false;
            if (final_packing_list.Count > 0)
            {
                var packing_json = JsonConvert.SerializeObject(final_packing_list);
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                int flag_force_upload = 0;
                if (check_force_upload.IsChecked == true)
                {
                    flag_force_upload = 1;
                }
                reqarm.Add("packing_list", packing_json);
                reqarm.Add("flag", flag_force_upload.ToString());
                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.upload_excel_file);
                if (result.getresultFlag())
                {
                    int failed_count = 0;
                    int success_count = 0;
                    JObject json = result.getjsonResult();
                    var objects = JArray.Parse(json.GetValue("Responses").ToString()); // parse as array  
                    foreach (JObject root in objects)
                    {

                        String Internal_Order_No = root.GetValue("Order").ToString();
                        String Weight = root.GetValue("Weight").ToString();
                        String Fabric_Lot_No = root.GetValue("Fabric Lot").ToString();
                        String packing_list_code = root.GetValue("packing_list_code").ToString();
                        String status = root.GetValue("Error_Description").ToString();
                        String error_code = root.GetValue("Error_No").ToString();
                        if (error_code == "0")
                        {
                            uploaded_excel_model model = new uploaded_excel_model(Internal_Order_No, Weight, Fabric_Lot_No, packing_list_code, "Successfully uploaded");
                            Console.WriteLine(model);
                            uploading_status_list.Add(model);
                            success_count++;

                        }
                        else
                        {
                            uploaded_excel_model model = new uploaded_excel_model(Internal_Order_No, Weight, Fabric_Lot_No, packing_list_code, "Failed");
                            Console.WriteLine(model);
                            uploading_status_list.Add(model);
                            failed_count++;

                        }

                    }
                    grid_final_packing_list.ItemsSource = null;
                    final_packing_list.Clear();
                    grid_excel_upload_status_list.ItemsSource = uploading_status_list;
                    popup_status.IsOpen = true;
                    uploaded_total_rolls_text.Content=success_count.ToString();
                    failed_total_rolls_text.Content = failed_count.ToString();

                }
                else
                {
                    if (result.geterrorCode() == "server001")
                    {
                        ShowError("Please Check IP Or Server");
                    }
                    else
                    {
                        if (result.geterrorCode() == "API-Duplicate")
                        {
                            ShowError("Duplicate packing list");
                            grid_final_packing_list.ItemsSource = null;
                  
                        }
                        else
                        {
                            ShowError(result.getDescription());
                        }
                    }
                }

            }
            else
            {
                ShowError("Packing list is empty");
            }
        }
        private void btn_status_popup_ok_Click(object sender, RoutedEventArgs e)
        {
            popup_status.IsOpen = false;
            grid_excel_upload_status_list.ItemsSource = null;
            grid_excel_upload_status_list.Items.Clear();
            uploading_status_list.Clear();
        }
    }
}
