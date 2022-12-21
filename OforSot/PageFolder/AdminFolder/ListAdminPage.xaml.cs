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
    /// Логика взаимодействия для ListAdminPage.xaml
    /// </summary>
    public partial class ListAdminPage : Page
    {
        public ListAdminPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.Getcontext().User.ToList()
                .OrderBy(c => c.UserId);
        }
        private void Ref()
        {
            ListAdminDG.ItemsSource = DBEntities.Getcontext().Role.ToList()
                .OrderBy(c => c.RoleId);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListAdminDG.ItemsSource = DBEntities.Getcontext().User.Where(u => u.Login.StartsWith(SearchTb.Text)).ToList();
                if (ListAdminDG.Items.Count <= 0)
                {
                    MBClass.ErrorMB("пользователь не найден");
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            ListAdminDG.ItemsSource = DBEntities.Getcontext().User.ToList();
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            User user = ListAdminDG.SelectedItem as User;
            VariableClass.UserId = user.UserId;
            this.NavigationService.Navigate(new EditAdminPage(ListAdminDG.SelectedItem as User));
            Ref();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя для удаления");
            }
            else
            {
                try
                {
                    User user = ListAdminDG.SelectedItem as User;
                    if (MBClass.QestionMB($"Удалить выбраного пользователя?"))
                    {
                        DBEntities.Getcontext().User.Remove(user);
                        DBEntities.Getcontext().SaveChanges();
                        Ref();
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                ListAdminDG.ItemsSource = DBEntities.Getcontext().User.ToList();
            }
        }
    }
}
