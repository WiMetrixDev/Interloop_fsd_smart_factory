using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Wimetrix_warehouse_mangement_system.SPTS.CompletedOrders
{
    /// <summary>
    /// Interaction logic for transfer_orders.xaml
    /// </summary>
    public partial class completed_orders : UserControl
    {

        static ObservableCollection<completed_orders_model> transfer_order_list = new ObservableCollection<completed_orders_model>();

        private bool isAllSelected;

        public completed_orders()
        {

            isAllSelected = false;

            InitializeComponent();
            notification_disptachter();
            getOrderList();

        }

        private void getOrderList()
        {
            grid_transfer_orders_list.ItemsSource = null;
            grid_transfer_orders_list.Items.Clear();
            transfer_order_list.Clear();

            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.get_orders_list_for_transfer);

            if (result.getresultFlag())
            {

                JObject json = result.getjsonResult();
                var objects = json.GetValue("Orders"); // parse as array  

                foreach (JObject root in objects)
                {

                    bool isSelected = false;
                    String orderID = root.GetValue("orderID").ToString();
                    String styleCode = root.GetValue("styleCode").ToString();
                    String Article = root.GetValue("Article").ToString();
                    int TotalOperations = int.Parse(root.GetValue("TotalOperations").ToString());
                    int CompletedOperations = int.Parse(root.GetValue("CompletedOperations").ToString());
                    String CompletePercentage = root.GetValue("CompletePercentage").ToString();

                    transfer_order_list.Add(new completed_orders_model(isSelected, orderID, styleCode, Article, TotalOperations, CompletedOperations, CompletePercentage));

                }

                grid_transfer_orders_list.ItemsSource = transfer_order_list;

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

        private void Btn_transfer_orders_Click(object sender, RoutedEventArgs e)
        {

            if (transfer_order_list.Count > 0)
            {

                DataGrid ThisGrid = this.grid_transfer_orders_list;

                transfer_order_list.ToList().ForEach(current_order =>
                {

                    if (current_order.isSelected)
                    {

                        var reqarm = new System.Collections.Specialized.NameValueCollection();
                        reqarm.Add("order_id", current_order.orderID);
                        reqarm.Add("style_code", current_order.styleCode);
                        reqarm.Add("article", current_order.Article);

                        Http.http_request request = new Http.http_request();
                        Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.transfer_orders_for_order_style_article);
                        current_order.isTransfered = result.getresultFlag();

                    }

                });

                ThisGrid.Items.Refresh();
                ThisGrid.CommitEdit();
                showSuccess("Order Transfer Finished!");

            }
            else
            {
                ShowError("No Rows Selected!");
            }

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGrid ThisGrid = (DataGrid)sender;
            completed_orders_model item = ThisGrid.SelectedItem as completed_orders_model;

            if (item != null)
            {

                transfer_order_list.ToList().ForEach(order => {
                    if (order.Equals(item))
                    {
                        order.isSelected = !item.isSelected;
                    }
                });

                ThisGrid.Items.Refresh();
                ThisGrid.CommitEdit();

            }

        }

        private void selectDeselectAllClick(object sender, RoutedEventArgs e)
        {

            isAllSelected = !isAllSelected;
            transfer_order_list.ToList().ForEach(order =>
            {
                order.isSelected = isAllSelected;
            });

            DataGrid ThisGrid = (DataGrid) this.grid_transfer_orders_list;

            ThisGrid.CancelEdit();
            ThisGrid.Items.Refresh();
            ThisGrid.CommitEdit();

        }
    }
}
