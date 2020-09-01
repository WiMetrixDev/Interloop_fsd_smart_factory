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

namespace Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin.View_Style_Bulletin
{
    /// <summary>
    /// Interaction logic for view_style_bulletin.xaml
    /// </summary>
    public partial class view_style_bulletin : UserControl
    {
        static List<style_bulletin_model> style_bulletin_list = new List<style_bulletin_model>();
        public view_style_bulletin()
        {
            InitializeComponent();
            notification_disptachter();
            load_style_bulletin_data();
            
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
        private void Btn_view_style_bulletin_Click(object sender, RoutedEventArgs e)
        {
            if(combo_orders.Text.ToString()!=""
                && combo_style.Text.ToString()!=""
                && combo_article.Text.ToString() != "")
            {
                get_style_bulletin(combo_orders.Text.ToString(), combo_style.Text.ToString(), combo_article.Text.ToString());
            }
            else
            {
                ShowError("Select Order, Style Code and Article first");
            }
        }
        public void load_style_bulletin_data()
        {
            combo_orders.Items.Clear();
            combo_style.Items.Clear();
            combo_article.Items.Clear();
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
        public void load_style_for_order(String order)
        {
            combo_style.Items.Clear();
            combo_article.Items.Clear();
            combo_style.Text = "";
            combo_article.Text = "";

            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", order);
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_style_for_order);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Style_Codes"); // parse as array  
                foreach (JObject root in objects)
                {
                    String styleCode = root.GetValue("Style_Code").ToString();
                    combo_style.Items.Add(styleCode);
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
        public void load_article_for_order(String order, String StyleCode)
        {
            combo_article.Items.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", order);
            reqarm.Add("style_code", StyleCode);

            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_article_for_order);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Articles"); // parse as array  
                foreach (JObject root in objects)
                {
                    String Article = root.GetValue("Article").ToString();
                    combo_article.Items.Add(Article);
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
        private void Combo_orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grid_view_styleBulletin.ItemsSource = null;
            grid_view_styleBulletin.Items.Clear();
            style_bulletin_list.Clear();
            string selected_order = (sender as ComboBox).SelectedItem as string;
            if (selected_order != null)
            {
        
                load_style_for_order(selected_order);
            }
        }
        private void Combo_style_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grid_view_styleBulletin.ItemsSource = null;
            grid_view_styleBulletin.Items.Clear();
            style_bulletin_list.Clear();
            string selected_style = (sender as ComboBox).SelectedItem as string;
            if (selected_style != null)
            {

                load_article_for_order(combo_orders.Text.ToString(), selected_style);
            }
        }
        public void get_style_bulletin(String Order, String StyleCode,String Article )
        {
            grid_view_styleBulletin.ItemsSource = null;
            grid_view_styleBulletin.Items.Clear();
            style_bulletin_list.Clear();
            var reqarm = new System.Collections.Specialized.NameValueCollection();
            reqarm.Add("order_id", Order);
            reqarm.Add("style", StyleCode);
            reqarm.Add("article", Article);

            // reqarm.Add();
            //reqarm.Add();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_style_bulletin_for_order);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                var objects = json.GetValue("Style_Bulletin"); // parse as array  
                foreach (JObject root in objects)
                {
                    String Style_ID = root.GetValue("Style ID").ToString();

                    String Style_Code = root.GetValue("StyleCode").ToString();
                    String article = root.GetValue("Article").ToString();
                    String Operartion_ID = root.GetValue("Operation ID").ToString();
                    String Operation_desc = root.GetValue("Operation Description").ToString();
                    String SMV = root.GetValue("SMV").ToString();
                    String Piece_Rate = root.GetValue("Piece Rate").ToString();
                    String opSeq = root.GetValue("Operation Sequence").ToString();
                    style_bulletin_list.Add(new style_bulletin_model(Style_ID,Order, Style_Code, article, Operartion_ID, Operation_desc, SMV, Piece_Rate, opSeq));
                }
                grid_view_styleBulletin.ItemsSource = style_bulletin_list;
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
                        ShowError("Unable to fetch Style Bulletin");
                    }
                }
            }
        }

    }
}
