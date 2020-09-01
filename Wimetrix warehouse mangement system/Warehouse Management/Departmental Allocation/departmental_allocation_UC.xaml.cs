using Newtonsoft.Json.Linq;
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
using Wimetrix_warehouse_mangement_system.Warehouse_Management.Update_location;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Departmental_Allocation
{
    /// <summary>
    /// Interaction logic for departmental_allocation_UC.xaml
    /// </summary>
    public partial class departmental_allocation_UC : UserControl
    {

        int total_rolls = 0;
        float total_weight = 0;
        bool select_all_flag = false;

        List<stocking_model> issuance_grid_list = new List<stocking_model>();
        List<stocking_model> issuance_grid_list_original = new List<stocking_model>();
        List<stocking_model> child_rolls_issuance_list = new List<stocking_model>();
        public departmental_allocation_UC()
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
            combo_popup_issuance.Items.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_issuance_get_departments);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = JArray.Parse(json.GetValue("Departments").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String dept_id = root.GetValue("Dept Id").ToString();
                    String dept_name = root.GetValue("Dept Name").ToString();

                    combo_popup_issuance.Items.Add(dept_id + " - " + dept_name);
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

                issuance_popup.IsOpen = false;
            }
        }
        private void btn_update_location_Click(object sender, RoutedEventArgs e)
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
                text_poppup_total_rolls.Content = count;
                text_poppup_total_weight.Content = total_weight;
                populateDepartments();
                issuance_popup.IsOpen = true;
            }
            else
            {
                ShowError("No Rolls Selected For Department Allocation");
            }


        }
        private void btn_set_Click(object sender, RoutedEventArgs e)
        {
            if (combo_popup_issuance.Text != "")
            {
                allocate_departement();
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
                    issuance_grid_list_original.Add(new stocking_model(false, order, Roll, Color, Weight, Vendor, Fabric_Lot, Fabric_Type, supplier_lot));

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
        public void allocate_departement()
        {
            String[] department = combo_popup_issuance.Text.ToString().Split('-');
            int count = 0;
            int upload_count = 0;

            foreach (stocking_model stock_item in grid_issuance.ItemsSource)
            {
                if (stock_item.Select)
                {
                    //string child_roll_id = "";
                    //foreach (stocking_model child_item in child_rolls_issuance_list)
                    //{
                  
                    //    if (child_item.Roll_ID.Equals(stock_item.Roll_ID))
                    //    {
                    //        var reqarm1 = new System.Collections.Specialized.NameValueCollection();
                    //        reqarm1.Add("roll_id", stock_item.Roll_ID);
                    //        reqarm1.Add("location_id", department[0]);
                    //        reqarm1.Add("weight", stock_item.Weight);
                    //        Http.http_request request1 = new Http.http_request();
                    //        Http.HttpResult result1 = request1.send_request_for_error_codes_in_return(reqarm1, Http.api_files.for_issuance_create_child_roll);
                    //        if (result1.getresultFlag())
                    //        {
                    //            JObject json = result1.getjsonResult();
                    //            child_roll_id = json.GetValue("child_roll_id").ToString();
                    //            upload_count++;
                    //        }   
                    //        else
                    //        {
                    //            ShowError("Unable to create child roll for :" + stock_item.Roll_ID);
                    //        }

                    //    }
                    //}
                    var reqarm = new System.Collections.Specialized.NameValueCollection();
                    reqarm.Add("roll_id", stock_item.Roll_ID);  
                    reqarm.Add("location_id", department[0]);
                    reqarm.Add("weight", stock_item.Weight);
                    Http.http_request request = new Http.http_request();
                    Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_issuance_create_child_roll);
                    count++;
                    if (result.getresultFlag())
                    {
                        upload_count++;
                    }
                }

            }

            issuance_popup.IsOpen = false;
            if (upload_count == count)
            {
                showSuccess("Department Has Been Allocated To Selected Rolls");
                child_rolls_issuance_list.Clear();
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
                ShowError("Failed To Allocate Department To Selected Rolls");
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
            issuance_popup.IsOpen = false;
        }
        private void btn_allocation_error_set_Click(object sender, RoutedEventArgs e)
        {
            popup_consumption_error.IsOpen = false;
        }
        private void grid_issuance_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid datagrid = sender as DataGrid;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (e.Column is DataGridBoundColumn)
                {
                    DataGridBoundColumn column = (DataGridBoundColumn)e.Column;
                    if (column.Header.ToString() == "Weight")
                    {
                        string oldValue = e.Row.DataContext.GetType().GetProperty("Weight")
                                           .GetValue(e.Row.DataContext).ToString();
                        string Roll = e.Row.DataContext.GetType().GetProperty("Roll_ID")
                                       .GetValue(e.Row.DataContext).ToString();

                        foreach (stocking_model stock_item in issuance_grid_list_original)
                        {
                            if (stock_item.Roll_ID.Equals(Roll))
                            {
                                 oldValue = stock_item.Weight ;
                            }

                        }
                        TextBox element = e.EditingElement as TextBox;
                        string newValue = element.Text;

                        float oldSize = float.Parse(oldValue);
                        try
                        {
                            float newSize = float.Parse(newValue);
                            if (newSize > oldSize && newSize > 0)
                            {
                                string strMsg = "Consumption, " + newValue + ", cannot be greater than original Weight, "
                                              + oldValue + ".\nThis action is not valid.";
                                popup_Error_Message.Text = strMsg;
                                popup_consumption_error.IsOpen = true;
                                element.Text = oldValue;
                                e.Cancel = true;
                            }
                            else
                            {
                                string Roll_ID = e.Row.DataContext.GetType().GetProperty("Roll_ID")
                                .GetValue(e.Row.DataContext).ToString();
                                foreach (stocking_model stock_item in grid_issuance.ItemsSource)
                                {
                                    if (stock_item.Roll_ID.Equals(Roll_ID))
                                    {
                                        if (child_rolls_issuance_list.Count != 0)
                                        {
                                            int child_issuance_list_index = 0;
                                            foreach (stocking_model child_item in child_rolls_issuance_list)
                                            {
                                                if (child_item.Roll_ID.Equals(Roll_ID))
                                                {
                                                    child_issuance_list_index = child_rolls_issuance_list.IndexOf(child_item);
                                                    break;
                                                }
                                                break;
                                            }
                                            child_rolls_issuance_list.RemoveAt(child_issuance_list_index);
                                            child_rolls_issuance_list.Add(stock_item);
                                        }
                                        else
                                        {
                                            child_rolls_issuance_list.Add(stock_item);
                                        }

                                    }
                                                                  
                                }                               
                            }
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
    }
}
