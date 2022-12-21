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

namespace OforSot.PageFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для ListDirectorPage.xaml
    /// </summary>
    public partial class ListDirectorPage : Page
    {
        public ListDirectorPage()
        {
            InitializeComponent();
            ListDirDG.ItemsSource = DBEntities.Getcontext().Specialist.ToList()
                .OrderBy(c => c.SpecialistId);
        }
        private void Ref()
        {
            ListDirDG.ItemsSource = DBEntities.Getcontext().Specialist.ToList()
                .OrderBy(c => c.SpecialistId);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListDirDG.ItemsSource = DBEntities.Getcontext().Specialist.Where(u => u.SpecialistLastName.StartsWith(SearchTb.Text)).ToList();
                if (ListDirDG.Items.Count <= 0)
                {
                    MBClass.ErrorMB("Сотрудник не найден");
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            ListDirDG.ItemsSource = DBEntities.Getcontext().User.ToList();
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            Specialist specialist = ListDirDG.SelectedItem as Specialist;
            VariableClass.SpecialistId = specialist.SpecialistId;
            this.NavigationService.Navigate(new EditDirectorPage(ListDirDG.SelectedItem as Specialist));
            Ref();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (ListDirDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника для удаления");
            }
            else
            {
                try
                {
                    Specialist specialist = ListDirDG.SelectedItem as Specialist;
                    if (MBClass.QestionMB($"Удалить выбраного сотрудника?"))
                    {
                        DBEntities.Getcontext().Specialist.Remove(specialist);
                        DBEntities.Getcontext().SaveChanges();
                        Ref();
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                ListDirDG.ItemsSource = DBEntities.Getcontext().Specialist.ToList();
            }
        }
    }
}
