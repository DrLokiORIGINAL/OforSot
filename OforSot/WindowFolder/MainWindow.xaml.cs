using OforSot.ClassFolder;
using OforSot.DataFolder;
using OforSot.PageFolder.AdminFolder;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.AdminFolder.AddAdminPage());
            MaiFrame.Navigate(new PageFolder.AdminFolder.ListAdminPage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ListBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListAdminPage());
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new AddAdminPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
