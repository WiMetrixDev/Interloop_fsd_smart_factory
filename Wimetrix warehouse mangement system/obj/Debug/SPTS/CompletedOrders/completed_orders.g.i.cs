﻿#pragma checksum "..\..\..\..\SPTS\CompletedOrders\completed_orders.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "743907DB0A20222B1117BEE1C10685D53A8D39790462398693C55A3E08F029FD"
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
using Wimetrix_warehouse_mangement_system.SPTS.CompletedOrders;


namespace Wimetrix_warehouse_mangement_system.SPTS.CompletedOrders {
    
    
    /// <summary>
    /// completed_orders
    /// </summary>
    public partial class completed_orders : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\SPTS\CompletedOrders\completed_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_tranfer_orders;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\SPTS\CompletedOrders\completed_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid_transfer_orders_list;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\SPTS\CompletedOrders\completed_orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox notifier;
        
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
            System.Uri resourceLocater = new System.Uri("/Wimetrix Management System;component/spts/completedorders/completed_orders.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SPTS\CompletedOrders\completed_orders.xaml"
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
            this.btn_tranfer_orders = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\SPTS\CompletedOrders\completed_orders.xaml"
            this.btn_tranfer_orders.Click += new System.Windows.RoutedEventHandler(this.Btn_transfer_orders_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_transfer_orders_list = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            
            #line 22 "..\..\..\..\SPTS\CompletedOrders\completed_orders.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.selectDeselectAllClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.notifier = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

