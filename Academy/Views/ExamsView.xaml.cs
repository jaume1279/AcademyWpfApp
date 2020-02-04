using Academy.ViewModels;
using System.Windows.Controls;

namespace Academy.Views
{
    /// <summary>
    /// Interaction logic for ExamsView.xaml
    /// </summary>
    public partial class ExamsView : UserControl
    {
        public ExamsView()
        {
            InitializeComponent();

            var vm = new ExamViewModel();
            this.DataContext = vm;
        }

    }
}
