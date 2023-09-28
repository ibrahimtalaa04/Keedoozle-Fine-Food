using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Keedoozle_Fine_Food.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
