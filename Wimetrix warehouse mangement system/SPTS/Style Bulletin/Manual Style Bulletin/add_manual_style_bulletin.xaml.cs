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

namespace Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin.Manual_Style_Bulletin
{
    /// <summary>
    /// Interaction logic for add_manual_style_bulletin.xaml
    /// </summary>
    public partial class add_manual_style_bulletin : UserControl
    {
        List<String> operation_id_list = new List<String>();
        static List<upload_manual_style_bulletin_model> style_bulletin_list = new List<upload_manual_style_bulletin_model>();
        static List<upload_style_bulletin_model> uploading_status_list = new List<upload_style_bulletin_model>();
        int upload_count = 0;
        public add_manual_style_bulletin()
        {
            InitializeComponent();
            notification_disptachter();
            load_style_bulletin_data();
            load_operationList();
   
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
                var objects = json.GetValue("Orders") ; // parse as array  
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
        public void load_operationList()
        {
            combo_operations.Items.Clear();
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
                    operation_id_list.Add(Operation_ID);
                    combo_operations.Items.Add(Operation_Description);
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
        private void grid_packing_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btn_popup_ok_Click(object sender, RoutedEventArgs e)
        {
            if (combo_operations.Text != "" && text_opSeq.Text!="" && text_pieceRate.Text!="" && text_smv.Text!="")
            {
                grid_style_bulletin.ItemsSource = null;
                String operationID = operation_id_list[combo_operations.SelectedIndex];
                style_bulletin_list.Add(new upload_manual_style_bulletin_model(combo_orders.Text, combo_style.Text, combo_article.Text, operationID, combo_operations.Text, text_smv.Text, text_pieceRate.Text, text_opSeq.Text));
                grid_style_bulletin.ItemsSource = style_bulletin_list;
                combo_orders.Text = "";
                combo_article.Text = "";
                combo_style.Text = "";
                combo_operations.Text = "";
                text_smv.Text = "";
                text_opSeq.Text = "";
                text_pieceRate.Text = "";
                style_bulletin_popup.IsOpen = false;
            }
            else
            {
                ShowError("Please provide Operation, SMV, Piece Rate and OpSequence");
            }
        }
        private void btn_add_style_bulletin_Click(object sender, RoutedEventArgs e)
        {
            if(combo_orders.Text!=""&&combo_style.Text!="" && combo_article.Text != "")
            {
                style_bulletin_popup.IsOpen = true;


            }
            else
            {
                ShowError("Please provide the Order, StyleCode and Article");
            }
        }
        private void Btn_upload_Click(object sender, RoutedEventArgs e)
        {
            if (grid_style_bulletin.ItemsSource != null)
            {
                progress_bar.Value = 0;
                int count = grid_style_bulletin.Items.Count;
                float increament = 100 / count;
                increament = increament + 1;
                foreach (upload_manual_style_bulletin_model item in grid_style_bulletin.Items)
                {
                    var reqarm = new System.Collections.Specialized.NameValueCollection();
                    reqarm.Add("orderID", item.Order);
                    reqarm.Add("opSequence", item.opsequence);
                    reqarm.Add("styleCode", item.Style);
                    reqarm.Add("article", item.Article);
                    reqarm.Add("operationName", item.Operation_Description);
                    reqarm.Add("operationID", item.Operation_ID);
                    reqarm.Add("SMV", item.SMV);
                    reqarm.Add("pieceRate", item.PieceRate);
                    Http.http_request request = new Http.http_request();
                    Http.HttpResult result = request.send_request(reqarm, Http.api_files.upload_StyleBulletin);
                    if (result.getresultFlag())
                    {
                        //  row.Foreground = Brushes.Green;
                        upload_style_bulletin_model model = new upload_style_bulletin_model(item.Order, item.Style, item.Article, item.Operation_ID, item.Operation_Description, item.SMV, item.PieceRate, item.opsequence, "Successful");
                        //   Console.WriteLine(model);

                        uploading_status_list.Add(model);
                        upload_count++;
                    }
                    else
                    {
                        if (result.geterrorCode() == "server001")
                        {
                            ShowError("Please check IP or server");
                            break;
                        }
                        else
                        {
                            if (result.geterrorCode() == "API-001")
                            {
                                upload_style_bulletin_model model = new upload_style_bulletin_model(item.Order, item.Style, item.Article, item.Operation_ID, item.Operation_Description, item.SMV, item.PieceRate, item.opsequence, "Failed");
                                uploading_status_list.Add(model);
                                upload_count++;
                                //   row.Foreground = Brushes.Red;
                            }
                        }
                    }
                    progress_bar.Value = progress_bar.Value + increament;

                }

                if (grid_style_bulletin.Items.Count == upload_count)
                {
                    grid_excel_upload_status_list.ItemsSource = null;
                    grid_excel_upload_status_list.Items.Clear();
                    grid_excel_upload_status_list.ItemsSource = uploading_status_list;
                    grid_style_bulletin.ItemsSource = null;
                    grid_style_bulletin.Items.Clear();
                    style_bulletin_list.Clear();
                    popup_status.IsOpen = true;
                }
            }
        }
        private void btn_ok_status_popup(object sender, RoutedEventArgs e)
        {
            popup_status.IsOpen = false;
            grid_style_bulletin.ItemsSource = null;
            grid_style_bulletin.Items.Clear();
            progress_bar.Value = 0;
            grid_excel_upload_status_list.ItemsSource = null;
            grid_excel_upload_status_list.Items.Clear();
            uploading_status_list.Clear();
        }
        public void load_style_for_order(String order)
        {
            combo_style.Items.Clear();
            combo_article.Items.Clear();
            combo_style.Text="";
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
        public void load_article_for_order(String order,String StyleCode)
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
            string selected_order = (sender as ComboBox).SelectedItem as string;
            if (selected_order != null)
            {
                load_style_for_order(selected_order);
            }
        }
        private void Combo_style_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected_style = (sender as ComboBox).SelectedItem as string;
            if (selected_style != null)
            {
                load_article_for_order(combo_orders.Text.ToString(),selected_style);
            }
        }
        private void Combo_orders_TextInput(object sender, TextCompositionEventArgs e)
        {
           
        }
    }
}
