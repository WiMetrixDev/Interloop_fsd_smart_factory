﻿#pragma checksum "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F088CF6D69C1EE1E1F3FE7B63AB061C4EDAC8CDAAE78143C382E8ADB7422FD1F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking.Stock_Out;


namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking.Stock_Out {
    
    
    /// <summary>
    /// stock_out_uc
    /// </summary>
    public partial class stock_out_uc : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progress_bar;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid_out;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_stock_out;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox notifier;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_orders;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_load;
        
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
            System.Uri resourceLocater = new System.Uri("/Wimetrix Management System;component/warehouse%20management/manual%20stocking/st" +
                    "ock%20out/stock_out_uc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml"
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
            this.progress_bar = ((System.Windows.Controls.ProgressBar)(target));
            
            #line 11 "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml"
            this.progress_bar.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.progress_bar_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_out = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btn_stock_out = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml"
            this.btn_stock_out.Click += new System.Windows.RoutedEventHandler(this.btn_stock_out_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.notifier = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.combo_orders = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btn_load = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\..\..\Warehouse Management\Manual Stocking\Stock Out\stock_out_uc.xaml"
            this.btn_load.Click += new System.Windows.RoutedEventHandler(this.btn_load_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

