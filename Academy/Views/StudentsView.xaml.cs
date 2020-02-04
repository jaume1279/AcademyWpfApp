using Academy.ViewModels;
using System.Windows.Controls;

namespace Academy.Views
{
    /// <summary>
    /// Interaction logic for StudentsView.xaml
    /// </summary>
    public partial class StudentsView : UserControl
    {
        public StudentsView()
        {
            InitializeComponent();

            var vm = new StudentsViewModel();
            this.DataContext = vm;
        }

        //private void DelButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var selectedStudent = DatagridStudents.SelectedItem as Student;

        //}
    }
}
