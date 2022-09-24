using NFC_App.View;

namespace NFC_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(Home), typeof(Home));
        InitializeComponent();
	}
}
