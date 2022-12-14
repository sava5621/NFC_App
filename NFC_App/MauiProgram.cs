global using CommunityToolkit.Mvvm.ComponentModel;
global using NFC_App.ViewModel;
using NFC_App.View;

namespace NFC_App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<Home>();
        return builder.Build();
	}
}
