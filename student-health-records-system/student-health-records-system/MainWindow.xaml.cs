using System;
using System.Collections.Generic;
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
            adminInfo.Add(adminUsernameTbx.Text);
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
    }
}
