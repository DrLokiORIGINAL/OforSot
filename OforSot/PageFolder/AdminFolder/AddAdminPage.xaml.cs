using OforSot.ClassFolder;
using OforSot.DataFolder;
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

namespace OforSot.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AddAdminPage.xaml
    /// </summary>
    public partial class AddAdminPage : Page
    {
        public AddAdminPage()
        {
            InitializeComponent();
            RoleCb.ItemsSource = DBEntities.Getcontext()
                .Role.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.Getcontext().User.Add(new User()
            {
                RoleId = Int32.Parse(RoleCb.SelectedValue.ToString()),
                Login = LoginTb.Text,
                Password = PasswordTb.Text,
            });
            DBEntities.Getcontext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListAdminPage());
        }
    }
}
