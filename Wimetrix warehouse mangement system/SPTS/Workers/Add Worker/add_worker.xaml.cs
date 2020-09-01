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

namespace Wimetrix_warehouse_mangement_system.SPTS.Workers.Add_Worker
{
    /// <summary>
    /// Interaction logic for add_worker.xaml
    /// </summary>
    public partial class add_worker : UserControl
    {
        public add_worker()
        {
            InitializeComponent();
            notification_disptachter();
            load_lines();
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
        public void load_lines()
        {
            combo_lines.Items.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_lines);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Lines"); // parse as array  
                foreach (JObject root in objects)
                {
                    String Line_ID = root.GetValue("Line_ID").ToString();
                    combo_lines.Items.Add(Line_ID);
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

        private void Btn_upload_order_Click(object sender, RoutedEventArgs e)
        {
           if(text_worker_id.Text!="" && text_worker_name.Text!="" && combo_lines.Text != "")
            {
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                reqarm.Add("worker_id",text_worker_id.Text);
                reqarm.Add("worker_name", text_worker_name.Text);
                reqarm.Add("line_id", combo_lines.Text);

                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request(reqarm, Http.api_files.insert_worker);
                if (result.getresultFlag())
                {
                    showSuccess("Worker added Succesfully");
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
                            ShowError("Failed to add Worker");
                        }
                    }
                }
            }
            else
            {
                ShowError("Incomplete Information");
            }

            text_worker_id.Text = "";
            text_worker_name.Text = "";
            combo_lines.Text = "";
        }
    }
}
