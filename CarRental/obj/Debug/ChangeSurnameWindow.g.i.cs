﻿#pragma checksum "..\..\ChangeSurnameWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E0CE08526FB7F3E6CB42CC6E3A49D94A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CarRental;
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


namespace CarRental {
    
    
    /// <summary>
    /// ChangeSurnameWindow
    /// </summary>
    public partial class ChangeSurnameWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ChangeSurnameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _loginTB;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ChangeSurnameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _newSurname;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ChangeSurnameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _passwordTB;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ChangeSurnameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _okBTN;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ChangeSurnameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _clearBTN;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ChangeSurnameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _CancelBTN;
        
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
            System.Uri resourceLocater = new System.Uri("/CarRental;component/changesurnamewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChangeSurnameWindow.xaml"
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
            this._loginTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this._newSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this._passwordTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this._okBTN = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\ChangeSurnameWindow.xaml"
            this._okBTN.Click += new System.Windows.RoutedEventHandler(this._okBTN_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this._clearBTN = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\ChangeSurnameWindow.xaml"
            this._clearBTN.Click += new System.Windows.RoutedEventHandler(this._clearBTN_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this._CancelBTN = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\ChangeSurnameWindow.xaml"
            this._CancelBTN.Click += new System.Windows.RoutedEventHandler(this._CancelBTN_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
