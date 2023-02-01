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

        public AddStudentWindow()
        {
            InitializeComponent();
            CaptureImgBtn.IsEnabled = false;
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

            ImageToFile("Test.png");
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

        public void ImageToFile(string filePath)
        {

            List<Object> temp = new List<object>();
            var image = studentImageImgbx.Source;
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)image));
                encoder.Save(fileStream);
            }


        }

        private void uploadImgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            ofd.Multiselect = false;


        }
    }
}