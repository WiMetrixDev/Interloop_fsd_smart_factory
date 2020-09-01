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

namespace Wimetrix_warehouse_mangement_system.SPTS.CutReport.view_cutreport
{
    /// <summary>
    /// Interaction logic for view_cutreport.xaml
    /// </summary>
    public partial class view_cutreport : UserControl
    {
        static List<cutreport_model> cut_report_list = new List<cutreport_model>();
        static ObservableCollection<cutreport_model> cutreport_model_list = new ObservableCollection<cutreport_model>();
        public view_cutreport()
        {
            InitializeComponent();
            notification_disptachter();
            load_orders();
     
        }
        public void load_orders()
        {
            combo_orders.Items.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_orders_list);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Orders"); // parse as array  
                foreach (JObject root in objects)
                {
                    String Order = root.GetValue("Order_ID").ToString();

                    combo_orders.Items.Add(Order);
    

                    // stock_list.Add(new stocking_model(false, Order_code, Roll, Color, Weight));
                }
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Check IP or Server");
                }
                else
                {
                    if (result.geterrorCode() == "API-001")
                    {
                        ShowError("Unable to fetch Data");
                    }
                }
            }

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

        private void Btn_load_cutreport_Click(object sender, RoutedEventArgs e)
        {
            if (combo_orders.Text != "")
            {
                load_cutreport(combo_orders.SelectedValue.ToString());
            }
            else
            {
                ShowError("Please select Order first");
            }
        }

        public void load_cutreport(String Order)
        {
            grid_view_cutreport.ItemsSource = null;
            grid_view_cutreport.Items.Clear();
            cutreport_model_list.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", Order);
            // reqarm.Add();
            //reqarm.Add();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_cut_report_for_order);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Cut_Report"); // parse as array  
                foreach (JObject root in objects)
                {
                    String Item_ID = root.GetValue("Item ID").ToString();
                    String Cut_ID = root.GetValue("Cut ID").ToString();
                    String Bundle = root.GetValue("Bundle ID").ToString();
                    String Quantity = root.GetValue("Quantity").ToString();
                    String StyleCode = root.GetValue("StyleCode").ToString();
                    String Article = root.GetValue("Article").ToString();
                    String Size = root.GetValue("Size").ToString();
                    String Color = root.GetValue("Color").ToString();
                    //cut_report_list.Add(new cutreport_model(Order,Cut_ID,Bundle,Size,Quantity,Article,StyleCode,Color));
                    cutreport_model_list.Add(new cutreport_model(Order, Cut_ID, Bundle, Size, Quantity, Article, StyleCode, Color));
                }

                  grid_view_cutreport.ItemsSource = cutreport_model_list;

            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Check IP or Server");
                }
                else
                {
                    if (result.geterrorCode() == "API-001")
                    {
                        ShowError("Unable to fetch Cut Report");
                    }
                }
            }
        }
    }
}
