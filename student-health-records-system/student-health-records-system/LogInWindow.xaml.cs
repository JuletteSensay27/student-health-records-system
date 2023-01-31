using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace student_health_records_system
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        private DBInteractions dbFunctions = new DBInteractions();

        public LogInWindow()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] message = dbFunctions.userLogin(adminUNameTbx.Text, adminPWordPbx.Password);

            if (message[2] == null) 
            {
                MessageBox.Show($"Status: {message[0]}\nMessage:{message[1]}");
                return;
            }

            MessageBox.Show($"Status: {message[0]}\nMessage:{message[1]}");

            if (message[2] != "NAD") 
            {
                
            }

            AdminWindow nurseWindow = new AdminWindow(adminUNameTbx.Text);
            nurseWindow.Show();
            this.Close();
        }
    }
}
