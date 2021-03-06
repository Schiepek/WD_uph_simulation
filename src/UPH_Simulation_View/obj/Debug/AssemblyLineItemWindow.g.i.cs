﻿#pragma checksum "..\..\AssemblyLineItemWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "10D5655767BF1AD41F8290A3748255CC"
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
using UPH_Simulation_View;
using UPH_Simulation_View.Properties;
using UPH_Simulation_View.Util;
using UPH_Simulation_ViewModel;


namespace UPH_Simulation_View {
    
    
    /// <summary>
    /// AssemblyLineItemWindow
    /// </summary>
    public partial class AssemblyLineItemWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\AssemblyLineItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel spnAssemblyLineConfig;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AssemblyLineItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AssemblyLineItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtboxName;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AssemblyLineItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBoxAutostacker;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\AssemblyLineItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtboxCapacity;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\AssemblyLineItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdButtons;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\AssemblyLineItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdOk;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\AssemblyLineItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOk;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\AssemblyLineItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgAssemblyItems;
        
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
            System.Uri resourceLocater = new System.Uri("/UPH_Simulation_View;component/assemblylineitemwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AssemblyLineItemWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 12 "..\..\AssemblyLineItemWindow.xaml"
            ((UPH_Simulation_View.AssemblyLineItemWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.CloseAssemblyLineItemWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.spnAssemblyLineConfig = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 3:
            this.grdName = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.txtboxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.checkBoxAutostacker = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.txtboxCapacity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.grdButtons = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.grdOk = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.btnOk = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.dgAssemblyItems = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

