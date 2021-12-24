using System;
using ExplorER.FileEntities.Base;

namespace ExplorER.FilePresenters.Base.Core
{
    public class OpenDirectoryEventArgs : EventArgs
    {
        public FileEntityViewModel FileEntityViewModel { get; }

        public OpenDirectoryEventArgs(FileEntityViewModel fileEntityViewModel)
        {
            FileEntityViewModel = fileEntityViewModel;
        }
    }
}