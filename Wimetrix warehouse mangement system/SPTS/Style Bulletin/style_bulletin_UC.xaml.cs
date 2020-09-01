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
using Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin.Manual_Style_Bulletin;

namespace Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin
{
    /// <summary>
    /// Interaction logic for style_bulletin_UC.xaml
    /// </summary>
    public partial class style_bulletin_UC : UserControl
    {
        public style_bulletin_UC()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_upload_style_Click(object sender, RoutedEventArgs e)
        {
            btn_upload_style.Background = Brushes.Green;
            btn_view_style.Background = Brushes.DarkSlateGray;
            btn_add_style.Background = Brushes.DarkSlateGray;
            dock_cutreport.Children.Clear();
            upload_style_bulletin us = new upload_style_bulletin();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_cutreport.Children.Add(us);
        }

        private void btn_add_style_Click(object sender, RoutedEventArgs e)
        {
            btn_upload_style.Background = Brushes.DarkSlateGray;
            btn_view_style.Background = Brushes.DarkSlateGray;
            btn_add_style.Background = Brushes.Green;
            dock_cutreport.Children.Clear();
           add_manual_style_bulletin  us = new add_manual_style_bulletin();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_cutreport.Children.Add(us);
        }

        private void Btn_view_style_Click(object sender, RoutedEventArgs e)
        {
            btn_upload_style.Background = Brushes.DarkSlateGray;
            btn_add_style.Background = Brushes.DarkSlateGray;
            btn_view_style.Background = Brushes.Green;
            dock_cutreport.Children.Clear();
            View_Style_Bulletin.view_style_bulletin us = new View_Style_Bulletin.view_style_bulletin();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_cutreport.Children.Add(us);
        }
    }
}
