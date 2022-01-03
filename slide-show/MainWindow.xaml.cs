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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace slide_show
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string selectedPath = string.Empty;
        string[] files;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
          
        }

        int index = 0;

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if(dialog.SelectedPath.Length >0)
                {
                    selectedPath = dialog.SelectedPath;

                    files =  System.IO.Directory.GetFiles(selectedPath);
                    index = files.Length;


                }
            }


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(selectedPath.Length>0)
            {
                if (e.Key == Key.Escape)
                {
                    if (WindowState == WindowState.Normal)
                    {
                        WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        WindowState = WindowState.Normal;

                    }
                }

                if (e.Key == Key.Left)
                {

                    if (index > 0)
                    {

                        index--;
                        var uri = new Uri(files[index]);
                        var img2 = new BitmapImage(uri);

                        img.Source = img2;
                    }

                }
                else if (e.Key == Key.Right)
                {
                    if (index < files.Length - 1)
                    {
                        index++;
                        var uri = new Uri(files[index]);
                        var img2 = new BitmapImage(uri);

                        img.Source = img2;
                    };

                }
            }
           


            
        }
    }
}
