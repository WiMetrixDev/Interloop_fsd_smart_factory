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

namespace Wimetrix_warehouse_mangement_system.SPTS.Operations.Add_operation
{
    /// <summary>
    /// Interaction logic for add_operation.xaml
    /// </summary>
    public partial class add_operation : UserControl
    {
        public add_operation()
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
        private void Btn_upload_operation_Click(object sender, RoutedEventArgs e)
        {
            if (text_operation.Text != "" && text_section.Text != "")
            {
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                reqarm.Add("operation_description", text_operation.Text);
                reqarm.Add("section", text_section.Text);
                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request(reqarm, Http.api_files.insert_operation);
                if (result.getresultFlag())
                {
                    showSuccess("Operation added Successfully");
                    text_operation.Text = "";
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
                            ShowError("Cannot add Operation");
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
