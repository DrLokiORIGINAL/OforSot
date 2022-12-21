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
    /// Логика взаимодействия для EditAdminPage.xaml
    /// </summary>
    public partial class EditAdminPage : Page
    {
        public EditAdminPage(User user)
        {
            InitializeComponent();
            DataContext = user;
            RoleCb.ItemsSource = DBEntities.Getcontext()
              .Role.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = DBEntities.Getcontext().User.
                FirstOrDefault(s => s.UserId == VariableClass.UserId);
            user.RoleId = Int32.Parse(RoleCb.SelectedValue.ToString());
            user.Login = LoginTb.Text;
            user.Password = PasswordTb.Text;
            DBEntities.Getcontext().SaveChanges();
            MBClass.InformationMB("Поользователь успешно отредактирован");
            NavigationService.Navigate(new ListAdminPage());
        }
    }
}
