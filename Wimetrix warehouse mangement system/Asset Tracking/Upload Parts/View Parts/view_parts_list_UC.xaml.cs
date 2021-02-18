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

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Upload_Parts.View_Parts
{
    /// <summary>
    /// Interaction logic for view_parts_list_UC.xaml
    /// </summary>
    public partial class view_parts_list_UC : UserControl
    {
        static List<parts_model> parts_list = new List<parts_model>();
        public view_parts_list_UC()
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
        private void btn_load_parts_Click(object sender, RoutedEventArgs e)
        {
            grid_parts_list.ItemsSource = null;
            grid_parts_list.Items.Clear();
            parts_list.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_part_list);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Parts"); // parse as array  
                foreach (JObject root in objects)
                {
                    String part_id = root.GetValue("part_id").ToString();
                    String item = root.GetValue("item").ToString();
                    String part_code = root.GetValue("part_code").ToString();
                    String part_quantity = root.GetValue("part_quantity").ToString();
                    String UOM = root.GetValue("part_uom").ToString();
                    String Organization = root.GetValue("part_organization").ToString();
                    String location_name = root.GetValue("location_name").ToString();
                    parts_list.Add(new parts_model(part_id, item, part_code, Organization, UOM,part_quantity, location_name));
                }
                grid_parts_list.ItemsSource = parts_list;
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
                        ShowError("Unable to fetch parts list");
                    }
                }
            }
        }

        private void text_parts_KeyUp(object sender, KeyEventArgs e)
        {
            grid_parts_list.ItemsSource = null;
            grid_parts_list.Items.Clear();
            var filtered = parts_list.Where(parts_model => parts_model.Name.ToLower().StartsWith(text_parts.Text.ToString().ToLower()));
            grid_parts_list.ItemsSource = filtered;
        }
    }
}
