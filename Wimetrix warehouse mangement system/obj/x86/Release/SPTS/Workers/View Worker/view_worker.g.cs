﻿#pragma checksum "..\..\..\..\..\..\SPTS\Workers\View Worker\view_worker.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "655D935DE8E23982F91176CE959891BB4CEC9F495435A56F674CB5E552584C12"
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
using Wimetrix_warehouse_mangement_system.SPTS.Workers.View_Worker;


namespace Wimetrix_warehouse_mangement_system.SPTS.Workers.View_Worker {
    
    
    /// <summary>
    /// view_worker
    /// </summary>
    public partial class view_worker : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\..\SPTS\Workers\View Worker\view_worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progress_bar;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\..\SPTS\Workers\View Worker\view_worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid_workers_list;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\..\SPTS\Workers\View Worker\view_worker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_load_workers;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\..\SPTS\Workers\View Worker\view_worker.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Wimetrix Management System;component/spts/workers/view%20worker/view_worker.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\SPTS\Workers\View Worker\view_worker.xaml"
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
            this.grid_workers_list = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btn_load_workers = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\..\SPTS\Workers\View Worker\view_worker.xaml"
            this.btn_load_workers.Click += new System.Windows.RoutedEventHandler(this.Btn_load_workers_Click);
            
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

