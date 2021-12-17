namespace ExplorER
{
    public sealed class ExplorerEr
    {
        #region Singleton

        public static ExplorerEr Instance { get; private set; }
        
        public static void CreateExplorerEr(ISynchronizationHelper helper)
        {
            if (Instance == null)
            {
                Instance = new ExplorerEr(helper);
            }
        }

        #endregion

        #region Public Properties
        public MainViewModel MainViewModel { get; }

        /// <summary>
        /// Менеджер иконок
        /// </summary>
        public IIconsManager IconsManager { get; }

        /// <summary>
        /// Менеджер закладок
        /// </summary>
        public IBookmarksManager BookmarksManager { get; }

        #endregion

        #region Constructor
        /// <summary>
        /// Менеджер иконок
        /// </summary>

        private ExplorerEr(ISynchronizationHelper synchronizationHelper)
        {
            MainViewModel = new MainViewModel(synchronizationHelper);

            IconsManager = new IconsManager(new ExtensionToImageFileConverter());
            BookmarksManager = new BookmarksManager(MainViewModel);
        }

        #endregion
    }
}
