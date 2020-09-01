using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Transfer_Rolls
{
    /// <summary>
    /// Interaction logic for transfer_rolls_UC.xaml
    /// </summary>
    public partial class transfer_rolls_UC : UserControl
    {
        int   total_rolls = 0;
        float total_weight = 0;
        bool  select_all_flag = false;
        List<stocking_model> issuance_grid_list = new List<stocking_model>();
        List<stocking_model> selected_rolls = new List<stocking_model>();
        public transfer_rolls_UC()
        {
            InitializeComponent();
            notification_disptachter();
            populateOrders();
        }
        private DispatcherTimer dispatcherTimer;
        public void notification_disptachter()
        {

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            populateOrders();
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
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_issuance_get_orders_for_fabric_roll_search);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Orders").ToString()); // parse as array  

                foreach (JObject root in objects)
                {
                    String order_number = root.GetValue("Order_Code").ToString();
                    combo_orders.Items.Add(order_number);
               
                }
                getAllOrders();
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
        public void getAllOrders()
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
                    combo_popup_orders.Items.Add(order_number);
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
        private void combo_orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combo_lot.Items.Clear();
            combo_vendors.Items.Clear();
            combo_colors.Items.Clear();
            combo_fabric_type.Items.Clear();

            string selected_order = (sender as ComboBox).SelectedItem as string;
            if (selected_order != null)
            {
                populateFabricLot(selected_order);
                fetch_data_for_selected_filters(selected_order, "", "", "", "");
            }

        }
        public void populateFabricLot(String Order)
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", Order);
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_issuance_get_fabric_lot_for_order);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Fabric Lots").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String Fabric_lot = root.GetValue("Fabric Lot").ToString();
                    combo_lot.Items.Add(Fabric_lot);
                }
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please Check IP Or server");
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
        private void Combo_lot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combo_vendors.Items.Clear();
            combo_colors.Items.Clear();
            combo_fabric_type.Items.Clear();
            string selected_lot = (sender as ComboBox).SelectedItem as string;
            if (selected_lot != null)
            {
                populateVendor(combo_orders.Text.ToString(), selected_lot);
                fetch_data_for_selected_filters(combo_orders.Text.ToString(), selected_lot, "", "", "");
            }
        }
        public void populateVendor(String Order, String FabricLot)
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", Order);
            reqarm.Add("fabric_lot", FabricLot);

            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_issuance_get_vendor_for_order_and_fabric_lot);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Vendor Names").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String vendor_name = root.GetValue("Vendor Name").ToString();
                    combo_vendors.Items.Add(vendor_name);
                }
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please Check IP Or server");
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
        private void Combo_vendors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combo_colors.Items.Clear();
            combo_fabric_type.Items.Clear();
            string selected_vendor = (sender as ComboBox).SelectedItem as string;
            if (selected_vendor != null)
            {
                populateColors(combo_orders.Text.ToString(), combo_lot.Text.ToString(), selected_vendor);
                fetch_data_for_selected_filters(combo_orders.Text.ToString(), combo_lot.Text.ToString(), selected_vendor, "", "");
            }
        }
        public void populateColors(String Order, String FabricLot, String Vendor)
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", Order);
            reqarm.Add("fabric_lot", FabricLot);
            reqarm.Add("vendor", Vendor);

            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_issuance_get_color_for_order_and_fabric_lot_and_vendor);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("COLORS").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String color = root.GetValue("Color").ToString();
                    combo_colors.Items.Add(color);
                }
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please Check IP Or server");
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
        private void Combo_colors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combo_fabric_type.Items.Clear();
            string selected_color = (sender as ComboBox).SelectedItem as string;
            if (selected_color != null)
            {
                populateFabricTypes(combo_orders.Text.ToString(), combo_lot.Text.ToString(), combo_vendors.Text.ToString(), selected_color);
                fetch_data_for_selected_filters(combo_orders.Text.ToString(), combo_lot.Text.ToString(), combo_vendors.Text.ToString(), selected_color, "");
            }
        }
        public void populateFabricTypes(String Order, String FabricLot, String Vendor, String Color)
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", Order);
            reqarm.Add("fabric_lot", FabricLot);
            reqarm.Add("vendor", Vendor);
            reqarm.Add("color", Color);


            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_issuance_get_fabric_type_for_order_and_fabric_lot_and_vendor_and_color);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("FABRIC TYPE").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String fabric_type = root.GetValue("Fabric type").ToString();
                    combo_fabric_type.Items.Add(fabric_type);
                }
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please Check IP Or server");
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
        private void Combo_fabric_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected_fabric_type = (sender as ComboBox).SelectedItem as string;
            if (selected_fabric_type != null)
            {
                //  populateFabricTypes(combo_orders.Text.ToString(), combo_lot.Text.ToString(), combo_vendors.Text.ToString(), selected_color);
                fetch_data_for_selected_filters(combo_orders.Text.ToString(), combo_lot.Text.ToString(), combo_vendors.Text.ToString(), combo_colors.Text.ToString(), selected_fabric_type);

            }

        }
        public void populateDepartments()
        {

        }
        private void btn_update_location_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (stocking_model stock_item in grid_issuance.ItemsSource)
            {
                if (stock_item.Select)
                {
                    count++;
                    float weight = float.Parse(stock_item.Weight);
                    total_weight = total_weight + weight;
                }

            }
            if (count > 0)
            {
                transfer_popup.IsOpen = true;
            }
            else
            {
                ShowError("No Rolls Selected For Transfer");
            }


        }
        public void fetch_data_for_selected_filters(String order, String fabric_lot, String vendor, String color, String fabric_type)
        {
            grid_issuance.ItemsSource = null;
            grid_issuance.Items.Clear();
            issuance_grid_list.Clear();

            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", order);
            reqarm.Add("fabric_lot", fabric_lot);
            reqarm.Add("vendor", vendor);
            reqarm.Add("color", color);
            reqarm.Add("fabric_type", fabric_type);
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_issuance_get_rolls_for_order_and_fabric_lot_and_vendor_and_color_and_fabric_type);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("ROLLS").ToString()); // parse as array  
                foreach (JObject root in objects)
                {

                    String Roll = root.GetValue("Roll").ToString();
                    String Weight = root.GetValue("Weight").ToString();
                    String Color = root.GetValue("Color").ToString();
                    String Vendor = root.GetValue("Vendor").ToString();
                    String Fabric_Lot = root.GetValue("Fabric Lot").ToString();
                    String Fabric_Type = root.GetValue("Fabric Type").ToString();
                    String supplier_lot = root.GetValue("supplier_lot").ToString();
                    issuance_grid_list.Add(new stocking_model(false, order, Roll, Color, Weight, Vendor, Fabric_Lot, Fabric_Type, supplier_lot));


                }
                float total_weight = 0;
                foreach (stocking_model stock in issuance_grid_list)
                {
                    total_weight = total_weight + float.Parse(stock.Weight);
                }
                total_weight_text.Content = total_weight.ToString();
                total_rolls_text.Content = issuance_grid_list.Count;

                grid_issuance.ItemsSource = issuance_grid_list;
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
        public void change_order_for_roll()
        {
            int count = 0;
            int upload_count = 0;
            foreach (stocking_model stock_item in grid_issuance.ItemsSource)
            {
                if (stock_item.Select)
                {
                    var reqarm = new System.Collections.Specialized.NameValueCollection();
                    reqarm.Add("roll_id", stock_item.Roll_ID);
                    reqarm.Add("new_order_id",combo_popup_orders.Text.ToString() );;
                    Http.http_request request = new Http.http_request();
                    Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.change_order_of_roll);
                    count++;
                    if (result.getresultFlag())
                    {
                        upload_count++;
                    }

                }

            }
            transfer_popup.IsOpen = false;
            if (upload_count == count)
            {
                showSuccess("Order of selected rolls have been changed");
                grid_issuance.ItemsSource = null;
                grid_issuance.Items.Clear();
                issuance_grid_list.Clear();
                combo_orders.Items.Clear();
                combo_lot.Items.Clear();
                combo_fabric_type.Items.Clear();
                combo_vendors.Items.Clear();
                combo_colors.Items.Clear();
                populateOrders();
                total_weight = 0;
                total_weight_text.Content = total_weight.ToString();
                total_rolls_text.Content = issuance_grid_list.Count;


            }
            else
            {
                ShowError("Failed To change order of selected rolls");
            }


        }
        private void columnHeader_Click(object sender, RoutedEventArgs e)
        {
            var columnHeader = sender as DataGridColumnHeader;
            if (columnHeader != null)
            {

                if (columnHeader.Content.ToString() == "Select All")
                {
                    if (!select_all_flag)
                    {
                        grid_issuance.ItemsSource = null;
                        grid_issuance.Items.Clear();
                        foreach (stocking_model stock_item in issuance_grid_list)
                        {
                            stock_item.Select = true;
                        }
                        select_all_flag = true;
                        grid_issuance.ItemsSource = issuance_grid_list;
                    }
                    else
                    {
                        grid_issuance.ItemsSource = null;
                        grid_issuance.Items.Clear();
                        foreach (stocking_model stock_item in issuance_grid_list)
                        {
                            stock_item.Select = false;
                        }
                        select_all_flag = false;
                        grid_issuance.ItemsSource = issuance_grid_list;
                    }
                }



            }

        }
        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            transfer_popup.IsOpen = false;
        }
        private void btn_popup_transfer_Click(object sender, RoutedEventArgs e)
        {
            if (combo_popup_orders.Text != "")
            {
                change_order_for_roll();
            }
            else
            {
                ShowError("Order not provided");
            }
        }
        private void btn_transfer_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            total_weight = 0;
            foreach (stocking_model stock_item in grid_issuance.ItemsSource)
            {
                if (stock_item.Select)
                {
                    count++;
                    float weight = float.Parse(stock_item.Weight);
                    total_weight = total_weight + weight;                 
                }

            }
            if (count > 0)
            {
                text_poppup_total_rolls.Content = count.ToString();
                text_poppup_total_weight.Content = total_weight.ToString();
                transfer_popup.IsOpen = true;
            }
            else
            {
                ShowError("No Rolls Selected For Transfer");
            }
        }       

    }
}