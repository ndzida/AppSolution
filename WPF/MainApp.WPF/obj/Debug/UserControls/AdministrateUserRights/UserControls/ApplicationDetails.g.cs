﻿#pragma checksum "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2C0C9C62CFE796371893B49E61C555C8A7B563D88B56E795E584ECFA7B35D9E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MainApp.WPF.Converters;
using MainApp.WPF.UserControls.AdministrateUserRights.UserControls;
using MainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands;
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


namespace MainApp.WPF.UserControls.AdministrateUserRights.UserControls {
    
    
    /// <summary>
    /// ApplicationDetails
    /// </summary>
    public partial class ApplicationDetails : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock headerDetails;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock errorApplicationName;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNew;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEdit;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
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
            System.Uri resourceLocater = new System.Uri("/MainApp.WPF;component/usercontrols/administrateuserrights/usercontrols/applicati" +
                    "ondetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
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
            
            #line 15 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.NewCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.NewCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 16 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.SaveCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SaveCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 17 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.EditCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.EditCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 18 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.DeleteCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\..\..\UserControls\AdministrateUserRights\UserControls\ApplicationDetails.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeleteCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.headerDetails = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.errorApplicationName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btnNew = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btnEdit = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
