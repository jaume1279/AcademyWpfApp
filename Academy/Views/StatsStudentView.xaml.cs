using Academy.ViewModels;
using System.Windows.Controls;

namespace Academy.Views
{
    /// <summary>
    /// Interaction logic for StatsStudentView.xaml
    /// </summary>
    public partial class StatsStudentView : UserControl
    {
        public StatsStudentView()
        {
            InitializeComponent();

            var vm = new StatsStudentViewModel();
            this.DataContext = vm;
        }

    }
}
