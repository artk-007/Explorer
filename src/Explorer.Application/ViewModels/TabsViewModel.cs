using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using ExplorER.Base;
using ExplorER.FileEntities;
using ExplorER.FileEntities.Base;

namespace ExplorER
{
    public class TabsViewModel : BaseViewModel
    {
        #region Private Fields

        private readonly ISynchronizationHelper _synchronizationHelper;

        #endregion
            
        #region Public Properties

        public ITabClient InterTabClient { get; }

        public ObservableCollection<ChromerTabItemViewModel> TabItems { get; }

        public ChromerTabItemViewModel? CurrentTabItem { get; set; }

        public IReadOnlyCollection<MenuItemViewModel> Bookmarks => ExplorerEr.Instance.BookmarksManager.Bookmarks;

        public Func<DirectoryTabItemViewModel> Factory { get; }

        #endregion

        #region Commands

        public DelegateCommand CreateNewTabItemCommand { get; }
        public DelegateCommand OpenTabItemInNewWindowCommand { get; }
        public DelegateCommand DuplicateTabCommand { get; }
        public DelegateCommand CloseAllTabsCommand { get; }

        #endregion
        
        #region Constructor

        public TabsViewModel(ISynchronizationHelper synchronizationHelper, ITabClient tabClient,
            IEnumerable<DirectoryTabItemViewModel> init)
        {
            _synchronizationHelper = synchronizationHelper;
            InterTabClient = tabClient;

            CreateNewTabItemCommand = new DelegateCommand(OnCreateNewTabItem);
            OpenTabItemInNewWindowCommand = new DelegateCommand(OnOpenTabItemInNewWindow, OnCanOpenTabItemInNewWindow);
            DuplicateTabCommand = new DelegateCommand(OnDuplicate);
            CloseAllTabsCommand = new DelegateCommand(OnCloseAllTabs, CanCloseAllTabs);

            TabItems = new ObservableCollection<ChromerTabItemViewModel>(init);

            Factory = CreateTabVm;

            TabItems.CollectionChanged += TabItemsOnCollectionChanged;
        }

        #endregion

        #region Public Methods

        public void OnOpenNewTab(FileEntityViewModel fileEntityViewModel, bool isSelectNewTab = false)
        {
            if (fileEntityViewModel is DirectoryViewModel directoryViewModel)
            {
                var tab = new DirectoryTabItemViewModel(_synchronizationHelper, directoryViewModel.FullName,
                    directoryViewModel.Name);
                TabItems.Add(tab);

                if (isSelectNewTab)
                    CurrentTabItem = tab;
            }
        }

        private void OnCreateNewTabItem(object? obj)
        {
            if (obj is not DirectoryTabItemViewModel directoryTabItem)
                return;

            var tab = new DirectoryTabItemViewModel(_synchronizationHelper,
                ExplorerEr.RootName, ExplorerEr.RootName);
            TabItems.Add(tab);
        }

        private bool OnCanOpenTabItemInNewWindow(object? obj) => TabItems.Count > 1;

        private void OnOpenTabItemInNewWindow(object? obj)
        {
            if (obj is not DirectoryTabItemViewModel directoryTabItem)
                return;

            TabItems.Remove(directoryTabItem);

            ExplorerEr.Instance.OpenTabInNewWindow(directoryTabItem);
        }

        private void OnDuplicate(object? obj)
        {
            if (obj is not DirectoryTabItemViewModel directoryTabItem)
                return;

            TabItems.Add(new DirectoryTabItemViewModel(_synchronizationHelper,
                directoryTabItem.CurrentDirectoryFileName, directoryTabItem.Header));
        }

        private bool CanCloseAllTabs(object? obj) => TabItems.Count > 1;

        private void OnCloseAllTabs(object? obj)
        {
            if (obj is not DirectoryTabItemViewModel directoryTabItem)
                return;

            var removedItems = TabItems.Where(i => i != directoryTabItem).ToList();

            foreach (var item in removedItems)
                TabItems.Remove(item);
        }

        #endregion

        #region Private Methods

        private DirectoryTabItemViewModel CreateTabVm() =>
            new(_synchronizationHelper, ExplorerEr.RootName, ExplorerEr.RootName);

        private void TabItemsOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OpenTabItemInNewWindowCommand.RaiseCanExecuteChanged();
            CloseAllTabsCommand.RaiseCanExecuteChanged();
        }

        #endregion
    }
}