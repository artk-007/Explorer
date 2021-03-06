using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ExplorER
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ISynchronizationHelper _synchronizationHelper;

        #region Public Properties        

        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } = 
            new ObservableCollection<DirectoryTabItemViewModel>();

        public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }

        public IReadOnlyCollection<MenuItemViewModel> Bookmarks => ExplorerEr.Instance.BookmarksManager.Bookmarks;

        #endregion

        #region Events

        #endregion

        #region Constructor

        public MainViewModel(ISynchronizationHelper synchronizationHelper)
        {
            _synchronizationHelper = synchronizationHelper;
            AddTabItemCommand = new DelegateCommand(OnAddTabItem);

            CloseCommand = new DelegateCommand(OnClose);

            AddTabItemViewModel();

        }
        #endregion

        #region Public Methods
        public void ApplicationClosing()
        {

        }

        #endregion

        #region Commands Methods

        private void OnAddTabItem(object obj)
        {
            AddTabItemViewModel();
        }

        private void OnClose(object obj)
        {
            if (obj is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }
       

        #endregion

        #region Private Methods

        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel(_synchronizationHelper);

            DirectoryTabItems.Add(vm);

            CurrentDirectoryTabItem = vm;
        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            DirectoryTabItems.Remove(directoryTabItemViewModel);

            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }

        #endregion

        #region Comands

        public DelegateCommand AddTabItemCommand { get; }

        public DelegateCommand CloseCommand { get; }

        public DelegateCommand BookmarkClickCommand { get; }
        #endregion


        public DelegateCommand AddBookmarkCommand => ExplorerEr.Instance.BookmarksManager.AddBookmarkCommand;

    }
    /// <summary>
    /// View-Model MenuItem
    /// </summary>
    public class MenuItemViewModel
    {
        public string Path { get; set; }

        public string Header { get; set; }

        public ICommand Command { get; set; }

        public object CommandParameter { get; set; }

        public string IconPath { get; set; }

        public IList<MenuItemViewModel> Items { get; set; }

        public MenuItemViewModel(string path)
        {
            Path = path;
            CommandParameter = path;
        }
    }
}   
