using Academy.ViewModels;
using System.Windows.Controls;

namespace Academy.Views
{
    /// <summary>
    /// Interaction logic for StudentExamView.xaml
    /// </summary>
    public partial class StudentExamView : UserControl
    {
        public StudentExamView()
        {
            InitializeComponent();

            var vm = new StudentExamViewModel();
            this.DataContext = vm;
        }
    }
}
