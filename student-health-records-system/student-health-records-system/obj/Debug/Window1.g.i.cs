// Updated by XamlIntelliSenseFileGenerator 2/2/2023 6:05:16 AM
#pragma checksum "..\..\Window1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "015E4AA901357F5C1B426AB7A63446E3906AB726FB16F121ED700A95BB487514"
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


namespace student_health_records_system
{


    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 195 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logoutBtn;

#line default
#line hidden


#line 196 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addRecordBtn;

#line default
#line hidden


#line 197 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button massInsertBtn;

#line default
#line hidden


#line 198 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button showLogsWindowBtn;

#line default
#line hidden


#line 199 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBtn;

#line default
#line hidden


#line 200 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtn_Copy;

#line default
#line hidden


#line 202 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchBtn;

#line default
#line hidden


#line 206 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AdminTable;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/student-health-records-system;component/window1.xaml", System.UriKind.Relative);

#line 1 "..\..\Window1.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.AdminConsole = ((student_health_records_system.Window1)(target));
                    return;
                case 2:
                    this.logoutBtn = ((System.Windows.Controls.Button)(target));

#line 195 "..\..\Window1.xaml"
                    this.logoutBtn.Click += new System.Windows.RoutedEventHandler(this.loginBtn_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.addRecordBtn = ((System.Windows.Controls.Button)(target));
                    return;
                case 4:
                    this.massInsertBtn = ((System.Windows.Controls.Button)(target));
                    return;
                case 5:
                    this.showLogsWindowBtn = ((System.Windows.Controls.Button)(target));
                    return;
                case 6:
                    this.EditBtn = ((System.Windows.Controls.Button)(target));

#line 199 "..\..\Window1.xaml"
                    this.EditBtn.Click += new System.Windows.RoutedEventHandler(this.loginBtn_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.DeleteBtn_Copy = ((System.Windows.Controls.Button)(target));

#line 200 "..\..\Window1.xaml"
                    this.DeleteBtn_Copy.Click += new System.Windows.RoutedEventHandler(this.loginBtn_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.SearchBtn = ((System.Windows.Controls.Button)(target));

#line 202 "..\..\Window1.xaml"
                    this.SearchBtn.Click += new System.Windows.RoutedEventHandler(this.loginBtn_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.AdminTable = ((System.Windows.Controls.DataGrid)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window AdminConsole;
    }
}

