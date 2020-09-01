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

namespace Wimetrix_warehouse_mangement_system.SPTS.Operations.operations_UC
{
    /// <summary>
    /// Interaction logic for operations_UC.xaml
    /// </summary>
    public partial class operations_UC : UserControl
    {
        public operations_UC()
        {
            InitializeComponent();
        }

        private void Btn_add_operation_Click(object sender, RoutedEventArgs e)
        {
            btn_add_operation.Background = Brushes.Green;
            btn_view_operatons.Background = Brushes.DarkSlateGray;
            dock_operations.Children.Clear();
            Add_operation.add_operation us = new Add_operation.add_operation();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_operations.Children.Add(us);

        }

        private void Btn_view_operatons_Click(object sender, RoutedEventArgs e)
        {
            btn_view_operatons.Background = Brushes.Green;
            btn_add_operation.Background = Brushes.DarkSlateGray;
            dock_operations.Children.Clear();
            View_operations.view_operations us = new View_operations.view_operations();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_operations.Children.Add(us);
        }

        private void Btn_view_operatons_Click_1(object sender, RoutedEventArgs e)
        {
            btn_view_operatons.Background = Brushes.Green;
            btn_add_operation.Background = Brushes.DarkSlateGray;
            dock_operations.Children.Clear();
            View_operations.view_operations us = new View_operations.view_operations();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_operations.Children.Add(us);
        }
    }
}
