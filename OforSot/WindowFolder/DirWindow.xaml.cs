using OforSot.ClassFolder;
using OforSot.PageFolder.DirectorFolder;
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

namespace OforSot.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для DirWindow.xaml
    /// </summary>
    public partial class DirWindow : Window
    {
        public DirWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ListSotBtn_Click(object sender, RoutedEventArgs e)
        {
            DirFrame.Navigate(new ListDirectorPage());
        }

        private void AddSotBtn_Click(object sender, RoutedEventArgs e)
        {
            DirFrame.Navigate(new AddDirectorPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
