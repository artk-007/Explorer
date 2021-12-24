using System;
using System.IO;
using ExplorER.FileEntities.Base;

namespace ExplorER.FileEntities
{
    public class DirectoryViewModel : FileEntityViewModel
    {
        private readonly DirectoryInfo _directoryName;

        public DirectoryViewModel(DirectoryInfo directoryName) : base(directoryName.Name)
        {
            _directoryName = directoryName;
            FullName = directoryName.FullName;
        }

        public override DateTime ChangeDateTime => _directoryName.LastWriteTime;

        public override string GetRootName()
            => new DirectoryInfo(FullName).Root.Name;
    }
}