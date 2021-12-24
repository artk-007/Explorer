using ExplorER.FilePresenters.Base;

namespace ExplorER.FilePresenters
{
    public class TileFilesPresenterViewModel : BaseFilesPresenter
    {
        public TileFilesPresenterViewModel(DirectoryTabItemViewModel directoryTabItemView, string directoryPathName) :
            base(directoryTabItemView, directoryPathName)
        {
        }
    }
}