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

namespace Wimetrix_warehouse_mangement_system.SPTS.CutReport
{
    /// <summary>
    /// Interaction logic for cutreport_UC.xaml
    /// </summary>
    public partial class cutreport_UC : UserControl
    {
        public cutreport_UC()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_add_upload_Click(object sender, RoutedEventArgs e)
        {
            btn_add_upload.Background = Brushes.Green;
            btn_view.Background = Brushes.DarkSlateGray;
            btn_add_add.Background = Brushes.DarkSlateGray;
            dock_cutreport.Children.Clear();
            upload_cutreport us = new upload_cutreport();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_cutreport.Children.Add(us);
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            btn_view.Background = Brushes.Green;
            btn_add_upload.Background = Brushes.DarkSlateGray;
            btn_add_add.Background = Brushes.DarkSlateGray;
            dock_cutreport.Children.Clear();
            view_cutreport.view_cutreport us = new view_cutreport.view_cutreport();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_cutreport.Children.Add(us);
        }

        private void btn_add_add_Click(object sender, RoutedEventArgs e)
        {
            btn_add_add.Background = Brushes.Green;
            btn_add_upload.Background = Brushes.DarkSlateGray;
            btn_view.Background = Brushes.DarkSlateGray;
            dock_cutreport.Children.Clear();
        }
    }
}
