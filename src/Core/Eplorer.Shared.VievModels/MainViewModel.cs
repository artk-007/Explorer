using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Eplorer.Shared.VievModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Public Properties

        public string MainDiskName { get; set; }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor

        public MainViewModel()
        {
            MainDiskName = Environment.SystemDirectory;
        }

        #endregion

        #region Protected Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
