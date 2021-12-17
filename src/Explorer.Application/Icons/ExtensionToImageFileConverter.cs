using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExplorER
{
    internal class ExtensionToImageFileConverter
    {
        private  Dictionary<string, FileInfo> _icons;
        //private  readonly IconSettings _settings;

        #region Constructor

        public ExtensionToImageFileConverter()
        {
            var applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var iconsDirectory = new DirectoryInfo(Path.Combine(applicationDirectory, "Icons","Resources", "Icons"));

            _icons = iconsDirectory
                .GetFiles()
                .ToDictionary(fi => GetNameWithoutExtension(fi.Name));

        }

        #endregion

        #region Public Methods
        public FileInfo GetImagePath(string extension)
        {

            if (_icons.ContainsKey(extension.ToUpper()))
            {
                return _icons[extension.ToUpper()];
            }

            return _icons[IconName.Blank.ToUpper()];
        }

        #endregion


        private string GetNameWithoutExtension(string fileName)
        {
            var parts = fileName.Split(new[] {'.'});
            if (parts.Length > 0)
                return parts[0].ToUpper();

            return "._";
        }
    }

   
}
