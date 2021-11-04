using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Eplorer.Shared.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
     
        #region Protected Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
