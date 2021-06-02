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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Wimetrix_warehouse_mangement_system.Properties;

namespace Wimetrix_warehouse_mangement_system.Login
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
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
        private void db_connect_Click(object sender, RoutedEventArgs e)
        {

            if (text_username.Text != "" && text_password.Password != "")
            {
                verify_login(text_username.Text.ToString(), text_password.Password.ToString());
            }
            else
            {
                ShowError("Provide username and password");
            }



        }

        public void verify_login(String username, String password)
        {
            var reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("user_code", username);
            reqparm.Add("password", password);

            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request_for_error_codes_in_return(reqparm, Http.api_files.login);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                String department = json.GetValue("Dept").ToString();
                String user_type = json.GetValue("User Type").ToString();

                Settings.Default.user_type = user_type;
                Settings.Default.user_dept = department;
                Settings.Default.username = username;
                Settings.Default.password = password;
                Settings.Default.Save();

                wlecome_window welcome_screen = new wlecome_window();
                welcome_screen.Show();
                this.Close();
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
        private void btn_windowClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        private void btn_setIP_Click(object sender, RoutedEventArgs e)
        {
            if (ip_popup.IsOpen != true)
            {
                text_ip.Text = Settings.Default["serverIP"].ToString();
                showIpPopup();
            }

        }
        private void btn_set_Click(object sender, RoutedEventArgs e)
        {
            if (ip_popup.IsOpen)
            {
                Settings.Default["serverIP"] = text_ip.Text;
                Settings.Default.Save();
                hideIpPopup();
            }
        }
        public void showIpPopup()
        {
            var blur = new BlurEffect();
            var current = this.Background;
            blur.Radius = 6;

            this.Background = new SolidColorBrush(Colors.DarkGray);
            this.Effect = blur;
            ip_popup.IsOpen = true;
            ////this.Effect = null;
            ////this.Background = current;
            //
        }
        public void hideIpPopup()
        {
            ip_popup.IsOpen = false;
            this.Effect = null;
            this.Background = new SolidColorBrush(Colors.White);


        }
        private void btn_setNodeIP_Click(object sender, RoutedEventArgs e)
        {
            if (node_ip_popup.IsOpen != true)
            {
                text_node_ip.Text = Settings.Default["nodeServerIP"].ToString();
                showNodeIpPopup();
            }

        }
        private void btn_set_node_Click(object sender, RoutedEventArgs e)
        {
            if (node_ip_popup.IsOpen)
            {
                Settings.Default["nodeServerIP"] = text_node_ip.Text;
                Settings.Default.Save();
                hideNodeIpPopup();
            }
        }
        public void showNodeIpPopup()
        {
            var blur = new BlurEffect();
            var current = this.Background;
            blur.Radius = 6;

            this.Background = new SolidColorBrush(Colors.DarkGray);
            this.Effect = blur;
            node_ip_popup.IsOpen = true;
            ////this.Effect = null;
            ////this.Background = current;
            //
        }
        public void hideNodeIpPopup()
        {
            node_ip_popup.IsOpen = false;
            this.Effect = null;
            this.Background = new SolidColorBrush(Colors.White);


        }
        private void btn_windowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }



}
