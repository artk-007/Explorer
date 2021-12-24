﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using ExplorER.FileEntities;
using ExplorER.FileEntities.Base;

namespace ExplorER
{
    /// <summary>
    /// Основное приложение проводника chromER
    /// </summary>
    public sealed class ExplorerEr
    {
        private readonly ISynchronizationHelper _synchronizationHelper;
        private readonly ITabClient _tabClient;
        private readonly Action<TabsViewModel, Point> _windowFactory;

        #region Singleton

        public static ExplorerEr Instance { get; private set; }

        public static void CreateChromer(ISynchronizationHelper helper, ITabClient tabClient,
            Action<TabsViewModel, Point> windowFactory)
        {
            if (Instance == null)
            {
                CultureInfo currentCulture = new("Ru-ru");
                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentCulture;

                Instance = new ExplorerEr(helper, tabClient, windowFactory);
            }
        }

        public static string RootName = "Мой компьютер";

        #endregion

        #region Public Properties

        //public TabsViewModel TabsViewModel { get; }

        /// <summary>
        /// Менеджер иконок
        /// </summary>
        public IIconsManager IconsManager { get; }

        /// <summary>
        /// Менеджер закладок
        /// </summary>
        public IBookmarksManager BookmarksManager { get; }

        public DelegateCommand OpenNewWindowCommand { get; }

        #endregion

        #region Constructor

        private ExplorerEr(ISynchronizationHelper synchronizationHelper,
            ITabClient tabClient,
            Action<TabsViewModel, Point> windowFactory)
        {
            _synchronizationHelper = synchronizationHelper;
            _tabClient = tabClient;
            _windowFactory = windowFactory;

            var converter = new ExtensionToImageFileConverter();

            OpenNewWindowCommand = new DelegateCommand(OnOpenNewWindow);

            IconsManager = new IconsManager(converter);
            BookmarksManager = new BookmarksManager(converter);
        }

        #endregion

        public TabsViewModel CreateMainViewModel(IEnumerable<DirectoryTabItemViewModel> initItems)
            => new(_synchronizationHelper, _tabClient, initItems);

        public void OpenTabInNewWindow(DirectoryTabItemViewModel directoryTabItemView)
        {
            var mainViewModel = CreateMainViewModel(new DirectoryTabItemViewModel[0]);

            mainViewModel.TabItems.Add(directoryTabItemView);

            _windowFactory.Invoke(mainViewModel, new Point(24, 24));
        }

        private void OnOpenNewWindow(object parameter)
        {
            if (parameter is FileEntityViewModel fileEntityViewModel)
            {
                if (fileEntityViewModel is DirectoryViewModel directoryViewModel)
                {
                    var myCompTabVm = new DirectoryTabItemViewModel(
                        _synchronizationHelper,
                        directoryViewModel.FullName,
                        directoryViewModel.Name);

                    OpenTabInNewWindow(myCompTabVm);
                }
            }
        }
    }

    public interface ITabClient
    {
    }
}