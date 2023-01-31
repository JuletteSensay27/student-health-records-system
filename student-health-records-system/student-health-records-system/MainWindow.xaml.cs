using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace student_health_records_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DBInteractions db = new DBInteractions();


        public MainWindow()
        {
            InitializeComponent();

         
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            student_health_records_system.Student_Health_Record_SystemDataSet student_Health_Record_SystemDataSet = ((student_health_records_system.Student_Health_Record_SystemDataSet)(this.FindResource("student_Health_Record_SystemDataSet")));
            // Load data into the table table_studentInfo. You can modify this code as needed.
            student_health_records_system.Student_Health_Record_SystemDataSetTableAdapters.table_studentInfoTableAdapter student_Health_Record_SystemDataSettable_studentInfoTableAdapter = new student_health_records_system.Student_Health_Record_SystemDataSetTableAdapters.table_studentInfoTableAdapter();
            student_Health_Record_SystemDataSettable_studentInfoTableAdapter.Fill(student_Health_Record_SystemDataSet.table_studentInfo);
            System.Windows.Data.CollectionViewSource table_studentInfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("table_studentInfoViewSource")));
            table_studentInfoViewSource.View.MoveCurrentToFirst();
            // Load data into the table table_adminAccounts. You can modify this code as needed.
            student_health_records_system.Student_Health_Record_SystemDataSetTableAdapters.table_adminAccountsTableAdapter student_Health_Record_SystemDataSettable_adminAccountsTableAdapter = new student_health_records_system.Student_Health_Record_SystemDataSetTableAdapters.table_adminAccountsTableAdapter();
            student_Health_Record_SystemDataSettable_adminAccountsTableAdapter.Fill(student_Health_Record_SystemDataSet.table_adminAccounts);
            System.Windows.Data.CollectionViewSource table_adminAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("table_adminAccountsViewSource")));
            table_adminAccountsViewSource.View.MoveCurrentToFirst();
            // Load data into the table table_activityLogs. You can modify this code as needed.
            student_health_records_system.Student_Health_Record_SystemDataSetTableAdapters.table_activityLogsTableAdapter student_Health_Record_SystemDataSettable_activityLogsTableAdapter = new student_health_records_system.Student_Health_Record_SystemDataSetTableAdapters.table_activityLogsTableAdapter();
            student_Health_Record_SystemDataSettable_activityLogsTableAdapter.Fill(student_Health_Record_SystemDataSet.table_activityLogs);
            System.Windows.Data.CollectionViewSource table_activityLogsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("table_activityLogsViewSource")));
            table_activityLogsViewSource.View.MoveCurrentToFirst();
            // Load data into the table vwAdminIDandName. You can modify this code as needed.
            student_health_records_system.Student_Health_Record_SystemDataSetTableAdapters.vwAdminIDandNameTableAdapter student_Health_Record_SystemDataSetvwAdminIDandNameTableAdapter = new student_health_records_system.Student_Health_Record_SystemDataSetTableAdapters.vwAdminIDandNameTableAdapter();
            student_Health_Record_SystemDataSetvwAdminIDandNameTableAdapter.Fill(student_Health_Record_SystemDataSet.vwAdminIDandName);
            System.Windows.Data.CollectionViewSource vwAdminIDandNameViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("vwAdminIDandNameViewSource")));
            vwAdminIDandNameViewSource.View.MoveCurrentToFirst();
        }
    }
}
