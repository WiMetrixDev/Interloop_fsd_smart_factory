﻿#pragma checksum "..\..\..\..\..\..\SPTS\Orders\Add Order\add_order.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FC1FB1201D1EFBF7BC73CD3F5A41AF617E9BDDF7B40D0CAD45012158CC464420"
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
using Wimetrix_warehouse_mangement_system.SPTS.Orders.Add_Order;


namespace Wimetrix_warehouse_mangement_system.SPTS.Orders.Add_Order {
    
    
    /// <summary>
    /// add_order
    /// </summary>
    public partial class add_order : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\..\SPTS\Orders\Add Order\add_order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_upload_order;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\..\SPTS\Orders\Add Order\add_order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox notifier;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\..\SPTS\Orders\Add Order\add_order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_orders;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\..\SPTS\Orders\Add Order\add_order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_style;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\SPTS\Orders\Add Order\add_order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_article;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\..\SPTS\Orders\Add Order\add_order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_size;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\..\SPTS\Orders\Add Order\add_order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_color;
        
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
            System.Uri resourceLocater = new System.Uri("/Wimetrix Management System;component/spts/orders/add%20order/add_order.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\SPTS\Orders\Add Order\add_order.xaml"
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
            this.btn_upload_order = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\..\..\SPTS\Orders\Add Order\add_order.xaml"
            this.btn_upload_order.Click += new System.Windows.RoutedEventHandler(this.Btn_upload_order_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.notifier = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.combo_orders = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.text_style = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.text_article = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.text_size = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.text_color = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

