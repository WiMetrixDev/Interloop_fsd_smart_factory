using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Upload_Excel
{
    /// <summary>
    /// Interaction logic for import_packing_list_UC.xaml
    /// </summary>
    public partial class import_packing_list_UC : System.Windows.Controls.UserControl
    {
        private DataTable dataSet;
        static List<uploaded_excel_model> uploading_status_list = new List<uploaded_excel_model>();
        static List<upload_excel_model> packing_list = new List<upload_excel_model>();
        int upload_count = 0;

        public import_packing_list_UC()
        {
            InitializeComponent();
            notification_disptachter();
        }
        //Import Excel 
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
                try { 
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
                    string query = String.Format("select [ERP Item Code],[ERP Item Description],[IGP Date],[IGP No],[Internal Order No],[Customer Name],[Customer code]	," +
                        "[DCN No],[Vendor Name],[Fabric Type],[Yarn Supplier],[Yarn Lot No],[Fabric Lot No],[Color Code],[GSM],[Fabric Width],[Weight (Kgs)],[Pcs (No)]," +
                        "[Roll Identification (Rack, Locator, Bin)],[Transaction Type],[Roll ID],[Fabric Length],[Goods code],[Supplier Lot],[Fabric Content],[Supplier Roll ID] from[" + SheetName + "]");
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query,connectionString);
                    dataSet = new DataTable();
                    dataAdapter.Fill(dataSet);
                    try
                    {
                        grid_packing_list.ItemsSource = dataSet.DefaultView;
                        Console.Write(grid_packing_list.Items.Count);                   
                    }
                    catch(Exception ex)
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
            packing_list.Clear();
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
                    var ERP_Item_Code = row["ERP Item Code"].ToString();
                    var ERP_Item_Description = row["ERP Item Description"].ToString();
                    var IGP_Date = row["IGP Date"].ToString();
                    var IGP_No = row["IGP No"].ToString();
                    var Internal_Order_No = row["Internal Order No"].ToString();
                    var Customer_Name = row["Customer Name"].ToString();
                    var Customer_code = row["Customer code"].ToString();
                    var DCN_No = row["DCN No"].ToString();
                    var Vendor_Name = row["Vendor Name"].ToString();
                    var Fabric_Type = row["Fabric Type"].ToString();
                    var Yarn_Supplier = row["Yarn Supplier"].ToString();
                    var Yarn_Lot_No = row["Yarn Lot No"].ToString();
                    var Fabric_Lot_No = row["Fabric Lot No"].ToString();
                    var Color_Code = row["Color Code"].ToString();
                    var GSM = row["GSM"].ToString();
                    var Fabric_width = row["Fabric Width"].ToString();
                    var Weight = row["Weight (Kgs)"].ToString();
                    var Pcs = row["Pcs (No)"].ToString();
                    var Roll_Identification = row["Roll Identification (Rack, Locator, Bin)"].ToString();
                    var Transaction_Type = row["Transaction Type"].ToString();
                    var Roll_ID = row["Roll ID"].ToString();
                    var Fabric_length = row["Fabric Length"].ToString();
                    var goods_code = row["Goods code"].ToString();
                    var supplier_lot = row["Supplier Lot"].ToString();
                    var fabric_content = row["Fabric Content"].ToString();
                    var supplier_roll_ID = row["Supplier Roll ID"].ToString();
                    //var reqarm = new System.Collections.Specialized.NameValueCollection();
                    //reqarm.Add("item_code", ERP_Item_Code.ToString());
                    //reqarm.Add("item_description", ERP_Item_Description.ToString());
                    String[] igp_date = IGP_Date.ToString().Split(' ');
                    //reqarm.Add("igp_date", igp_date[0]);
                    //reqarm.Add("igp_no", IGP_No.ToString());
                    //reqarm.Add("order_no", Internal_Order_No.ToString());
                    //reqarm.Add("customer_name", Customer_Name.ToString());
                    //reqarm.Add("customer_code", Customer_code.ToString());
                    //reqarm.Add("dcn_no", DCN_No.ToString());
                    //reqarm.Add("vendor_name", Vendor_Name.ToString());
                    //reqarm.Add("fabric_type", Fabric_Type.ToString());
                    //reqarm.Add("supplier", Yarn_Supplier.ToString());
                    //reqarm.Add("yarn_no", Yarn_Lot_No.ToString());
                    //reqarm.Add("fabric_no", Fabric_Lot_No.ToString());
                    //reqarm.Add("color_code", Color_Code.ToString());
                    //reqarm.Add("gsm", GSM.ToString());
                    //reqarm.Add("fabric_length", Fabric_length.ToString());
                    //reqarm.Add("weight", Weight.ToString());
                    //reqarm.Add("pcs", Pcs.ToString());
                    //reqarm.Add("roll_identification", Roll_Identification.ToString());
                    //reqarm.Add("transaction_type", Transaction_Type.ToString());
                    //reqarm.Add("roll_id", Roll_ID.ToString());
                    //reqarm.Add("goods_code", goods_code.ToString());
                    //reqarm.Add("fabric_width", Fabric_width.ToString());

                    packing_list.Add(new upload_excel_model(ERP_Item_Code.ToString(),
                         ERP_Item_Description.ToString(),
                         igp_date[0],
                         IGP_No.ToString(),
                         Internal_Order_No.ToString(),
                         Customer_Name.ToString(),
                         Customer_code.ToString(),
                         DCN_No.ToString(),
                         Vendor_Name.ToString(),
                         Fabric_Type.ToString(),
                         Yarn_Supplier.ToString(),
                         Yarn_Lot_No.ToString(),
                         Fabric_Lot_No.ToString(),
                         Color_Code.ToString(),
                         GSM.ToString(),
                         Fabric_length.ToString(),
                         Weight.ToString(),
                         Pcs.ToString(),
                         Roll_Identification.ToString(),
                         Transaction_Type.ToString(),
                         Roll_ID.ToString(),
                         Fabric_width.ToString(),
                         goods_code.ToString(),
                         supplier_lot.ToString(), 
                         fabric_content,
                         supplier_roll_ID
                         )) ;
                    progress_bar.Value = progress_bar.Value + increament;
                    
                }
                var packing_json = JsonConvert.SerializeObject(packing_list);
                var reqarm = new System.Collections.Specialized.NameValueCollection();
                int flag_force_upload = 0;
                if (check_force_upload.IsChecked==true)
                {
                    flag_force_upload = 1;
                }

                reqarm.Add("packing_list", packing_json);
                reqarm.Add("flag", flag_force_upload.ToString());

                Http.http_request request = new Http.http_request();
                Http.HttpResult result = request.send_request_for_error_codes_in_return(reqarm, Http.api_files.upload_excel_file);
                if (result.getresultFlag())
                {
                    JObject json = result.getjsonResult();
                    var objects = JArray.Parse(json.GetValue("Responses").ToString()); // parse as array  
                    foreach (JObject root in objects)
                    {

                        String Internal_Order_No = root.GetValue("Order").ToString();
                        String Weight = root.GetValue("Weight").ToString();
                        String Fabric_Lot_No = root.GetValue("Fabric Lot").ToString();
                        String packing_list_code = root.GetValue("packing_list_code").ToString();
                        String status = root.GetValue("Error_Description").ToString();

                        uploaded_excel_model model = new uploaded_excel_model(Internal_Order_No, Weight, Fabric_Lot_No, packing_list_code, "Successfully uploaded");
                        Console.WriteLine(model);
                        uploading_status_list.Add(model);           

                    }
                    grid_excel_upload_status_list.ItemsSource = uploading_status_list;
                    popup_status.IsOpen = true;
                  
                }
                else
                {
                    if (result.geterrorCode() == "server001")
                    {
                        ShowError("Please Check IP Or Server");
                    }
                    else
                    {
                        if (result.geterrorCode() == "API-Duplicate")
                        {
                            ShowError("Duplicate packing list");
                            grid_packing_list.ItemsSource = null;
                            grid_packing_list.Items.Clear();
                            progress_bar.Value = 0;
                        }
                        else
                        {
                            ShowError(result.getDescription());
                        }
                    }
                }

            }
            else
            {
                ShowError("Select packing list");
            }

            check_force_upload.IsChecked = false;
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
