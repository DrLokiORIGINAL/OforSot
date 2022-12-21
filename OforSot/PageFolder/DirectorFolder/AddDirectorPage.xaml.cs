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
    /// Логика взаимодействия для AddDirectorPage.xaml
    /// </summary>
    public partial class AddDirectorPage : Page
    {
        public AddDirectorPage()
        {
            InitializeComponent();
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.Getcontext().Specialist.Add(new Specialist()
            {
                MilitaryIDId = Int32.Parse(MilitaryIDIdCb.SelectedValue.ToString()),
                GovernmentServiceId = Int32.Parse(GovernmentServiceCb.SelectedValue.ToString()),
                EducationId = Int32.Parse(EducationCb.SelectedValue.ToString()),
                DisabilityId = Int32.Parse(DisabilityCb.SelectedValue.ToString()),
                EmploymentHistoryId = Int32.Parse(EmploymentHistoryCb.SelectedValue.ToString()),
                MedicalBookId = Int32.Parse(MedicalBookCb.SelectedValue.ToString()),
                SnilsId = Int32.Parse(SnilsCb.SelectedValue.ToString()),
                SpecialistLastName = LastNameTb.Text,
                SpecialistFirstName = FirstNameTb.Text,
                SpecialistMeddleName = MiddleNameTb.Text,
                PassportSeries = Int32.Parse(SerialPassportTb.Text),
                PassportNumber = Int32.Parse(NumberPassportTb.Text),
                PastPosition = PastPositionTb.Text,
                LastPlaceOfWork = LastPlaceOfWorkTb.Text,
                PlaceOfEducation = PlaceOfEducationTb.Text,
            });
            DBEntities.Getcontext().SaveChanges();
            MBClass.InformationMB("Успешно");
            NavigationService.Navigate(new ListDirectorPage());
        }
    }
}
