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

namespace Wimetrix_warehouse_mangement_system.SPTS.Orders.Add_Order
{
    /// <summary>
    /// Interaction logic for add_order.xaml
    /// </summary>
    public partial class add_order : UserControl
    {
        public add_order()
        {
            InitializeComponent();
            notification_disptachter();
            get_orders();
        }
        private DispatcherTimer dispatcherTimer;
        public void notification_disptachter()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
        }
        public void get_orders()
        {
            combo_orders.Items.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_warehouse_orders);
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
                    ShowError("Please Check IP Or Server");
                }
                else
                {
                    ShowError("Unable to load orders for date and dcn");
                }
            }

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
        private void Btn_upload_order_Click(object sender, RoutedEventArgs e)
        {
            if(combo_orders.Text.ToString() != ""
                && text_style.Text.ToString() != ""
                && text_article.Text.ToString() != ""
                && text_size.Text.ToString() != ""
                && text_color.Text.ToString() != ""
                )
            {
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                reqarm.Add("orderID", combo_orders.Text.ToString());
                reqarm.Add("styleCode", text_style.Text.ToString());
                reqarm.Add("article", text_article.Text.ToString());
                reqarm.Add("color", text_color.Text.ToString());
                reqarm.Add("size", text_size.Text.ToString());

                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request(reqarm, Http.api_files.insert_order);
                if (result.getresultFlag())
                {
                    combo_orders.SelectedIndex = -1;
                    text_style.Text = "";
                    text_article.Text = "";
                    text_size.Text = "";
                    text_color.Text = "";
                    showSuccess("Order added Successfully");
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
                            ShowError("Cannot add Order");
                        }
                    }
                }

            }
            else
            {
                ShowError("Incomplete Information");
            }
        
        }
    }
}
