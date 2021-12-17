using System.IO;

namespace ExplorER
{
    public sealed class DirectoryViewModel : FileEntityViewModel
    {       
       

        public DirectoryViewModel(string direcrotyName) : base(direcrotyName)
        {
            FullName = direcrotyName;
        }
        public DirectoryViewModel(DirectoryInfo direcrotyName) : base(direcrotyName.Name)
        {
            FullName = direcrotyName.FullName;
        }
    }
}
