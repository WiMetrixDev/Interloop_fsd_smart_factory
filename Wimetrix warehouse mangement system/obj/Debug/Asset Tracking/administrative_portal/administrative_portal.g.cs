﻿#pragma checksum "..\..\..\..\Asset Tracking\administrative_portal\administrative_portal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "93C7D0A6FE2C461DF8AF470E08D74651F9CECB89312BAEFA69C0A6B016C683EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal;


namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal {
    
    
    /// <summary>
    /// administrative_portal
    /// </summary>
    public partial class administrative_portal : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Asset Tracking\administrative_portal\administrative_portal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid dock_assets;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Asset Tracking\administrative_portal\administrative_portal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_view_assets;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Asset Tracking\administrative_portal\administrative_portal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add_asset;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Asset Tracking\administrative_portal\administrative_portal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_update_location;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wimetrix Management System;component/asset%20tracking/administrative_portal/admi" +
                    "nistrative_portal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Asset Tracking\administrative_portal\administrative_portal.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dock_assets = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.btn_view_assets = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Asset Tracking\administrative_portal\administrative_portal.xaml"
            this.btn_view_assets.Click += new System.Windows.RoutedEventHandler(this.Btn_view_assets_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_add_asset = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Asset Tracking\administrative_portal\administrative_portal.xaml"
            this.btn_add_asset.Click += new System.Windows.RoutedEventHandler(this.Btn_add_asset_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_update_location = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Asset Tracking\administrative_portal\administrative_portal.xaml"
            this.btn_update_location.Click += new System.Windows.RoutedEventHandler(this.Btn_update_location_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

