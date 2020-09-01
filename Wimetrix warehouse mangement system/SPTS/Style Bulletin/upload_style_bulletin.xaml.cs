    using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin
{
    /// <summary>
    /// Interaction logic for upload_style_bulletin.xaml
    /// </summary>
    public partial class upload_style_bulletin : System.Windows.Controls.UserControl
    {
        private DataTable dataSet;
        static List<upload_style_bulletin_model> uploading_status_list = new List<upload_style_bulletin_model>();
        int upload_count = 0;
        public upload_style_bulletin()
        {
            InitializeComponent();
            notification_disptachter();
        }

        private void btn_excel_import_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Value = 0;
            OpenFileDialog dialog = new OpenFileDialog { };
            dialog.Filter = "Style Bulletin (*.xlsx;*.xls)|*.xlsx;*.xls";
            dialog.Title = "Select Excel Style Bulletin";
            dialog.ShowDialog();
            string packing_list = dialog.FileName;
            if (System.IO.File.Exists(packing_list))
            {
                try
                {
                    string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;""", packing_list);
                    //  string query = String.Format("select * from [" + textBox1.Text + "$]");
                    // Get the name of First Sheet
                    OleDbConnection con = new OleDbConnection(connectionString);
                    con.Open();
                    DataTable dtExcelSchema;
                    dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    // MessageBox.Show(sms_filename);
                    con.Close();
                    //Query to select data from excel
                    string query = String.Format("select [orderID], [Style #], [Article], [Operation ID],[Operation Description], [SMV], [PieceRate], [opsequence] from[" + SheetName + "]");
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
                    dataSet = new DataTable();
                    dataAdapter.Fill(dataSet);
                    try
                    {
                        grid_packing_list.ItemsSource = dataSet.DefaultView;
                        Console.Write(grid_packing_list.Items.Count);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                catch (Exception ex)
                {
                  //  System.Windows.MessageBox.Show(ex.Message.ToString());
                     ShowError("Excel Format not Supported.");
                    //   ShowError(ex.ToString());
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

        private void btn_excel_upload_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Value = 0;

            if (grid_packing_list.ItemsSource != null)
            {
                var rows = grid_packing_list.Items;
                //  var rows = GetDataGridRows(grid_packing_list);

                int count = dataSet.Rows.Count;
                float increament = 100 / count;
                increament = increament + 1;
                foreach (DataRow row in dataSet.Rows)
                {
                    var order_ID = row["orderID"].ToString();
                    var Operation_ID = row["Operation ID"].ToString();
                    var Operation_Description = row["Operation Description"].ToString();
                    var SMV = row["SMV"].ToString();
                    var PieceRate = row["PieceRate"].ToString();
                    var opsequence = row["opsequence"].ToString();
                    var Style = row["style #"].ToString();
                    var Article = row["Article"].ToString();
                    var reqarm = new System.Collections.Specialized.NameValueCollection();

                    reqarm.Add("orderID", order_ID.ToString());       
                    reqarm.Add("opSequence", opsequence.ToString());
                    reqarm.Add("styleCode", Style.ToString());
                    reqarm.Add("article", Article.ToString());
                    reqarm.Add("operationName", Operation_Description);
                    reqarm.Add("operationID", Operation_ID);
                    reqarm.Add("SMV", SMV);
                    reqarm.Add("pieceRate", PieceRate);

                    Http.http_request request = new Http.http_request();
                    Http.HttpResult result = request.send_request(reqarm, Http.api_files.upload_StyleBulletin);
                    if (result.getresultFlag())
                    {
                        //  row.Foreground = Brushes.Green;
                        upload_style_bulletin_model model = new upload_style_bulletin_model(order_ID, Style,Article,Operation_ID,Operation_Description,SMV,PieceRate,opsequence,"Successful");
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
                                upload_style_bulletin_model model = new upload_style_bulletin_model(order_ID, Style, Article, Operation_ID, Operation_Description, SMV, PieceRate, opsequence, "Failed");
                                    uploading_status_list.Add(model);
                                    upload_count++;
                                //   row.Foreground = Brushes.Red;
                            }
                        }
                    }
                    progress_bar.Value = progress_bar.Value + increament;

                }
            }
            if (dataSet.Rows.Count == upload_count)
            {
                grid_excel_upload_status_list.ItemsSource = null;
                grid_excel_upload_status_list.Items.Clear();
                grid_excel_upload_status_list.ItemsSource = uploading_status_list;

                popup_status.IsOpen = true;
            }
        }

        private void btn_popup_ok_Click(object sender, RoutedEventArgs e)
        {
            popup_status.IsOpen = false;
            grid_packing_list.ItemsSource = null;
            grid_packing_list.Items.Clear();
            progress_bar.Value = 0;
            grid_excel_upload_status_list.ItemsSource = null;
            grid_excel_upload_status_list.Items.Clear();
            uploading_status_list.Clear();
        }
    }
    }


