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

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Upload_Parts
{
    /// <summary>
    /// Interaction logic for machine_parts_UC.xaml
    /// </summary>
    public partial class machine_parts_UC : UserControl
    {
        public machine_parts_UC()
        {
            InitializeComponent();
        }

        private void tab_upload_upload_packing_list_Click(object sender, RoutedEventArgs e)
        {
            tab_upload_upload_parts_list.Background = Brushes.Green;
            tab_view_machine_parts.Background = Brushes.DarkSlateGray;
            dock_packing_list.Children.Clear();
            Upload_parts.upload_parts_UC us = new Upload_parts.upload_parts_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_packing_list.Children.Add(us);
        }

        private void tab_view_machine_parts_Click(object sender, RoutedEventArgs e)
        {
            tab_view_machine_parts.Background = Brushes.Green;
            tab_upload_upload_parts_list.Background = Brushes.DarkSlateGray;
            dock_packing_list.Children.Clear();
            View_Parts.view_parts_list_UC us = new View_Parts.view_parts_list_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_packing_list.Children.Add(us);
        }
    }
}
