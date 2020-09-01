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
using Wimetrix_warehouse_mangement_system.Warehouse_Management.Configuration_files;
using Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Departmental_Consumption
{
    /// <summary>
    /// Interaction logic for deparmental_consumption.xaml
    /// </summary>
    public partial class deparmental_consumption : UserControl
    {
        List<stocking_model> issuance_grid_list = new List<stocking_model>();
        public deparmental_consumption()
        {
            InitializeComponent();
            notification_disptachter();
            populateDepartments();

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
        public void populateDepartments()
        {
            combo_department.Items.Clear();
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

                    combo_department.Items.Add(dept_id + " - " + dept_name);
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
        private void Combo_department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grid_issuance.ItemsSource = null;
            grid_issuance.Items.Clear();
            issuance_grid_list.Clear();

            combo_orders.Items.Clear();
            combo_lot.Items.Clear();
            combo_vendors.Items.Clear();
            combo_colors.Items.Clear();
            combo_fabric_type.Items.Clear();

            string selected_department = (sender as ComboBox).SelectedItem as string;
            if (selected_department != null)
            {
                populateOrders(selected_department);
            }

        }
        public void populateOrders(String department)
        {
            String[] Department = department.Split('-');
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("dept_id", Department[0]);
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_consumption_get_orders_for_fabric_roll_search);
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
                populateFabricLot(combo_department.Text, selected_order);
                fetch_data_for_selected_filters(combo_department.Text.ToString(), selected_order, "", "", "", "");
            }

        }
        public void populateFabricLot(String department, String Order)
        {
            String[] Department = department.Split('-');
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", Order);
            reqarm.Add("dept_id", Department[0]);
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_consumption_get_fabric_lot_for_order);
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
                populateVendor(combo_department.Text.ToString(), combo_orders.Text.ToString(), selected_lot);
                fetch_data_for_selected_filters(combo_department.Text.ToString(), combo_orders.Text.ToString(), selected_lot, "", "", "");
            }
        }
        public void populateVendor(String department, String Order, String FabricLot)
        {
            String[] Department = department.Split('-');
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", Order);
            reqarm.Add("fabric_lot", FabricLot);
            reqarm.Add("dept_id", Department[0]);

            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_consumption_get_vendor_for_order_and_fabric_lot);
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
                populateColors(combo_department.Text.ToString(), combo_orders.Text.ToString(), combo_lot.Text.ToString(), selected_vendor);
                fetch_data_for_selected_filters(combo_department.Text.ToString(), combo_orders.Text.ToString(), combo_lot.Text.ToString(), selected_vendor, "", "");
            }
        }
        public void populateColors(String department, String Order, String FabricLot, String Vendor)
        {
            String[] Department = department.Split('-');
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", Order);
            reqarm.Add("fabric_lot", FabricLot);
            reqarm.Add("vendor", Vendor);
            reqarm.Add("dept_id", Department[0]);
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_consumption_get_color_for_order_and_fabric_lot_and_vendor);
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
                populateFabricTypes(combo_orders.Text.ToString(), combo_orders.Text.ToString(), combo_lot.Text.ToString(), combo_vendors.Text.ToString(), selected_color);
                fetch_data_for_selected_filters(combo_department.Text.ToString(), combo_orders.Text.ToString(), combo_lot.Text.ToString(), combo_vendors.Text.ToString(), selected_color, "");
            }
        }
        public void populateFabricTypes(String department, String Order, String FabricLot, String Vendor, String Color)
        {
            String[] Department = department.Split('-');
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", Order);
            reqarm.Add("fabric_lot", FabricLot);
            reqarm.Add("vendor", Vendor);
            reqarm.Add("dept_id", Department[0]);
            reqarm.Add("color", Color);


            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_consumption_get_fabric_type_for_order_and_fabric_lot_and_vendor_and_color);
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
                fetch_data_for_selected_filters(combo_department.Text.ToString(), combo_orders.Text.ToString(), combo_lot.Text.ToString(), combo_vendors.Text.ToString(), combo_colors.Text.ToString(), selected_fabric_type);

            }

        }
        private void btn_consumption_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (stocking_model stock_item in grid_issuance.ItemsSource)
            {
                if (stock_item.Select)
                {
                    count++;
                }

            }
            if (count > 0)
            {
                allocate_consumption();
            }
            else
            {
                ShowError("No Rolls Selected For Department Consumption");
            }


        }
        private void btn_set_Click(object sender, RoutedEventArgs e)
        {
            popup_consumption_error.IsOpen = false;
        }
        public void fetch_data_for_selected_filters(String department, String order, String fabric_lot, String vendor, String color, String fabric_type)
        {
            grid_issuance.ItemsSource = null;
            grid_issuance.Items.Clear();
            issuance_grid_list.Clear();
            String[] Department = department.Split('-');


            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", order);
            reqarm.Add("fabric_lot", fabric_lot);
            reqarm.Add("vendor", vendor);
            reqarm.Add("color", color);
            reqarm.Add("fabric_type", fabric_type);
            reqarm.Add("dept_id", Department[0]);
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_consumption_get_rolls_for_order_and_fabric_lot_and_vendor_and_color_and_fabric_type);
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

                    issuance_grid_list.Add(new stocking_model(false, order, Roll, Color, Weight, Vendor, Fabric_Lot, Fabric_Type,""));


                }
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
        private void Grid_issuance_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
        private void Grid_issuance_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (e.Column.Header.ToString() == "Weight")
            {

            }
        }
        public void allocate_consumption()
        {
            String[] department = combo_department.Text.ToString().Split('-');
            departments dept = new departments();
            String s = dept.get_mapping(int.Parse(department[0]));

            int count = 0;
            int upload_count = 0;
            foreach (stocking_model stock_item in grid_issuance.ItemsSource)
            {

                if (stock_item.Select)
                {
                    var reqarm = new System.Collections.Specialized.NameValueCollection();
                    reqarm.Add("roll_id", stock_item.Roll_ID);
                    reqarm.Add("location_id", s);
                    reqarm.Add("weight", stock_item.Weight);
                    Http.http_request request = new Http.http_request();
                    Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.for_consumption_insert_department_consumption);
                    count++;
                    if (result.getresultFlag())
                    {

                            upload_count++;

                    }

                }

            }

            if (upload_count == count)
            {
                showSuccess("Consumption has been recorded for selected rolls");
               
                grid_issuance.ItemsSource = null;
                grid_issuance.Items.Clear();
                issuance_grid_list.Clear();
                combo_orders.Items.Clear();
                combo_lot.Items.Clear();
                combo_fabric_type.Items.Clear();
                combo_vendors.Items.Clear();
                combo_colors.Items.Clear();
                populateOrders(combo_department.Text.ToString());

            }
            else
            {
                ShowError("Failed to record consumption");
            }



        }
        public bool set_intention_flag(String rfid)
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("card_epc", rfid);
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.stock_in);
            if (result.getresultFlag())
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
