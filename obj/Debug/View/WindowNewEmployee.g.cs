﻿#pragma checksum "..\..\..\View\WindowNewEmployee.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "68EFB7046315736892A4F241C3D70E6BD1FE28DD7FEFA999A1D9D5EE69598DF7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using Workers.View;


namespace Workers.View {
    
    
    /// <summary>
    /// WindowNewEmployee
    /// </summary>
    public partial class WindowNewEmployee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\View\WindowNewEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbId;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\View\WindowNewEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbLastName;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\WindowNewEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbFirstName;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\View\WindowNewEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbRole;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\View\WindowNewEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbBirthday;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\View\WindowNewEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ClBirthday;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\View\WindowNewEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtSave;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\View\WindowNewEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtCansel;
        
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
            System.Uri resourceLocater = new System.Uri("/Workers;component/view/windownewemployee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\WindowNewEmployee.xaml"
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
            this.TbId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TbLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TbFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CbRole = ((System.Windows.Controls.ComboBox)(target));
            
            #line 54 "..\..\..\View\WindowNewEmployee.xaml"
            this.CbRole.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbRole_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbBirthday = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\..\View\WindowNewEmployee.xaml"
            this.tbBirthday.IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.tbBirthday_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ClBirthday = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.BtSave = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\View\WindowNewEmployee.xaml"
            this.BtSave.Click += new System.Windows.RoutedEventHandler(this.BtSave_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtCansel = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

