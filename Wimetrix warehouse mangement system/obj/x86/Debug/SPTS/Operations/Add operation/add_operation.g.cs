﻿#pragma checksum "..\..\..\..\..\..\SPTS\Operations\Add operation\add_operation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6A99D28CA005D901BE181CBF9FA7C5A5F4ED18159C3ABA131C31575C6BE8C943"
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
using Wimetrix_warehouse_mangement_system.SPTS.Operations.Add_operation;


namespace Wimetrix_warehouse_mangement_system.SPTS.Operations.Add_operation {
    
    
    /// <summary>
    /// add_operation
    /// </summary>
    public partial class add_operation : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\..\SPTS\Operations\Add operation\add_operation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_upload_order;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\..\SPTS\Operations\Add operation\add_operation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox notifier;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\..\SPTS\Operations\Add operation\add_operation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_operation;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\..\SPTS\Operations\Add operation\add_operation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_section;
        
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
            System.Uri resourceLocater = new System.Uri("/Wimetrix Management System;component/spts/operations/add%20operation/add_operati" +
                    "on.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\SPTS\Operations\Add operation\add_operation.xaml"
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
            
            #line 10 "..\..\..\..\..\..\SPTS\Operations\Add operation\add_operation.xaml"
            this.btn_upload_order.Click += new System.Windows.RoutedEventHandler(this.Btn_upload_operation_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.notifier = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.text_operation = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.text_section = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

