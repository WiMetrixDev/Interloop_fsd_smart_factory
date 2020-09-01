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

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking
{
    /// <summary>
    /// Interaction logic for manual_stocking_UC.xaml
    /// </summary>
    public partial class manual_stocking_UC : UserControl
    {
        Stock_IN.stock_in_uc stock_in = new Stock_IN.stock_in_uc();
        Stock_Out.stock_out_uc stock_out = new Stock_Out.stock_out_uc();
        public manual_stocking_UC()
        {
            InitializeComponent();
            notification_disptachter();
            fill_combo_orders();
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
        public void fill_combo_orders()
        {
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
                    stock_in.combo_orders.Items.Add(order_number);
                    stock_out.combo_orders.Items.Add(order_number);

                }
            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please check IP or server");
                }
            }

        }
        private void btn_stock_IN_Click(object sender, RoutedEventArgs e)
        {
           btn_stock_IN.Background = Brushes.Green;
            btn_Stock_out.Background = Brushes.DarkSlateGray;
            dock_stocking.Children.Clear();
            Stock_IN.stock_in_uc us = new Stock_IN.stock_in_uc();
            stock_in.HorizontalAlignment = HorizontalAlignment.Stretch;
            stock_in.VerticalAlignment = VerticalAlignment.Stretch;
            dock_stocking.Children.Add(stock_in);
        }
        private void btn_Stock_out_Click(object sender, RoutedEventArgs e)
        {
            btn_Stock_out.Background = Brushes.Green;
            btn_stock_IN.Background = Brushes.DarkSlateGray;
            dock_stocking.Children.Clear();
            Stock_Out.stock_out_uc us = new Stock_Out.stock_out_uc();
            stock_out.HorizontalAlignment = HorizontalAlignment.Stretch;
            stock_out.VerticalAlignment = VerticalAlignment.Stretch;
            dock_stocking.Children.Add(stock_out);
        }
    }
}
