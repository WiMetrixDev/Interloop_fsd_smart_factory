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

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal
{
    /// <summary>
    /// Interaction logic for administrative_portal.xaml
    /// </summary>
    public partial class administrative_portal : UserControl
    {
        public administrative_portal()
        {
            InitializeComponent();
        }
        private void Btn_add_asset_Click(object sender, RoutedEventArgs e)
        {
            btn_add_asset.Background = Brushes.Green;
            btn_view_assets.Background = Brushes.DarkSlateGray;
            btn_update_location.Background = Brushes.DarkSlateGray;

            dock_assets.Children.Clear();
            add_new_asset.add_new_asset us = new add_new_asset.add_new_asset();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_assets.Children.Add(us);
        }
        private void Btn_view_assets_Click(object sender, RoutedEventArgs e)
        {
            btn_add_asset.Background = Brushes.DarkSlateGray;
            btn_view_assets.Background = Brushes.Green;
            btn_update_location.Background = Brushes.DarkSlateGray;

            dock_assets.Children.Clear();
            View_Assets.view_assets_UC us = new View_Assets.view_assets_UC();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_assets.Children.Add(us);
        }
        private void Btn_update_location_Click(object sender, RoutedEventArgs e)
        {
            btn_add_asset.Background = Brushes.DarkSlateGray;
            btn_view_assets.Background = Brushes.DarkSlateGray;
            btn_update_location.Background = Brushes.Green;

            dock_assets.Children.Clear();
            Asset_Allocation.asset_allocation us = new Asset_Allocation.asset_allocation();
            us.HorizontalAlignment = HorizontalAlignment.Stretch;
            us.VerticalAlignment = VerticalAlignment.Stretch;
            dock_assets.Children.Add(us);
        }
    }
}
