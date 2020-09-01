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

namespace Wimetrix_warehouse_mangement_system.SPTS.Operations.View_operations
{
    /// <summary>
    /// Interaction logic for view_operations.xaml
    /// </summary>
    public partial class view_operations : UserControl
    {
        static List<operation_model> operaton_list = new List<operation_model>();
        public view_operations()
        {
            InitializeComponent();
            notification_disptachter();
        }

        private void Grid_operation_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
        private void Btn_load_operations_Click(object sender, RoutedEventArgs e)
        {
            grid_operation_list.ItemsSource = null;
            grid_operation_list.Items.Clear();
            operaton_list.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_operations_list);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Operations"); // parse as array  
                foreach (JObject root in objects)
                {
                    String Operation_ID = root.GetValue("Operation_ID").ToString();
                    String Operation_Description = root.GetValue("Operation_Description").ToString();
                    operaton_list.Add(new operation_model(Operation_ID, Operation_Description));
                }
                grid_operation_list.ItemsSource = operaton_list;
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

        private void Text_color_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Text_operation_KeyUp(object sender, KeyEventArgs e)
        {
            grid_operation_list.ItemsSource = null;
            grid_operation_list.Items.Clear();
            var filtered = operaton_list.Where(operation_model => operation_model.Description.StartsWith(text_operation.Text.ToString()));
            grid_operation_list.ItemsSource = filtered;
        }
    }
}
