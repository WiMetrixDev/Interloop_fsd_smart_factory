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

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Generate_Packing_List
{
    /// <summary>
    /// Interaction logic for packing_list_UC.xaml
    /// </summary>
    public partial class packing_list_UC : UserControl
    {
        public packing_list_UC()
        {
            InitializeComponent();
        }

        private void btn_generate_packing_list_Click(object sender, RoutedEventArgs e)
        {
            btn_generate_packing_list.Background = Brushes.Green;
            btn_view_packing_list.Background = Brushes.DarkSlateGray;
            dock_packing_list.Children.Clear();
            Add_Packing_List.add_packing_list_UC us = new Add_Packing_List.add_packing_list_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_packing_list.Children.Add(us);
        }

        private void btn_Stock_out_Click(object sender, RoutedEventArgs e)
        {
            btn_view_packing_list.Background = Brushes.Green;
            btn_generate_packing_list.Background = Brushes.DarkSlateGray;
            dock_packing_list.Children.Clear();
            View_Packing_List.view_packing_list_UC us = new View_Packing_List.view_packing_list_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_packing_list.Children.Add(us);
        }
    }
}
