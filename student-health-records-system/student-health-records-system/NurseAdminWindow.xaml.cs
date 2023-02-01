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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        DBInteractions dbFunctions = new DBInteractions();

        public AdminWindow(string nurseUsername)
        {
            InitializeComponent();
            nurseUNameLbl.Content = nurseUsername;
            
        }

        private void addRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow newStudent = new AddStudentWindow();
            newStudent.Show();
        }

        private void NurseAdminWindow_Closed(object sender, EventArgs e)
        {
            string[] message = dbFunctions.userLogout(nurseUNameLbl.Content.ToString());

            MessageBox.Show($"Status: {message[0]}\nMessage:{message[1]}");

            LogInWindow newLogin = new LogInWindow();
            newLogin.Show();
            this.Close();
        }
    }
}
