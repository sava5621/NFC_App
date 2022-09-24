using NFC_App.Model;
using NFC_App.Services;

namespace NFC_App.View;

public partial class LoadPage : ContentPage
{
	public LoadPage()
	{
		InitializeComponent();
		CheckToken();

    }
	async void CheckToken()
	{
		UserRefreshToken refreshToken = await LocalDBServices.GetToken();
		if (refreshToken != null)
		{
			if (await ApiServices.RefreshTokenAsync(refreshToken)) //если токен существует и правильный
			{
                List<ItemModel> items = await ApiServices.GetItem<List<ItemModel>>(TokenServices.AccessToken, "/ItemsTest"); 
				if (items != null)
				{
					foreach (var i in items)
					{
						DataServices.Items.Add(i);
                    }
				}
                App.Current.MainPage = new MainPage();
            }
            App.Current.MainPage = new LoginPage(new LoginViewModel()); // если токен не правильный 
        }
		else
		{
			App.Current.MainPage = new LoginPage(new LoginViewModel());
		}
	}
}