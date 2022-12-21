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
    /// Логика взаимодействия для EditDirectorPage.xaml
    /// </summary>
    public partial class EditDirectorPage : Page
    {
        public EditDirectorPage(Specialist specialist)
        {
            InitializeComponent();
            DataContext = specialist;
            MilitaryIDIdCb.ItemsSource = DBEntities.Getcontext()
              .MilitaryID.ToList();
            GovernmentServiceCb.ItemsSource = DBEntities.Getcontext()
              .GovernmentService.ToList();
            EducationCb.ItemsSource = DBEntities.Getcontext()
              .Education.ToList();
            DisabilityCb.ItemsSource = DBEntities.Getcontext()
              .Disability.ToList();
            EmploymentHistoryCb.ItemsSource = DBEntities.Getcontext()
              .EmploymentHistory.ToList();
            MedicalBookCb.ItemsSource = DBEntities.Getcontext()
              .MedicalBook.ToList();
            SnilsCb.ItemsSource = DBEntities.Getcontext()
              .Snils.ToList();
        }

        private void EditDocBtn_Click(object sender, RoutedEventArgs e)
        {
            Specialist specialist = DBEntities.Getcontext().Specialist.
                FirstOrDefault(s => s.SpecialistId == VariableClass.SpecialistId);
            specialist.MilitaryIDId = Int32.Parse(MilitaryIDIdCb.SelectedValue.ToString());
            specialist.GovernmentServiceId = Int32.Parse(GovernmentServiceCb.SelectedValue.ToString());
            specialist.EducationId = Int32.Parse(EducationCb.SelectedValue.ToString());
            specialist.DisabilityId = Int32.Parse(DisabilityCb.SelectedValue.ToString());
            specialist.EmploymentHistoryId = Int32.Parse(EmploymentHistoryCb.SelectedValue.ToString());
            specialist.MedicalBookId = Int32.Parse(MedicalBookCb.SelectedValue.ToString());
            specialist.SnilsId = Int32.Parse(SnilsCb.SelectedValue.ToString());
            specialist.SpecialistLastName = LastNameTb.Text;
            specialist.SpecialistFirstName = FirstNameTb.Text;
            specialist.SpecialistMeddleName = MiddleNameTb.Text;
            specialist.PassportSeries = Int32.Parse(SerialPassportTb.Text);
            specialist.PassportNumber = Int32.Parse(NumberPassportTb.Text);
            specialist.PastPosition = PastPositionTb.Text;
            specialist.LastPlaceOfWork = LastPlaceOfWorkTb.Text;
            specialist.PlaceOfEducation = PlaceOfEducationTb.Text;
            DBEntities.Getcontext().SaveChanges();
            MBClass.InformationMB("Сотрудник успешно отредактирован");
            NavigationService.Navigate(new ListDirectorPage());
        }
    }
}
