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

namespace Wimetrix_warehouse_mangement_system.SPTS.Workers
{
    /// <summary>
    /// Interaction logic for worker_UC.xaml
    /// </summary>
    public partial class worker_UC : UserControl
    {
        public worker_UC()
        {
            InitializeComponent();
        }

        private void Btn_add_operation_Click(object sender, RoutedEventArgs e)
        {
            btn_add_operation.Background = Brushes.Green;
            btn_view_operatons.Background = Brushes.DarkSlateGray;
            dock_workers.Children.Clear();
            Add_Worker.add_worker us = new Add_Worker.add_worker();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_workers.Children.Add(us);
        }

        private void Btn_view_operatons_Click(object sender, RoutedEventArgs e)
        {
            btn_view_operatons.Background = Brushes.Green;
            btn_add_operation.Background = Brushes.DarkSlateGray;
            dock_workers.Children.Clear();
            View_Worker.view_worker us = new View_Worker.view_worker();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_workers.Children.Add(us);
        }
    }
}
