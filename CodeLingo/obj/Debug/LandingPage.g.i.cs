﻿#pragma checksum "..\..\LandingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E4867C0BD869593F315F8B5A6E6EBFF0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LoginPage;
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


namespace CodeLingo {
    
    
    /// <summary>
    /// LandingPage
    /// </summary>
    public partial class LandingPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Logout;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LandingTitle;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LeftContent;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid RightContent;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Lesson;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Lesson1Button;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Lesson2;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Lesson2Button;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Quiz2Button;
        
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
            System.Uri resourceLocater = new System.Uri("/CodeLingo;component/landingpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LandingPage.xaml"
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
            this.Logout = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\LandingPage.xaml"
            this.Logout.Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LandingTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.LeftContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.RightContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.Lesson = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Lesson1Button = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\LandingPage.xaml"
            this.Lesson1Button.Click += new System.Windows.RoutedEventHandler(this.lesson_button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Lesson2 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Lesson2Button = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\LandingPage.xaml"
            this.Lesson2Button.Click += new System.Windows.RoutedEventHandler(this.lesson_button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Quiz2Button = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\LandingPage.xaml"
            this.Quiz2Button.Click += new System.Windows.RoutedEventHandler(this.Quiz_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

