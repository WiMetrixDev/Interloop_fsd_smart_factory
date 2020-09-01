using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Upload_Parts.Upload_parts
{
    /// <summary>
    /// Interaction logic for upload_parts_UC.xaml
    /// </summary>
    public partial class upload_parts_UC : System.Windows.Controls.UserControl
    {
        private DataTable dataSet;
        static List<parts_model> parts_list = new List<parts_model>();
        int upload_count = 0;
        public upload_parts_UC()
        {
            InitializeComponent();
            notification_disptachter();
        }
        private void btn_excel_import_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Value = 0;
            OpenFileDialog dialog = new OpenFileDialog { };
            dialog.Filter = "Packing List (*.xlsx;*.xls)|*.xlsx;*.xls";
            dialog.Title = "Select Excel Packing List";
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
                    string query = String.Format("select [Item],[Description],[Organization],[UOM],[Quantity] from[" + SheetName + "]");
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
                    System.Windows.MessageBox.Show(ex.Message.ToString());
                    ShowError("Excel Format Not Supported.");
                    //   ShowError(ex.ToString());
                }
            }
        }
        private void btn_excel_upload_Click(object sender, RoutedEventArgs e)
        {
            parts_list.Clear();
            progress_bar.Value = 0;
            if (grid_packing_list.ItemsSource != null)
            {
                var rows = grid_packing_list.Items;
                upload_count = 0;
                int count = dataSet.Rows.Count;
                float increament = 100 / count;
                increament = increament + 1;
                foreach (DataRow row in dataSet.Rows)
                {
                    var Item = row["Item"].ToString().Trim().ToUpper();
                    var Description = row["Description"].ToString();
                    var Organization = row["Organization"].ToString();
                    var UOM = row["UOM"].ToString();
                    var Quantity = row["Quantity"].ToString();
                    if(Item!="" && Description != "")
                    {
                        parts_list.Add(new parts_model("", Item, Description, Organization, UOM, Quantity));
                        progress_bar.Value = progress_bar.Value + increament;
                    }
                }
                var packing_json = JsonConvert.SerializeObject(parts_list);
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                reqarm.Add("packing_list", packing_json);
                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.insert_part_list);
                if (result.getresultFlag())
                {
                    showSuccess("Machine parts list has been uploaded");
                    grid_packing_list.ItemsSource = null;
                    parts_list.Clear();
                    JObject json = result.getjsonResult();

                    //var objects = JArray.Parse(json.GetValue("Responses").ToString()); // parse as array  
                    //foreach (JObject root in objects)
                    //{

                    //    //String Internal_Order_No = root.GetValue("Order").ToString();
                    //    //String Weight = root.GetValue("Weight").ToString();
                    //    //String Fabric_Lot_No = root.GetValue("Fabric Lot").ToString();
                    //    //String packing_list_code = root.GetValue("packing_list_code").ToString();
                    //    //String status = root.GetValue("Error_Description").ToString();

                    //    //uploaded_excel_model model = new uploaded_excel_model(Internal_Order_No, Weight, Fabric_Lot_No, packing_list_code, "Successfully uploaded");
                    //    //Console.WriteLine(model);
                    //    //uploading_status_list.Add(model);

                    //}
                }
                else
                {
                    if (result.geterrorCode() == "server001")
                    {
                        ShowError("Please Check IP Or Server");
                    }
                    else
                    {
                        ShowError(result.getDescription());
                    }
                }

            }
            else
            {
                ShowError("Select Parts list");
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
    }
}
