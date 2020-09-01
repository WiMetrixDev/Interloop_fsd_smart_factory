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

namespace Wimetrix_warehouse_mangement_system.SPTS.Workers.View_Worker
{
    /// <summary>
    /// Interaction logic for view_worker.xaml
    /// </summary>
    public partial class view_worker : UserControl
    {
        static List<workers_model> worker_list = new List<workers_model>();
        public view_worker()
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
        private void Btn_load_workers_Click(object sender, RoutedEventArgs e)
        {
            grid_workers_list.ItemsSource = null;
            grid_workers_list.Items.Clear();
            worker_list.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_workers_list);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Workers"); // parse as array  
                foreach (JObject root in objects)
                {
                    String Worker_ID = root.GetValue("Worker_ID").ToString();
                    String Worker_name = root.GetValue("Worker_Name").ToString();
                    String Line = root.GetValue("Line_ID").ToString();

                    worker_list.Add(new workers_model(Worker_ID, Worker_name,Line));
                }
                grid_workers_list.ItemsSource = worker_list;
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
    }
}
