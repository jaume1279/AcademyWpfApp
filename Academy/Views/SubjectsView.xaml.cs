using Academy.ViewModels;
using System.Windows.Controls;

namespace Academy.Views
{
    /// <summary>
    /// Interaction logic for SubjectsView.xaml
    /// </summary>
    public partial class SubjectsView : UserControl
    {
        public SubjectsView()
        {
            InitializeComponent();

            var vm = new SubjectsViewModel();
            this.DataContext = vm;
        }
    }
}
