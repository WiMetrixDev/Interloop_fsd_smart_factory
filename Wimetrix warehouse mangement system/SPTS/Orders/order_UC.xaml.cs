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

namespace Wimetrix_warehouse_mangement_system.SPTS.Orders
{
    /// <summary>
    /// Interaction logic for order_UC.xaml
    /// </summary>
    public partial class order_UC : UserControl
    {
        public order_UC()
        {
            InitializeComponent();
        }

        private void Btn_add_orders_Click(object sender, RoutedEventArgs e)
        {
            btn_add_orders.Background = Brushes.Green;
            btn_view_orders.Background = Brushes.DarkSlateGray;
            dock_orders.Children.Clear();
            Add_Order.add_order us = new Add_Order.add_order();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_orders.Children.Add(us);
        }
    }
}
