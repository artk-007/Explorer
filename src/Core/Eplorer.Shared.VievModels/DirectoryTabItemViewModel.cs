using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace Eplorer.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region Public Properties

        public string FilePath { get; set; }

        public string Name { get; set; }

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } =
            new ObservableCollection<FileEntityViewModel>();

        public FileEntityViewModel SelectedFileEntity { get; set; }
     
        #endregion
        
        #region Comands

        public ICommand OpenCommand { get; }
        public ICommand CloseCommand { get; }

        #endregion

        #region Events

        public event ErrorEventHandler Closed;

        #endregion

        #region Constructor

        public DirectoryTabItemViewModel()
        {

            Name = "Мой компьютер";

            OpenCommand = new DelegateCommand(Open);
            CloseCommand = new DelegateCommand(OnClose);

            foreach (var logicalDrive in Directory.GetLogicalDrives())
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
        }

        

        #endregion

        #region Protected Methods
        #endregion

        #region Commands Methods

        private void Open(object parametr)
        {
            if (parametr is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;

                Name = directoryViewModel.Name;

                DirectoriesAndFiles.Clear();

                var directoryInfo = new DirectoryInfo(FilePath);

                foreach (var directory in directoryInfo.GetDirectories())
                {
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directory));
                }
                foreach (var fileInfo in directoryInfo.GetFiles())
                {
                    DirectoriesAndFiles.Add(new FileViewModel(fileInfo));
                }
            }
        }
        private void OnClose(object obj)
        {
            Closed?.Invoke(this, null); //Что то не так надо будет исправить
        }
        #endregion
    }
}   
