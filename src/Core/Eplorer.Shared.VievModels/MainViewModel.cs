using System.Collections.ObjectModel;
using System.Linq;

namespace Eplorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties        

        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } = 
            new ObservableCollection<DirectoryTabItemViewModel>();

        public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }


        #endregion

        #region Events

        #endregion

        #region Comands

        public DelegateCommand AddTabItemCommand { get;}

        #endregion

        #region Constructor

        public MainViewModel()
        {
            AddTabItemCommand = new DelegateCommand(OnAddTabItem);
            
            AddTabItemViewModel();

            
        }

        private void OnAddTabItem(object obj)
        {
            AddTabItemViewModel();
        }

        #endregion

        #region Public Methods
        public void ApplicationClosing()
        {

        }

        #endregion

        #region Commands Methods


        #endregion

        #region Private Methods

        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel();

            vm.Closed += Vm_Closed;

            DirectoryTabItems.Add(vm);

            CurrentDirectoryTabItem = vm;
        }

        private void Vm_Closed(object sender, System.IO.ErrorEventArgs e)
        {
            if (sender is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            directoryTabItemViewModel.Closed -= Vm_Closed;

            DirectoryTabItems.Remove(directoryTabItemViewModel);

            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }

        #endregion

        
    }
}   
