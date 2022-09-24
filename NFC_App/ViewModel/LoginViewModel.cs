using CommunityToolkit.Mvvm.Input;
using NFC_App.Services;
using NFC_App.View;
using static Android.Icu.Text.CaseMap;

namespace NFC_App.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        string login;
        [ObservableProperty]
        string pass;
        [RelayCommand]
        async void LoginUser()
        {
            if (await ApiServices.LoginAsync(login, pass))
            {
                App.Current.MainPage =new MainPage();
            }
            else
            {
                pass = String.Empty;
                //TODO: когда будет шел настроить уведомления
            }
        }
    }
}
