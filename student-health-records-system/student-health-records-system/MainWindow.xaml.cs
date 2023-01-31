using System;
using System.Collections.Generic;
using System.Data;
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

            adminDeptCbx.Items.Add("IT");
            adminDeptCbx.Items.Add("CL");
            adminAccessCbx.Items.Add("IAD");
            adminAccessCbx.Items.Add("NAD");

          
        }

       

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = string.Empty;
            string userPassword = string.Empty;
            string[] message = new string[2];

            userName = adminUsernameTbx.Text;
            userPassword = adminPasswordPbx.Password;

            message = db.userLogin(userName, userPassword);

            MessageBox.Show($"Status: {message[0]}\nMessage:{message[1]}");
            
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Object> adminInfo = new List<Object>();
            DateTime dateCreated = DateTime.Now;
            DateTime dateModified = DateTime.Now;
            string[] message = new string[2];

            adminInfo.Add(adminIDTbx.Text);
           
            adminInfo.Add(adminFNameTbx.Text);
            adminInfo.Add(adminMNameTbx.Text);
            adminInfo.Add(adminLNameTbx.Text);
            adminInfo.Add(adminUNameTbx.Text);
            adminInfo.Add(adminPWordPbx.Password);
            adminInfo.Add(adminPhoneNumTbx.Text);
            adminInfo.Add(adminEmailTbx.Text);
            adminInfo.Add(adminDeptCbx.SelectedItem);
            adminInfo.Add(adminAccessCbx.SelectedItem);
            adminInfo.Add(dateCreated);
            adminInfo.Add(dateModified);

            if (adminInfo.Contains(null)) 
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            message = db.userRegistration(adminInfo);

            MessageBox.Show($"Status: {message[0]}\nMessage: {message[1]}");

        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = string.Empty;
            string[] message = new string[2];
            userName = adminUsernameTbx.Text;
         
            message = db.userLogout(userName);

            MessageBox.Show($"Status: {message[0]}\nMessage:{message[1]}");
        }

        private void retrieveBtn_Click(object sender, RoutedEventArgs e)
        {
            string adminID = adminIDTbx.Text;
            Dictionary<string , string> adminInfo = db.getAdminInfo(adminID);

            if (adminInfo.Count < 1) 
            {
                MessageBox.Show("Admin ID is not existing!");
                return;
            }
            
            

            adminIDTbx.Text = adminInfo.Values.ElementAt(0);
            adminFNameTbx.Text = adminInfo.Values.ElementAt(1);
            adminMNameTbx.Text = adminInfo.Values.ElementAt(2);
            adminLNameTbx.Text = adminInfo.Values.ElementAt(3);
            adminUNameTbx.Text = adminInfo.Values.ElementAt(4);
            adminPWordPbx.Password = adminInfo.Values.ElementAt(5);
            adminPhoneNumTbx.Text = adminInfo.Values.ElementAt(6);
            adminEmailTbx.Text = adminInfo.Values.ElementAt(7);
            adminDeptCbx.SelectedItem = adminInfo.Values.ElementAt(8);
            adminAccessCbx.SelectedItem = adminInfo.Values.ElementAt(9);
            adminStatusTbx.Text = adminInfo.Values.ElementAt(10);
 
        }

        private void updateAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Object> adminInfo = new List<Object>();
            DateTime dateModified = DateTime.Now;
            string[] message = new string[2];

            adminInfo.Add(adminIDTbx.Text);
            adminInfo.Add(adminFNameTbx.Text);
            adminInfo.Add(adminMNameTbx.Text);
            adminInfo.Add(adminLNameTbx.Text);
            adminInfo.Add(adminUNameTbx.Text);
            adminInfo.Add(adminPWordPbx.Password);
            adminInfo.Add(adminPhoneNumTbx.Text);
            adminInfo.Add(adminEmailTbx.Text);
            adminInfo.Add(adminDeptCbx.SelectedItem);
            adminInfo.Add(adminAccessCbx.SelectedItem);
            adminInfo.Add(adminStatusTbx.Text);
            adminInfo.Add(dateModified);

            if (adminInfo.Contains(null))
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            message = db.userUpdates(adminInfo);

            MessageBox.Show($"Status: {message[0]}\nMessage: {message[1]}");
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string adminID = adminIDTbx.Text;

            string[] message = db.userDelete(adminID);

            MessageBox.Show($"Status: {message[0]}\nMessage:{message[1]}");
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
