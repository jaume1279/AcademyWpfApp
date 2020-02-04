using Academy.Lib;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Academy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Init();
        }
    }
}
