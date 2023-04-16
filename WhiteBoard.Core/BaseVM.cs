using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WhiteBoard.Core
{
    public class BaseVM : INotifyPropertyChanged
    {
        #region Public Methods

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion
    }
}