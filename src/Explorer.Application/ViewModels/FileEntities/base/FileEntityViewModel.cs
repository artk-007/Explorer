using System;
using ExplorER.Base;

namespace ExplorER.FileEntities.Base
{
    public abstract class FileEntityViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public string Group { get; set; } 

        public abstract DateTime ChangeDateTime { get; }

        protected FileEntityViewModel(string name)
        {
            Name = name;
        }

        public abstract string GetRootName();    
    }
}