using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.Win32;

namespace student_health_records_system
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        FilterInfoCollection fic = null;
        VideoCaptureDevice vcd = null;
        private List<List<Object>> studentFiles = new List<List<Object>>();
        private DBInteractions dbFunc = new DBInteractions();
        private List<Object> tempStudentImage = new List<Object>();
        private List<List<Object>> tempStudentFiles = new List<List<Object>>();

        public AddStudentWindow()
        {

            int studentID = int.Parse(dbFunc.getStudentCount().ToString()) + 1; 

            InitializeComponent();
            CaptureImgBtn.IsEnabled = false;
            sampleIDTbx.Text = studentID.ToString() ;
            sampleIDTbx.IsReadOnly = true;
            submitButton(sampleRegisterBtn);
            studentImageImgbx.Source = null;
            genderCbx.Items.Add("M");
            genderCbx.Items.Add("F");   
            genderCbx.Text = "Select an Item";
            studentAgeTbx.IsReadOnly = true;
        }

        private string IDToImageName(TextBox studentIDTbx) 
        {
            string fileName = string.Empty;
            int idNum = int.Parse(studentIDTbx.Text.ToString());

            if (idNum < 10) 
            {
                fileName = $"2023000{idNum}.png";
            }

            if (idNum > 10 && idNum < 100)
            {
                fileName = $"202300{idNum}.png";
            }

            if (idNum > 100 && idNum < 1000)
            {
                fileName = $"20230{idNum}.png";
            }

            if (idNum > 1000 && idNum < 10000)
            {
                fileName = $"2023{idNum}.png";
            }

            return fileName;
        }

        private void CaptureImgBtn_Click(object sender, RoutedEventArgs e)
        {
            vcd.SignalToStop();
            var result = MessageBox.Show("Do you Want To Save this Image?", "Capturing Image", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                vcd = new VideoCaptureDevice(fic[camerasCbx.SelectedIndex].MonikerString);
                startCameraBtn.Content = "Turn Off Camera";
                startCameraBtn.IsEnabled = true;
                vcd.NewFrame += Vcd_NewFrame;
                vcd.Start();
                CaptureImgBtn.IsEnabled = true;
                return;
            }

            
            ImageToFile(IDToImageName(sampleIDTbx));
            CaptureImgBtn.IsEnabled = false;
        }

        private void Vcd_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.Dispatcher.Invoke(() =>
            {
                studentImageImgbx.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        ((Bitmap)eventArgs.Frame.Clone()).GetHbitmap(),
                        IntPtr.Zero,
                        System.Windows.Int32Rect.Empty,
                        BitmapSizeOptions.FromWidthAndHeight((int)studentImageImgbx.Width, (int)studentImageImgbx.Height));
            });
        }

        private void startCameraBtn_Click(object sender, RoutedEventArgs e)
        {

            if (startCameraBtn.Content.ToString() != "start Camera")
            {
                vcd.SignalToStop();
                CaptureImgBtn.IsEnabled = false;
                startCameraBtn.IsEnabled = true;
                uploadImgBtn.IsEnabled = true;
                startCameraBtn.Content = "start Camera";
                vcd = null;
                studentImageImgbx.Source = null;
                return;
            }

            vcd = new VideoCaptureDevice(fic[camerasCbx.SelectedIndex].MonikerString);
            vcd.NewFrame += Vcd_NewFrame;
            vcd.Start();
            CaptureImgBtn.IsEnabled = true;
            startCameraBtn.IsEnabled = true;
            uploadImgBtn.IsEnabled = false;
            startCameraBtn.Content = "Turn Off Camera";
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo fi in fic)
                camerasCbx.Items.Add(fi.Name);
            camerasCbx.SelectedIndex = 0;
            vcd = new VideoCaptureDevice();
        }

        public void ImageToFile(string fileName)
        {
            tempStudentImage = new List<Object>()
            {
                fileName.Split('.')[0].ToString(), //Name
                fileName.Split('.')[1].ToString().ToUpper(), //file Type
                //File To Have Location after register button is clicked
            };

            
        }

        private void uploadImgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            ofd.Multiselect = false;


        }

        private void submitButton(Button submitBtn) 
        {
            submitBtn.Click += SubmitBtn_Click;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] message = new string[2];
            studentFiles = new List<List<Object>>();
            studentFiles.Add(tempStudentImage);
            for (int i = 0; i < tempStudentFiles.Count; i++) 
            {
                studentFiles.Add(tempStudentFiles.ElementAt(i)); 
            }

            List<Object> studentInfo = new List<Object>();            

            studentInfo.Add(sampleIDTbx.Text.ToString());
            studentInfo.Add(studentFNameTbx.Text.ToString());
            studentInfo.Add(studentMNameTbx.Text.ToString());
            studentInfo.Add(studentLNameTbx.Text.ToString());
            studentInfo.Add(genderCbx.Text.ToString());
            studentInfo.Add(studentBirthDate.SelectedDate.ToString());
            studentInfo.Add(studentAgeTbx.Text.ToString());
            studentInfo.Add(studentPhoneNumTbx.Text.ToString());
            studentInfo.Add(studentEmailTbx.Text.ToString());
            
            if (studentInfo.Contains("")) 
            {
                MessageBox.Show("All Basic Info Fields Must Be filled!");
                return;
            }

            string folderName = string.Empty;

            if (int.Parse(sampleIDTbx.Text.ToString()) < 10)
            {
                folderName = $"S{DateTime.Now.Year}000{sampleIDTbx.Text}";
            }

            if (int.Parse(sampleIDTbx.Text.ToString()) > 10 && int.Parse(sampleIDTbx.Text.ToString()) < 100)
            {
                folderName = $"S{DateTime.Now.Year}00{sampleIDTbx.Text}";
            }

            if (int.Parse(sampleIDTbx.Text.ToString()) > 100 && int.Parse(sampleIDTbx.Text.ToString()) < 1000)
            {
                folderName = $"S{DateTime.Now.Year}0{sampleIDTbx.Text}";
            }

            if (int.Parse(sampleIDTbx.Text.ToString()) > 1000 && int.Parse(sampleIDTbx.Text.ToString()) < 10000)
            {
                folderName = $"S{DateTime.Now.Year}{sampleIDTbx.Text}";
            }

            Directory.CreateDirectory($"C:\\Users\\julet\\Desktop\\Workspace\\JuletteSensay27\\" +
               $"c# Apps\\student-health-records-system\\student-health-records-system\\" +
               $"FileStorage\\{folderName}");

            string FilePath = $"C:\\Users\\julet\\Desktop\\Workspace\\JuletteSensay27\\" +
               $"c# Apps\\student-health-records-system\\student-health-records-system\\" +
               $"FileStorage\\{folderName}";

            for (int i = 0; i < studentFiles.Count; i++) 
            {
                if (studentFiles.ElementAt(i).Count < 1) 
                {
                    MessageBox.Show("Record Must Have a student Image!");
                    return;
                }

                if (studentFiles.ElementAt(i).ElementAt(1).ToString() != "PDF")
                {
                    ImageSource image = studentImageImgbx.Source;

                    if (image == null)
                    {
                        MessageBox.Show("Record Must Have a student Image!");
                        return;
                    }

                    string ImageFilePath = $"{FilePath}\\{studentFiles.ElementAt(i).ElementAt(0)}.{studentFiles.ElementAt(i).ElementAt(1)}";

                    using (var fileStream = new FileStream(ImageFilePath, FileMode.Create))
                    {
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create((BitmapSource)image));
                        encoder.Save(fileStream);
                    }

                    studentFiles.ElementAt(i).Add(ImageFilePath);
                }
                else
                {
                    string filePath = $"{FilePath}\\{studentFiles.ElementAt(i).ElementAt(0)}.{studentFiles.ElementAt(i).ElementAt(1)}";
                    studentFiles.ElementAt(i).Add(filePath);
                    File.Copy(studentFiles.ElementAt(i).ElementAt(2).ToString(), filePath);
                    studentFiles.ElementAt(i).Remove(studentFiles.ElementAt(i).ElementAt(2));
                }
            }

            message = dbFunc.studentRegister(studentInfo, studentFiles);
            MessageBox.Show($"Status: {message[0]}\nMessage:{message[1]}");
            
            this.Close();

        }

        private void studentBirthDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (studentBirthDate.Text != "") 
            {
                int studentAge = DateTime.Now.Year - studentBirthDate.SelectedDate.Value.Year;
                studentAgeTbx.Text = studentAge.ToString();
            }
          
        }

        private void uploadFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            tempStudentFiles = new List<List<Object>>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "PDF Files (*.pdf) | *.pdf";

            if ((bool)ofd.ShowDialog()) 
            {
                for (int i = 0; i < ofd.FileNames.Count(); i++) 
                {
                    List<Object> temp = new List<Object>()
                    {
                        ofd.SafeFileNames.ElementAt(i),
                        "PDF",
                        ofd.FileNames.ElementAt(i)
                    };

                    tempStudentFiles.Add(temp);
                }

                for (int i = 0; i < ofd.FileNames.Count(); i++) 
                {
                    fileNamesContLbl.Content += $"{ofd.SafeFileNames.ElementAt(i)}\n";
                }

                MessageBox.Show(tempStudentFiles.Count().ToString());

            }
        }

        private void addStudentWindow_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lockImageBtn_Click(object sender, RoutedEventArgs e)
        {
            startCameraBtn.IsEnabled = false;
            uploadImgBtn.IsEnabled = false;
            CaptureImgBtn.IsEnabled = false;
            lockImageBtn.IsEnabled = false;
        }
    }
}