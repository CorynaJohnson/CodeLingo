﻿#pragma checksum "..\..\..\Quiz2\Page3.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "43C5142D0B19E7CDEFC9DA57C09A0B7A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CodeLingo.Quiz2;
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


namespace CodeLingo.Quiz2 {
    
    
    /// <summary>
    /// Page3
    /// </summary>
    public partial class Page3 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Quiz2\Page3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Subtitle;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Quiz2\Page3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton A;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Quiz2\Page3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton B;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Quiz2\Page3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton C;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Quiz2\Page3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton D;
        
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
            System.Uri resourceLocater = new System.Uri("/CodeLingo;component/quiz2/page3.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Quiz2\Page3.xaml"
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
            this.Subtitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.A = ((System.Windows.Controls.RadioButton)(target));
            
            #line 13 "..\..\..\Quiz2\Page3.xaml"
            this.A.Checked += new System.Windows.RoutedEventHandler(this.HandleCheck);
            
            #line default
            #line hidden
            return;
            case 3:
            this.B = ((System.Windows.Controls.RadioButton)(target));
            
            #line 14 "..\..\..\Quiz2\Page3.xaml"
            this.B.Checked += new System.Windows.RoutedEventHandler(this.HandleCheck);
            
            #line default
            #line hidden
            return;
            case 4:
            this.C = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\..\Quiz2\Page3.xaml"
            this.C.Checked += new System.Windows.RoutedEventHandler(this.HandleCheck);
            
            #line default
            #line hidden
            return;
            case 5:
            this.D = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\..\Quiz2\Page3.xaml"
            this.D.Checked += new System.Windows.RoutedEventHandler(this.HandleCheck);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

