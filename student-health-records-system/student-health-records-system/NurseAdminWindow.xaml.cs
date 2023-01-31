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
        private DBInteractions dbFunctions = new DBInteractions();

        public AdminWindow(string nurseUsername)
        {
            InitializeComponent();
            nurseUNameLbl.Content = nurseUsername;
            fillTable(mainTable);
        }

        class Student 
        {
            public string studentID { get; set; }
            public string studentName { get; set; }
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] message = dbFunctions.userLogout(nurseUNameLbl.Content.ToString());

            MessageBox.Show($"Status: {message[0]}\nMessage:{message[1]}");

            LogInWindow newLoginWindow = new LogInWindow();
            newLoginWindow.Show();
            this.Close();
        }

        private void fillTable(DataGrid mainGrid) 
        {
            DataGridTextColumn studentID = new DataGridTextColumn();
            studentID.Header= "Student ID";
            studentID.Binding = new Binding("studentID");
            studentID.Width = NurseAdminWindow.Width/3;
            mainGrid.Columns.Add(studentID);
            

            DataGridTextColumn studentName = new DataGridTextColumn();
            studentName.Header = "Student Name";
            studentName.Binding = new Binding("studentName");
            studentName.Width = NurseAdminWindow.Width / 2 + 500;
            mainGrid.Columns.Add(studentName);

            for (int i = 0; i < dbFunctions.getAllStudents().Count; i++) 
            {
                mainGrid.Items.Add(new Student {studentID = dbFunctions.getAllStudents().ElementAt(i).ElementAt(0), studentName = dbFunctions.getAllStudents().ElementAt(i).ElementAt(1) } );
            }
        }
    }
}
