﻿#pragma checksum "..\..\..\AddStudentWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4D98CD09FB9AD34DC3AD6C2076F546A2116E5B6BF7BDFB3FDF15D8B5A39B15AC"
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
using student_health_records_system;


namespace student_health_records_system {
    
    
    /// <summary>
    /// AddStudentWindow
    /// </summary>
    public partial class AddStudentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\AddStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal student_health_records_system.AddStudentWindow addStudentWindow;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\AddStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image studentImageImgbx;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\AddStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uploadImgBtn;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\AddStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CaptureImgBtn;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\AddStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button startCameraBtn;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\AddStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox camerasCbx;
        
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
            System.Uri resourceLocater = new System.Uri("/student-health-records-system;component/addstudentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddStudentWindow.xaml"
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
            this.addStudentWindow = ((student_health_records_system.AddStudentWindow)(target));
            return;
            case 2:
            
            #line 9 "..\..\..\AddStudentWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.studentImageImgbx = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.uploadImgBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.CaptureImgBtn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\AddStudentWindow.xaml"
            this.CaptureImgBtn.Click += new System.Windows.RoutedEventHandler(this.CaptureImgBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.startCameraBtn = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\AddStudentWindow.xaml"
            this.startCameraBtn.Click += new System.Windows.RoutedEventHandler(this.startCameraBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.camerasCbx = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

