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

namespace Wimetrix_warehouse_mangement_system
{
    /// <summary>
    /// Interaction logic for wlecome_window.xaml
    /// </summary>
    public partial class wlecome_window : Window
    {
        public wlecome_window()
        {
            InitializeComponent();
            String user_dept = Settings.Default.user_dept;
            String user_type = Settings.Default.user_type;


            if (user_dept == "ASSET TRACKING")
            {
                btn_asset.IsEnabled = true;
            }
            if (user_dept == "CUTTING")
            {
                btn_cutting.IsEnabled = true;
            }
            if (user_dept == "WAREHOUSE")
            {
                btn_warehouse.IsEnabled = true;
            }
            if (user_dept == "PRODUCTION TRACKING")
            {
                btn_spts.IsEnabled = true;
            }
        }

        private void btn_warehouse_Click(object sender, RoutedEventArgs e)
        {

            index_page index_page = new index_page();
            index_page.menu_warehouse.IsEnabled = true;
            index_page.grid_main.Children.Clear();
            Warehouse_Management.Dashboard.stockReport us = new Warehouse_Management.Dashboard.stockReport();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            index_page.grid_main.Children.Add(us);

            index_page.Show();
            this.Close();
        }

        private void btn_cutting_Click(object sender, RoutedEventArgs e)
        {
            index_page index_page = new index_page();
            index_page.menu_cutting.IsEnabled = true;
            index_page.grid_main.Children.Clear();
           
            Cutting_Management.Cutting_dept.cutting_UC us = Cutting_Management.Cutting_dept.cutting_UC.Instance;
            us.destroy();
            us = Cutting_Management.Cutting_dept.cutting_UC.Instance;
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            us.connect();
            index_page.grid_main.Children.Add(us);
            index_page.Show();
            this.Close();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            this.Close();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            index_page index_page = new index_page();
            index_page.menu_Spts.IsEnabled = true;
            index_page.Show();
            this.Close();
        }

        private void Btn_asset_Click(object sender, RoutedEventArgs e)
        {
            index_page index_page = new index_page();
            index_page.menu_asset.IsEnabled = true;
            index_page.Show();
            this.Close();
        }
    }
}
