﻿#pragma checksum "..\..\..\..\..\Asset Tracking\Upload Parts\machine_parts_UC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D5C86D3691CDA4C76437EFA469DCD07E2FB4B5F910FE98C01CDB7BBB71433A4D"
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
using Wimetrix_warehouse_mangement_system.Asset_Tracking.Upload_Parts;


namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Upload_Parts {
    
    
    /// <summary>
    /// machine_parts_UC
    /// </summary>
    public partial class machine_parts_UC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\..\Asset Tracking\Upload Parts\machine_parts_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid dock_packing_list;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\Asset Tracking\Upload Parts\machine_parts_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tab_upload_upload_parts_list;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Asset Tracking\Upload Parts\machine_parts_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tab_view_machine_parts;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Asset Tracking\Upload Parts\machine_parts_UC.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Wimetrix Management System;component/asset%20tracking/upload%20parts/machine_par" +
                    "ts_uc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Asset Tracking\Upload Parts\machine_parts_UC.xaml"
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
            this.dock_packing_list = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.tab_upload_upload_parts_list = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\..\Asset Tracking\Upload Parts\machine_parts_UC.xaml"
            this.tab_upload_upload_parts_list.Click += new System.Windows.RoutedEventHandler(this.tab_upload_upload_packing_list_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tab_view_machine_parts = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\..\Asset Tracking\Upload Parts\machine_parts_UC.xaml"
            this.tab_view_machine_parts.Click += new System.Windows.RoutedEventHandler(this.tab_view_machine_parts_Click);
            
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

