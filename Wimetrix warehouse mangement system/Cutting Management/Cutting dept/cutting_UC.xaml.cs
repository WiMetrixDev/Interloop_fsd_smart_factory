using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Wimetrix_warehouse_mangement_system.Cutting_Management.Cutting_dept.serial;

namespace Wimetrix_warehouse_mangement_system.Cutting_Management.Cutting_dept
{
    /// <summary>
    /// Interaction logic for cutting_UC.xaml
    /// </summary>
    public partial class cutting_UC : UserControl
    {
        static List<cutting_model> cutting_list = new List<cutting_model>();

        static float large_waste_list = 0;
        static float small_waste_list =0 ;
        serial_weight serial = new serial_weight();
        String activity_code;
        bool flag_large_waste = false;
        bool flag_small_waste = false;
        bool reader_flag = false;
        String final_large_waste="";
        String final_small_waste = "";
        String final_small_waste_percentage = "";
        String final_large_waste_percentage="";
        String Card_number;

        String Order;
        String roll;
        String fabric_color_code;
        String fabric_lot_code;
        String supplier_code;
        String fabric_type_code;
        String supplier_lot;
        String available_weight;

        String last_Order;
        String last_roll;
        String last_fabric_color_code;
        String last_fabric_lot_code;
        String last_supplier_code;
        String last_fabric_type_code;
        String last_available_weight;

        String consumption_requested;
        String activity_start_time;
        String activity_end_time;

        int activity_rolls;
        float activity_weight = 0;
            
        WindowsService1.readerDataHandlers reader = new WindowsService1.readerDataHandlers();             
        private static cutting_UC _instance;
        public static cutting_UC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new cutting_UC();
          
