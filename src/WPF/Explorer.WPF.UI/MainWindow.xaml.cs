using System.ComponentModel;
using System.Windows;
using ExplorER;

namespace Explorer.WPF.UI
{
    public partial class MainWindow
    {
        private readonly MainViewModel _mainVm;

        public MainWindow()
        {
            InitializeComponent();
            
            _mainVm = ExplorerEr.Instance.MainViewModel;

            DataContext = _mainVm;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _mainVm.ApplicationClosing();

            System.Windows.Application.Current.Shutdown();

        }


       
        
    }
}
