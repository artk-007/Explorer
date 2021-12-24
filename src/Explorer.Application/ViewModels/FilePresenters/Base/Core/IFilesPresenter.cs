using System;

namespace ExplorER.FilePresenters.Base.Core
{
    public interface IFilesPresenter : IDisposable
    {
        string CurrentDirectoryPathName { get; }

        event EventHandler<OpenDirectoryEventArgs> DirectoryOrFileOpened;
    }
}