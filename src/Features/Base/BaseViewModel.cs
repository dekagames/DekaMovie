using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace DekaMovie;
public abstract class BaseViewModel : ObservableObject
{
    bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }    
}
