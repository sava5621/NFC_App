using Bumptech.Glide.Load.Engine;
using NFC_App.View;

namespace NFC_App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new LoadPage();
	}
}
