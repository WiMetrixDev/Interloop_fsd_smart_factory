﻿#pragma checksum "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "234CF8AB776677506155599135A20376F022BD1DD6475D821D440EDFB60727DD"
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
using Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin;


namespace Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin {
    
    
    /// <summary>
    /// upload_style_bulletin
    /// </summary>
    public partial class upload_style_bulletin : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progress_bar;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid_packing_list;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_excel_import;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_excel_upload;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox notifier;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost popup_status;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid_excel_upload_status_list;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_popup_ok;
        
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
            System.Uri resourceLocater = new System.Uri("/Wimetrix Management System;component/spts/style%20bulletin/upload_style_bulletin" +
                    ".xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
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
            return;
            case 2:
            this.grid_packing_list = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btn_excel_import = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
            this.btn_excel_import.Click += new System.Windows.RoutedEventHandler(this.btn_excel_import_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_excel_upload = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
            this.btn_excel_upload.Click += new System.Windows.RoutedEventHandler(this.btn_excel_upload_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.notifier = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.popup_status = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 7:
            this.grid_excel_upload_status_list = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.btn_popup_ok = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\SPTS\Style Bulletin\upload_style_bulletin.xaml"
            this.btn_popup_ok.Click += new System.Windows.RoutedEventHandler(this.btn_popup_ok_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

