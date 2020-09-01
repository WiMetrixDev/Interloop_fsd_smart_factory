using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
using Wimetrix_warehouse_mangement_system.Asset_Tracking.Add_Assets.add_new_asset;
using Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal.Add_new_Assets;
using Wimetrix_warehouse_mangement_system.Warehouse_Management.Upload_Excel;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal.add_new_asset
{
    /// <summary>
    /// Interaction logic for add_new_asset.xaml
    /// </summary>
    public partial class add_new_asset : System.Windows.Controls.UserControl
    {
        private DataTable dataSet;
        static List<uploaded_asset_model> uploading_status_list = new List<uploaded_asset_model>();
        int upload_count = 0;
        public add_new_asset()
        {
            InitializeComponent();
            notification_disptachter();
        }

        private void btn_excel_import_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Value = 0;
            OpenFileDialog dialog = new OpenFileDialog { };
            dialog.Filter = "Asset Excel List (*.xlsx;*.xls)|*.xlsx;*.xls";
            dialog.Title = "Select Asset Excel List";
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
                    string query = String.Format("select [Department],[Machine Type],[Sub Type],[Model],[Brand],[Serial No],[COO],[Supplier Name],[IGP]," +
                        "[Price],[Vendor],[YOM],[Installation Date],[Issuance To Module],[Machine ID],[Floor] from[" + SheetName + "]");
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
        //Upload Excel
        public IEnumerable<DataGridRow> GetDataGridRows(System.Windows.Controls.DataGrid grid)
        {
            Console.Write(grid.Items.Count);
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }

        }
        private void btn_excel_upload_Click(object sender, RoutedEventArgs e)
        {
            progress_bar.Value = 0;
            if (grid_packing_list.ItemsSource != null)
            {
                var rows = grid_packing_list.Items;
                upload_count = 0;
                int count = dataSet.Rows.Count;
                float increament = 100 / count;
                increament = increament + 1;
                List<asset_excel_model> asset_excelt_list = new List<asset_excel_model>();
               
                foreach (DataRow row in dataSet.Rows)
                {
                    var department = row["Department"].ToString();
                    var machine_type = row["Machine Type"].ToString();
                    var sub_type = row["Sub Type"].ToString();
                    var model = row["Model"].ToString();
                    var brand = row["Brand"].ToString();
                    var supplier_name = row["Supplier Name"].ToString();
                    var IGP = row["IGP"].ToString();
                    var price = row["Price"].ToString();
                    var vendor = row["Vendor"].ToString();
                    var YOM = row["YOM"].ToString();    
                    var installation_date = row["Installation Date"].ToString();
                    var module = row["Issuance To Module"].ToString();             
                    var machine_id = row["Machine ID"].ToString();
                    var serial_no = row["Serial No"].ToString();
                    var coo = row["COO"].ToString();
                    var floor = row["Floor"].ToString();
                    String rfid = "";
                    if (machine_id.Contains("-"))
                    {
                        rfid = machine_id;
                        try
                        {
                            String[] rfid_code = rfid.Split('-');
                            rfid = String.Format("0" + rfid_code[0] + "00" + rfid_code[1]);
                        }catch(Exception ex)
                        {

                        }
                    }
                    if (machine_type != "")
                    {
                        asset_excelt_list.Add(new asset_excel_model(department, machine_type, sub_type, model, brand, supplier_name, IGP, price, vendor, YOM, installation_date, module, machine_id, serial_no, coo, floor, rfid));

                    }


                }

                if (asset_excelt_list.Count > 0)
                {
                    var packing_json = JsonConvert.SerializeObject(asset_excelt_list);
                    var reqarm = new System.Collections.Specialized.NameValueCollection();
                    reqarm.Add("PackingList", packing_json);
                    Http.http_request request = new Http.http_request();
                    Http.HttpResult result = request.send_request(reqarm, Http.api_files.upload_asset);
                    if (result.getresultFlag())
                    {
                        showSuccess("Asset list has been uploaded");
                        grid_excel_upload_status_list.ItemsSource = null;
                    }
                    else
                    {
                        if (result.geterrorCode() == "API-001")
                        {
                            JObject json = result.getjsonResult();
                            String error_code = json.GetValue("Error_No").ToString();
                            if (error_code == "2601")
                            {
                                ShowError("Duplicate Asset list");
                            }

                        }
                        else
                        {

                            ShowError("Unable to upload asset list" + result.getDescription());
                        }

                    }
                }
                //if (dataSet.Rows.Count == upload_count)
                //{

                //    grid_excel_upload_status_list.ItemsSource = null;
                //    grid_excel_upload_status_list.Items.Clear();
                //    grid_excel_upload_status_list.ItemsSource = uploading_status_list;

                //    popup_status.IsOpen = true;
                //}
            }
        }
        public void showLoader()
        {
            loader.IsOpen = true;
        }
        public void hideLoader()
        {
            loader.IsOpen = false;
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