                return _instance;
            }
        }
        public void destroy()
        {

            _instance = null;
            text_small_weight_percentage.Content = "";
            text_small_weight.Text = "";
            text_small_weight_percentage.Content = "";
            text_small_weight.Text = "";
            grid_cutting.ItemsSource = null;
            grid_cutting.Items.Clear();
            cutting_list.Clear();
            large_waste_list = 0;
            small_waste_list = 0;


        }
        public cutting_UC()
        {
            InitializeComponent();
            notification_disptachter();
            notification_disptachter_popup();
            //text_total_consumption.Content = 500;
            //text_total_rolls.Content = 20;
            text_large_weight.IsEnabled = false;
            text_large_weight_percentage.IsEnabled = false;
            btn_large_waste.IsEnabled = false;
            btn_large_waste_hault.IsEnabled = false;
            text_small_weight.IsEnabled = false;
            text_small_weight_percentage.IsEnabled = false;
            btn_small_waste.IsEnabled = false;
            btn_small_waste_hault.IsEnabled = false;

        }
        public void connect()
        {
           
            serial.connectSerial();
            reader.ConnectReader("COM101");

        }
        private static readonly Regex _regex = new Regex("[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
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
        private DispatcherTimer dispatcherTimer_popup;
        public void notification_disptachter_popup()
        {
            dispatcherTimer_popup = new DispatcherTimer();
            dispatcherTimer_popup.Tick += new EventHandler(dispatcherTimer_Tick_popup);
            dispatcherTimer_popup.Interval = new TimeSpan(0, 0, 5);
        }
        private void dispatcherTimer_Tick_popup(object sender, EventArgs e)
        {
            notifier_popup.Visibility = System.Windows.Visibility.Collapsed;

            //Disable the timer
            dispatcherTimer.IsEnabled = false;
        }
        public void ShowError_popup(String text)
        {

            notifier_popup.Text = text;
            notifier_popup.Background = Brushes.IndianRed;
            notifier_popup.Visibility = Visibility.Visible;
            dispatcherTimer_popup.Start();
        }
        public void showSuccess_popup(String text)
        {
            notifier_popup.Text = text;
            notifier_popup.Background = Brushes.LimeGreen;
            notifier_popup.Visibility = Visibility.Visible;
            dispatcherTimer_popup.Start();
        }    
        private void Partial_Checked(object sender, RoutedEventArgs e)
        {
            partial_meters_dock.Visibility = Visibility.Visible;
        }
        private void Btn_popup_ok_Click(object sender, RoutedEventArgs e)
        {
            if(Partial.IsChecked == true || Complete.IsChecked == true)
            {
                grid_cutting.ItemsSource = null;
                grid_cutting.Items.Clear();

                if (Partial.IsChecked == true)
                {
                    if (!text_weight_left.Text.ToString().Equals("") && IsTextAllowed(text_weight_left.Text.ToString()))
                    {
                        try
                        {
                            float weight_left_float = float.Parse(text_weight_left.Text.ToString());
                            float available_weight_float = float.Parse(popup_text_weight_available.Content.ToString());
                            //  MessageBox.Show(weight_left_float.ToString() + available_weight_float.ToString());
                            if (weight_left_float > 0)
                            {
                                if (weight_left_float < available_weight_float)
                                {
                                    String consumption = (available_weight_float - weight_left_float).ToString();
                                    cutting_list.Add(new cutting_model(Order, roll, consumption, weight_left_float.ToString(), "Partial"));
                                    activity_weight = activity_weight + float.Parse(consumption);
                                    consumption_requested = text_weight_left.Text.ToString();

                                    last_Order = Order;
                                    last_roll = roll;
                                    last_fabric_color_code = fabric_color_code;
                                    last_fabric_lot_code = fabric_lot_code;
                                    last_supplier_code = supplier_code;
                                    last_fabric_type_code = fabric_type_code;
                                    last_available_weight = available_weight;
                                    close_popup();

                                }
                                else
                                {
                                    text_weight_left.Text = "";
                                    ShowError_popup("Weight left cannot be greater than weight Available");
                                }
                            }
                            else
                            {
                                text_weight_left.Text = "";
                                ShowError_popup("Remaining weight should be greater than zero");
                            }

                           
                        }
                        catch(Exception ex)
                        {
                            ShowError_popup("Invalid Characters in weight");
                        }
                     

                    }
                    else
                    {
                        ShowError_popup("Invalid weight");
                    }
                }
                else
                {
                    if (Complete.IsChecked == true)
                    {
                        String consumption = available_weight;
                        cutting_list.Add(new cutting_model(Order, roll, available_weight, "0", "Complete"));
                        activity_weight = activity_weight + float.Parse(available_weight);
                        last_Order = Order;
                        last_roll = roll;
                        last_fabric_color_code = fabric_color_code;
                        last_fabric_lot_code = fabric_lot_code;
                        last_supplier_code = supplier_code;
                        last_fabric_type_code = fabric_type_code;
                        last_available_weight = available_weight;
                        close_popup();
                    }
                }

                grid_cutting.ItemsSource = cutting_list;
                text_total_consumption.Content = activity_weight;
                text_total_rolls.Content = grid_cutting.Items.Count;
            }
            else
            {
                ShowError_popup("Please select partial or complete");
            }

        }
        private void Complete_Checked(object sender, RoutedEventArgs e)
        {
            partial_meters_dock.Visibility = Visibility.Hidden;
        }
        public void fetch_card_details(String card_number)
        {         
            this.Dispatcher.Invoke(() =>
            {             
                if (reader_flag)
                {
                    var reqarm = new System.Collections.Specialized.NameValueCollection();
                    reqarm.Add("rfid_tag", card_number);
                    Http.http_request request = new Http.http_request();
                    Http.HttpResult result = request.send_request(reqarm, Http.api_files.cutting_get_RFID_detail);
                    if (result.getresultFlag())
                    {
                        JObject json = result.getjsonResult();
                        roll = json.GetValue("Roll Code").ToString();
                        Order = json.GetValue("Order Code").ToString();
                        available_weight = json.GetValue("Weight").ToString();
                        fabric_color_code = json.GetValue("fabric_color_code").ToString();
                        fabric_lot_code = json.GetValue("fabric_lot_code").ToString();
                        supplier_code = json.GetValue("supplier_code").ToString();
                        fabric_type_code = json.GetValue("fabric_type_code").ToString();
                        supplier_lot = json.GetValue("supplier_lot").ToString();

                        bool rollAlreadyExists = false; 
                        foreach (cutting_model cutting_roll in cutting_list)
                        {
                            if (cutting_roll.Roll.Equals(roll))
                            {
                                rollAlreadyExists = true;
                            }
                        }
                         if (!rollAlreadyExists)
                            {
                            if (last_Order == Order
                            && last_fabric_color_code == fabric_color_code
                            && last_fabric_lot_code == fabric_lot_code
                            )
                            {
                                popup_text_order.Content = Order;
                                popup_text_roll_id.Content = roll;
                                popup_text_color.Content = fabric_color_code;
                                popup_text_fabric_lot.Content = fabric_lot_code;
                                popup_text_vendor.Content = supplier_code;
                                popup_text_fabric_type.Content = fabric_type_code;
                                popup_text_weight_available.Content = available_weight;
                                popup_text_supplier_lot.Content = supplier_lot;
                                show_popup();
                            }
                            else
                            {
                                if (cutting_list.Count == 0)
                                {
                                    popup_text_order.Content = Order;
                                    popup_text_roll_id.Content = roll;
                                    popup_text_color.Content = fabric_color_code;
                                    popup_text_fabric_lot.Content = fabric_lot_code;
                                    popup_text_vendor.Content = supplier_code;
                                    popup_text_fabric_type.Content = fabric_type_code;
                                    popup_text_weight_available.Content = available_weight;
                                    popup_text_supplier_lot.Content = supplier_lot;
                                    show_popup();
                                }
                                else
                                {
                                    ShowError("Order, fabric lot, color of the roll does not match with previosuly scanned rolls");
                                }
                            }
                        }
                        else
                        {
                            ShowError("Card already scanned");
                        }                  
                    }
                    else
                    {
                        if (result.geterrorCode() == "server001")
                        {
                            ShowError("Please check IP or server");
                        }
                        else
                        {
                            if(result.geterrorCode()== "API-001")
                            {
                                ShowError("No data found against this card");
                            }
                        }
                    }

                }
            });
            
        }
        public void close_popup()
        {
            issuance_popup.IsOpen = false;
            popup_text_order.Content = "";
            popup_text_roll_id.Content = "";
            popup_text_color.Content = "";
            popup_text_fabric_lot.Content = "";
            popup_text_vendor.Content = "";
            popup_text_fabric_type.Content = "";
            popup_text_weight_available.Content = "";
            reader_flag = true;
        }
        public void show_popup()
        {
            text_weight_left.Text = "";
            issuance_popup.IsOpen = true;
            reader_flag = false;
        }
        public void weight_receiver(String weight)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (flag_large_waste)
                {
                    float weight_serial = float.Parse(weight) + large_waste_list;
                    text_large_weight.Text = weight_serial.ToString() ;
                }
                else
                {
                    if (flag_small_waste)
                    {
                        float weight_serial = float.Parse(weight) + small_waste_list;
                        text_small_weight.Text = weight_serial.ToString();
                    }

                    if (reader_flag)
                    {
                        float weight_serial = float.Parse(weight);
                        text_weight_left.Text = weight_serial.ToString();
                    }
                }

            });
        }
        private void Btn_start_cutting_Click(object sender, RoutedEventArgs e)
        {
            if (btn_start_cutting.Content.ToString() == "Start Roll Scanning")
            {
                if (generate_activity_code())
                {
                    activity_start_time =  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    reader_flag = true;
                    btn_start_cutting.Content = "Stop Roll Scanning";
                    
                    bool flag_large_waste = false;
                    bool flag_small_waste = false;

                    text_large_weight.IsEnabled = false;
                    text_large_weight_percentage.IsEnabled = false;
                    btn_large_waste.IsEnabled = false;
                    btn_large_waste_hault.IsEnabled = false;
                    text_small_weight.IsEnabled = false;
                    text_small_weight_percentage.IsEnabled = false;
                    btn_small_waste.IsEnabled = false;
                    btn_small_waste_hault.IsEnabled = false;

                }
                //   btn_connect.IsEnabled = true;

            }
            else
            {
                if (btn_start_cutting.Content.ToString() == "Stop Roll Scanning")
                {
                    btn_start_cutting.Content = "Start Roll Scanning";
                    if (activity_weight > 0)
                    {
                        reader_flag = false;
                        flag_large_waste = true;
                        text_large_weight.IsEnabled = true;
                        text_large_weight_percentage.IsEnabled = true;
                        btn_large_waste.IsEnabled = true;
                        btn_large_waste_hault.IsEnabled = true;
                        text_small_weight.IsEnabled = false;
                        text_small_weight_percentage.IsEnabled = false;
                        btn_small_waste.IsEnabled = false;
                        btn_small_waste_hault.IsEnabled = false;
                        showSuccess("Please provide Small and Large wastage of the Roll");
                    }
                    else
                    {
                        reader_flag = false;
                    }

                }
            }

        }
        public bool generate_activity_code()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.cutting_generate_activity_code);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                 activity_code = json.GetValue("Activity_Code").ToString();
                Console.WriteLine("Activity"+activity_code);
               // populate_combo_ports();
                return true;
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please check IP or server");
                    return false;
                }
                else
                {
                    ShowError("Unable to Generate Activity Code. Server File Error");
                }
                return false;
            }

        }
        private void Btn_popup_cancel_Click(object sender, RoutedEventArgs e)
        {
            close_popup();
        }
        private void Btn_large_waste_Click(object sender, RoutedEventArgs e)
        {
            if(text_total_consumption.Content.ToString() != "0" && text_total_rolls.Content.ToString() != "0")
            {
                if((text_large_weight.Text.ToString()!="" && text_large_weight_percentage.Content.ToString() != "") || (large_waste_list > 0))
                {

                    float consumption_float = float.Parse(text_total_consumption.Content.ToString());
                    
                    float current_large_waste = float.Parse(text_large_weight.Text.ToString());
                    float total_large_waste = current_large_waste;                
                    final_large_waste = total_large_waste.ToString() ;
                    float  final_large_waste_percentage_float = total_large_waste / consumption_float * 100;
                    final_large_waste_percentage = final_large_waste_percentage_float.ToString();

                    flag_small_waste = true;
                    flag_large_waste = false;
                    btn_small_waste.IsEnabled = false;
                    btn_small_waste.IsEnabled = true;

                    text_large_weight.IsEnabled = false;
                    text_large_weight_percentage.IsEnabled = false;
                    btn_large_waste.IsEnabled = false;
                    btn_large_waste_hault.IsEnabled = false;
                    text_small_weight.IsEnabled = true;
                    text_small_weight_percentage.IsEnabled = true;
                    btn_small_waste.IsEnabled = true;
                    btn_small_waste_hault.IsEnabled = true;

                    showSuccess("Provide small waste now");
                }
                else
                {
                    ShowError("Please provide large wastage");
                }

            }
            else
            {
                ShowError("Please scan rolls for consumption first");
            }

        }
        private void Btn_small_waste_Click(object sender, RoutedEventArgs e)
        {
                flag_small_waste = false;
                flag_large_waste = false;
                    if ((text_small_weight.Text != "" && text_small_weight_percentage.Content.ToString() != "" ) || (small_waste_list > 0))
                    {
                //float previous_small_waste = sm();
                float current_small_waste = float.Parse(text_small_weight.Text.ToString());
                float total_small_weight = current_small_waste;

                final_small_waste = total_small_weight.ToString();

                float consumption_float = float.Parse(text_total_consumption.Content.ToString());
                float large_waste_float = float.Parse(final_large_waste);

                float total_small_weight_percentage = total_small_weight / (consumption_float - large_waste_float) * 100;
                final_small_waste_percentage = total_small_weight_percentage.ToString();

                if (cutting_list.Count > 0)
                {
                    var json = JsonConvert.SerializeObject(cutting_list);
                   
                    if (submit_individual(json))
                    {
                        if (submit_activity())
                        {
                            text_large_weight.Text = "";
                            text_small_weight.Text = "";
                            text_small_weight_percentage.Content = "";
                            text_large_weight_percentage.Content = "";
                            large_waste_list = 0;
                            small_waste_list = 0;
                            text_total_consumption.Content = "";
                            consumption_requested = "";
                            activity_weight = 0;
                            text_total_rolls.Content = "";
                            flag_large_waste = false;
                            flag_small_waste = false;
                            showSuccess("Cutting recorded successfuly, Click Start Cutting to start next cutting activity");
                            grid_cutting.ItemsSource = null;
                            grid_cutting.Items.Clear();
                            cutting_list.Clear();

                            text_large_weight.IsEnabled = false;
                            text_large_weight_percentage.IsEnabled = false;
                            btn_large_waste.IsEnabled = false;
                            btn_large_waste_hault.IsEnabled = false;
                            text_small_weight.IsEnabled = false;
                            text_small_weight_percentage.IsEnabled = false;
                            btn_small_waste.IsEnabled = false;
                            btn_small_waste_hault.IsEnabled = false;
                        }
                        else
                        {

                            ShowError("Unable to Submit Large Waste and Small Waste");

                        }
                    }
                    else
                    {
                        ShowError("Unable to Update Weight of the Rolls, Large and Small Waste Not Submitted");
                    }
                }
                else
                {
              
                }
                        
                                }
                            else
                            {
                                ShowError("Small waste can't be zero or empty");
                            }
                                    
        }
        private void Text_small_weight_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }
        private void Text_large_weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!text_large_weight.Text.ToString().Equals("") && IsTextAllowed(text_large_weight.Text.ToString()))
            {
                try
                {
                    float large_waste_float = float.Parse(text_large_weight.Text.ToString());
                    float consumption_float = float.Parse(text_total_consumption.Content.ToString());
                    // large_waste_float = large_waste_float +  calculate_total_large_waste();
                    if(large_waste_float < consumption_float)
                    {
                      
                        text_large_weight_percentage.Content = (large_waste_float) / consumption_float * 100;
                    }
                    else
                    {
                        large_waste_list =  0 ;
                      
                        text_large_weight_percentage.Content = "";
                        text_large_weight.Text = "";
                        ShowError("Consumtion cannot be less than large waste");
                    }
                }
                catch (Exception ex)
                {
                    large_waste_list = 0;
                    text_large_weight_percentage.Content = "";
                    text_large_weight.Text = "";
                }
            }
            else
            {
               
                text_large_weight.Text = "";
                text_large_weight_percentage.Content = "";
                //  ShowError("Invalid Large Waste");
            }
        }
        private void Text_small_weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!text_small_weight.Text.ToString().Equals("") && IsTextAllowed(text_small_weight.Text.ToString()))
            {
                try
                {
                    float small_waste_float = float.Parse(text_small_weight.Text.ToString());
                    float large_waste_float = float.Parse(final_large_waste.ToString());
                    float consumption_float = float.Parse(text_total_consumption.Content.ToString());
               //     small_waste_float = small_waste_float + calculate_total_small_waste();
                    if (small_waste_float < (consumption_float - large_waste_float))
                    {
                       
                        text_small_weight_percentage.Content = (small_waste_float) / (consumption_float - large_waste_float) * 100;
                    }
                    else
                    {
                        small_waste_list = 0;

                        text_small_weight_percentage.Content = "";
                        text_small_weight.Text = "";
                        ShowError("Small waste cannot be greater than sum of large waste and consumption");
                    }
                }
                catch (Exception ex)
                {
                    small_waste_list = 0;
                    text_small_weight_percentage.Content = "";
                    text_small_weight.Text = "";
                }
            }
            else
            {
                text_small_weight.Text = "";
                text_small_weight_percentage.Content = "";
                //  ShowError("Invalid Large Waste");
            }
        }
        private void Btn_submit_cutting_Click(object sender, RoutedEventArgs e)
        {
      
        }
        private void Btn_large_waste_hault_Click(object sender, RoutedEventArgs e)
        {
            if (flag_large_waste)
            {
                String weight = text_large_weight.Text.ToString();
                try
                {
                    large_waste_list = float.Parse(weight);
                    text_large_weight_percentage.Content = "";
                    text_large_weight.Text = "";
                }catch(Exception ex)
                {

                }
           
            }
        }
        private void Btn_small_waste_hault_Click(object sender, RoutedEventArgs e)
        {
            if (flag_small_waste)
            {
                String weight = text_small_weight.Text.ToString();
                try
                {
                    small_waste_list = float.Parse(weight);
                    text_small_weight_percentage.Content = "";
                    text_small_weight.Text = "";
                }
                catch (Exception ex)
                {

                }

            }
        }
        public bool submit_individual(String Roll_info)
        
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("roll_info", Roll_info);
            Console.WriteLine(Roll_info);
            reqarm.Add("activity_code", activity_code);

            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.cutting_get_insert_individual_roll);
            if (result.getresultFlag())
            {

                return true;
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please check IP or server");
                    return false;
                }
                else
                {
                    ShowError("Unable to Submit. Server File Error");
                }
            }

            return false;
        }
        public bool submit_activity()
        {
            var reqarm = new System.Collections.Specialized.NameValueCollection();

            activity_end_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            reqarm.Add("activity_code", activity_code);
            reqarm.Add("large_waste", final_large_waste);
            reqarm.Add("large_waste_percentage", final_large_waste_percentage);
            reqarm.Add("small_waste", final_small_waste);
            reqarm.Add("small_waste_percentage", final_small_waste_percentage);
            reqarm.Add("start_time", activity_start_time);
            reqarm.Add("end_time", activity_end_time);


            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.cutting_insert_activity);
            if (result.getresultFlag())
            {

                return true;
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please check IP or server");
                    return false;
                }
                else
                {

                }
            }

            return false;
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
