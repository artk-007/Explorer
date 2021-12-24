using System.Collections.Generic;

namespace ExplorER
{
    /// <summary>
    /// Менеджер закладок
    /// </summary>
    public interface IBookmarksManager
    {
        IReadOnlyCollection<MenuItemViewModel> Bookmarks { get; }
        DelegateCommand AddBookmarkCommand { get; }
    }
}