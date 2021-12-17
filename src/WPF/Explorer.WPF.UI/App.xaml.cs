using System.Windows;
using ExplorER;

namespace Explorer.WPF.UI
{
    public partial class App 
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ExplorerEr.CreateExplorerEr(new WPFSynchronizationHelper());
            var mainWindow = new MainWindow();

            mainWindow.Show();
        }
    }
}
