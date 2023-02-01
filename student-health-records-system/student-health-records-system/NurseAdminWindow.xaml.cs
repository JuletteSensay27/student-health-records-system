using Microsoft.Win32;
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
using System.IO;

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
            fillTable(mainTable);
        }

        class Student
        {
            public string studentID { get; set; }
            public string studentName { get; set; }
            public string dateCreated { get; set; }
            public string dateModified { get; set; }
        }

        private void fillTable(DataGrid mainGrid)
        {
            DataGridTextColumn studentID = new DataGridTextColumn();
            studentID.Header = "Student ID";
            studentID.Binding = new Binding("studentID");
            studentID.Width = NurseAdminWindow.Width / 4 - 50;
            mainGrid.Columns.Add(studentID);


            DataGridTextColumn studentName = new DataGridTextColumn();
            studentName.Header = "Student Name";
            studentName.Binding = new Binding("studentName");
            studentName.Width = NurseAdminWindow.Width / 4;
            mainGrid.Columns.Add(studentName);

            DataGridTextColumn dateCreated = new DataGridTextColumn();
            dateCreated.Header = "Date Created";
            dateCreated.Binding = new Binding("dateCreated");
            dateCreated.Width = NurseAdminWindow.Width / 4;
            mainGrid.Columns.Add(dateCreated);

            DataGridTextColumn dateModified = new DataGridTextColumn();
            dateModified.Header = "Date Modified";
            dateModified.Binding = new Binding("dateModified");
            dateModified.Width = NurseAdminWindow.Width / 4;
            mainGrid.Columns.Add(dateModified);


            for (int i = 0; i < dbFunctions.getAllStudents().Count; i++)
            {
                mainGrid.Items.Add(new Student
                {
                    studentID = dbFunctions.getAllStudents().ElementAt(i).ElementAt(0),
                    studentName = dbFunctions.getAllStudents().ElementAt(i).ElementAt(1),
                    dateCreated = dbFunctions.getAllStudents().ElementAt(i).ElementAt(2),
                    dateModified = dbFunctions.getAllStudents().ElementAt(i).ElementAt(3)
                });
            }
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


        private void massInsertBtn_Click(object sender, RoutedEventArgs e)
        {
            var result  = MessageBox.Show("Which Operation Do you want to proceed with? Yes-Mass Insert Students || No-Mass Insert Files","Mass Inserting", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.No) 
            {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Csv Files (*.csv) | *.csv";
                ofd.Multiselect = false;
                int studentCounter = 0;
                Dictionary<string, List<Object>> students = new Dictionary<string, List<object>>();
                string[] message = new string[2];

                if ((bool)ofd.ShowDialog())
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        string line = string.Empty;

                        while ((line = sr.ReadLine()) != null)
                        {
                            List<Object> tempStudentHolder = new List<Object>();
                            string[] tempArr = line.Split(',');

                            for (int i = 0; i < tempArr.Length; i++)
                            {
                                tempStudentHolder.Add(tempArr[i].ToString());
                            }

                            students.Add($"S{studentCounter + 1}", tempStudentHolder);
                            studentCounter++;
                        }
                    }
                }

                message = dbFunctions.massStudentRegister(students);
                MessageBox.Show($"Status: {message[0]}\nMessage:{message[1]}");
                return;
            }

            massInsertFiles();


        }

        private void massInsertFiles() 
        {
            OpenFileDialog ofd = new OpenFileDialog();    
            ofd.Filter = "Csv Files (*.csv) | *.csv";
            ofd.Multiselect = false;

            if ((bool)ofd.ShowDialog()) 
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    string line = string.Empty;
                    int failCounter = 0;
                    int successCounter = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] tempArr = line.Split(',');
                        List<Object> tempFileHolder = new List<Object>();

                        for (int i = 0; i < tempArr.Length; i++)
                        {
                           tempFileHolder.Add(tempArr.ElementAt(i).ToString());
                        }

                        if (int.Parse(dbFunctions.massStudentFilesAdd(tempFileHolder).ToString()) != 0) 
                        {
                            failCounter++;
                        }
                        else
                        {
                            successCounter++;
                        }

                    }

                    MessageBox.Show($"Status: Mass Insert Files Report\nMessage:Successes{successCounter}\nFails:{failCounter}");
                }
            }

        }
    }
}
