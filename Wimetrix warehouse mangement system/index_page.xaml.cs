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
using System.Windows.Shapes;
using Wimetrix_warehouse_mangement_system.Properties;
using Wimetrix_warehouse_mangement_system.Warehouse_Management.Upload_Excel;

namespace Wimetrix_warehouse_mangement_system
{
    /// <summary>
    /// Interaction logic for index_page.xaml
    /// </summary>
    public partial class index_page : Window
    {
        public index_page()
        {
            InitializeComponent();          
            String user_dept = Settings.Default.user_dept;
            String user_type = Settings.Default.user_type;
            item_admin.IsEnabled = false;

            if (user_dept == "ASSET TRACKING")
            {
                if (user_type == "ADMIN")
                {
                    item_admin.IsEnabled = true;
                }
            }
        
        }
        private void item_upload_excel_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void item_upload_excel_Click(object sender, RoutedEventArgs e)
        {
           grid_main.Children.Clear();
            import_packing_list_UC us = new import_packing_list_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void index_page1_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Warehouse_Management.Dashboard.stockReport us = new Warehouse_Management.Dashboard.stockReport();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;
            Application.Current.MainWindow.Width = 600;
            Application.Current.MainWindow.Width = 800;

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Cutting_Management.Cutting_dept.cutting_UC us =  Cutting_Management.Cutting_dept.cutting_UC.Instance;
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void item_update_location_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Warehouse_Management.Update_location.update_location_UC us = new Warehouse_Management.Update_location.update_location_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            wlecome_window welcome_screen = new wlecome_window();
            welcome_screen.Show();
            this.Close();
        }
        private void item_cutreport_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            SPTS.CutReport.cutreport_UC us = new SPTS.CutReport.cutreport_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void menu_warehouse_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void menu_asset_Click(object sender, RoutedEventArgs e)
        {

        } 
        private void item_view_excel_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Warehouse_Management.view_Packing_List.view_packinglist_UC us = new Warehouse_Management.view_Packing_List.view_packinglist_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void item_assign_rfid_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Warehouse_Management.Assign_Rfid.assign_rfid us = new Warehouse_Management.Assign_Rfid.assign_rfid();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void item_orders_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            SPTS.Operations.operations_UC.operations_UC us = new SPTS.Operations.operations_UC.operations_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void item_style_bulletin_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            SPTS.Style_Bulletin.style_bulletin_UC us = new SPTS.Style_Bulletin.style_bulletin_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void item_stocking_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Warehouse_Management.Manual_Stocking.manual_stocking_UC us = new Warehouse_Management.Manual_Stocking.manual_stocking_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void Item_workers_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            SPTS.Workers.worker_UC us = new SPTS.Workers.worker_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        //Asset Tracking
        private void Item_asset_tracking_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Asset_Tracking.Asset_Track.asset_tracking_UC us = new Asset_Tracking.Asset_Track.asset_tracking_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void Item_manual_allocate_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Asset_Tracking.administrative_portal.administrative_portal us = new Asset_Tracking.administrative_portal.administrative_portal();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void Item_orders_add_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            SPTS.Orders.order_UC us = new SPTS.Orders.order_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void Item_allocation_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Warehouse_Management.Departmental_Allocation.departmental_allocation_UC us = new Warehouse_Management.Departmental_Allocation.departmental_allocation_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void Item_consumption_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Warehouse_Management.Departmental_Consumption.deparmental_consumption us = new Warehouse_Management.Departmental_Consumption.deparmental_consumption();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
        private void Item_logout_Click(object sender, RoutedEventArgs e)
        {
            Login.login login = new Wimetrix_warehouse_mangement_system.Login.login();
            Settings.Default.user_type = "";
            Settings.Default.user_dept = "";
            Settings.Default.username = "";
            Settings.Default.password = "";
            Settings.Default.Save();
            login.Show();
            this.Close();
        }

        private void item_generate_packing_list_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Warehouse_Management.Generate_Packing_List.packing_list_UC us = new Warehouse_Management.Generate_Packing_List.packing_list_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }

        private void item_transfer_rolls_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Warehouse_Management.Transfer_Rolls.transfer_rolls_UC us = new Warehouse_Management.Transfer_Rolls.transfer_rolls_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }

        private void item_roll_return_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Warehouse_Management.Roll_Return.roll_return_UC us = new Warehouse_Management.Roll_Return.roll_return_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }

        private void item_upload_parts_list_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            Asset_Tracking.Upload_Parts.machine_parts_UC us = new Asset_Tracking.Upload_Parts.machine_parts_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            grid_main.Children.Add(us);
        }
    }




}
