using ExplorER.FilePresenters.Base;

namespace ExplorER.FilePresenters
{
    public class GridFilesPresenterViewModel : BaseFilesPresenter
    {
        public GridFilesPresenterViewModel(DirectoryTabItemViewModel directoryTabItemView, string directoryPathName) :
            base(directoryTabItemView, directoryPathName)
        {
        }
    }
}