using System.Collections.Generic;

namespace ExplorER
{
    internal class BookmarkItem
    {
        public string Path { get; set; }

        public string BookmarkFolderName { get; set; }
        public List<BookmarkItem> Children { get; set; }
    }
}
