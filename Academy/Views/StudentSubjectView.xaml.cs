using Academy.ViewModels;
using System.Windows.Controls;

namespace Academy.Views
{
    /// <summary>
    /// Interaction logic for StudentSubject.xaml
    /// </summary>
    public partial class StudentSubjectView : UserControl
    {
        public StudentSubjectView()
        {
            InitializeComponent();

            var vm = new StudentSubjectViewModel();
            this.DataContext = vm;
        }
    }
}
