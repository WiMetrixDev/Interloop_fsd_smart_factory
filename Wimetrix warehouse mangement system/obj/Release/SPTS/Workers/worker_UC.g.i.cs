﻿#pragma checksum "..\..\..\..\SPTS\Workers\worker_UC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4074084D40C6C93470A0DD8F19A5BC43925EEB52C37D535C9C1E108C5856F63A"
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
using Wimetrix_warehouse_mangement_system.SPTS.Workers;


namespace Wimetrix_warehouse_mangement_system.SPTS.Workers {
    
    
    /// <summary>
    /// worker_UC
    /// </summary>
    public partial class worker_UC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\SPTS\Workers\worker_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid dock_workers;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\SPTS\Workers\worker_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_view_operatons;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\SPTS\Workers\worker_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add_operation;
        
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
            System.Uri resourceLocater = new System.Uri("/Wimetrix Management System;component/spts/workers/worker_uc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SPTS\Workers\worker_UC.xaml"
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
            this.dock_workers = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.btn_view_operatons = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\SPTS\Workers\worker_UC.xaml"
            this.btn_view_operatons.Click += new System.Windows.RoutedEventHandler(this.Btn_view_operatons_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_add_operation = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\SPTS\Workers\worker_UC.xaml"
            this.btn_add_operation.Click += new System.Windows.RoutedEventHandler(this.Btn_add_operation_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

