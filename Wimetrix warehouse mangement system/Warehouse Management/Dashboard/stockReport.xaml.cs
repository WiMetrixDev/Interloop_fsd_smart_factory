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

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Dashboard
{
    /// <summary>
    /// Interaction logic for stockReport.xaml
    /// </summary>
    public partial class stockReport : UserControl
    {
        public stockReport()
        {
            InitializeComponent();
            Consumo consumo = new Consumo();
            notification_disptachter();
            DataContext = new ConsumoViewModel(consumo);
            get_Departmental_stock_summary();
           
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

        public void get_Departmental_stock_summary()
        {

            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.departmental_stock_summary);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();
                
                var objects = JArray.Parse(json.GetValue("Dept Summary").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String location = root.GetValue("Location Id").ToString();
                    String weight = root.GetValue("Total Weight").ToString();
                    switch (location)
                    {
                        case "101":
                            text_loading_dock_weight.Text = weight +" KG";
                            break;
                        
                        case "102":
                            text_warehouse_weight.Text = weight + " KG";
                            break;

                        case "103":
                            text_cutting_wip.Text = weight + " KG";
                            break;

                        case "104":
                            text_sampling_wip.Text = weight + " KG";
                            break;

                        case "105":
                            text_training_wip.Text = weight + " KG";
                            break;

                        case "106":
                            text_sewing_wip.Text = weight + " KG";
                            break;

                        default:   
                            
                            break;
                    }


                }
                get_Processing_summary();

            }
            else
            {
                if (result.geterrorCode() == "server001")
                {
                    ShowError("Please Check IP Or Server");
                }
            }
        
    }

        public void get_Processing_summary()
        {

            var reqarm = new System.Collections.Specialized.NameValueCollection();
            Http.http_request request = new Http.http_request();
            Http.HttpResult result = request.send_request(reqarm, Http.api_files.stock_Out_summary);
            if (result.getresultFlag())
            {
                JObject json = result.getjsonResult();

                var objects = JArray.Parse(json.GetValue("Dept Summary").ToString()); // parse as array  
                foreach (JObject root in objects)
                {
                    String location = root.GetValue("Location Id").ToString();
                    String weight = root.GetValue("Total Weight").ToString();
                    switch (location)
                    {

                        case "110":
                            text_cutting_consumption.Text = weight + " KG";
                            break;

                        case "111":
                            text_sampling_consumption.Text = weight + " KG";
                            break;

                        case "112":
                            text_training_consumption.Text = weight + " KG";
                            break;

                        case "113":
                            text_sewing_consumption.Text = weight + " KG";
                            break;


                        default:

                            break;
                    }


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


        private void Btn_reload_Click(object sender, RoutedEventArgs e)
        {
            get_Departmental_stock_summary();
        }
    }
    internal class ConsumoViewModel
    {
        public List<Consumo> Consumo { get; private set; }

        public ConsumoViewModel(Consumo consumo)
        {
            Consumo = new List<Consumo>();
            Consumo.Add(consumo);
        }
    }

    internal class Consumo
    {
        public string Titulo { get; private set; }
        public int Porcentagem { get; private set; }

        public Consumo()
        {
            Titulo = "Consumo Atual";
            Porcentagem = CalcularPorcentagem();
        }

        private int CalcularPorcentagem()
        {
            return 47; //Calculo da porcentagem de consumo
        }
    }
}
