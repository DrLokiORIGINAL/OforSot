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
using System.Windows.Shapes;

namespace OforSot.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrEmpty(LoginTb.Text))
                {
                    MBClass.ErrorMB("Введите логин");
                    LoginTb.Focus();
                }
                if (string.IsNullOrEmpty(PasswordTb.Password))
                {
                    MBClass.ErrorMB("Введите пароль");
                    PasswordTb.Focus();
                }
                else
                {
                    try
                    {
                        var user = DBEntities.Getcontext().User.FirstOrDefault
                            (u => u.Login == LoginTb.Text);
                        if (user == null)
                        {
                            MBClass.ErrorMB("Пользователь не найден");
                            LoginTb.Focus();
                            return;
                        }
                        if (user.Password != PasswordTb.Password)
                        {
                            MBClass.ErrorMB("Введен не правильный пароль");
                            PasswordTb.Focus();
                            return;
                        }
                        else
                        {
                            switch (user.RoleId)
                            {
                                case 1:
                                    MainWindow AdminWindow = new MainWindow();
                                    AdminWindow.Show();
                                    this.Close();
                                    break;
                                case 2:
                                    DirWindow dirWindow = new DirWindow();
                                    dirWindow.Show();
                                    this.Close();
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MBClass.ErrorMB(ex);
                    }
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
