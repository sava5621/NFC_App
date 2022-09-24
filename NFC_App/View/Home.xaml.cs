namespace NFC_App.View;

public partial class Home : ContentPage
{
	public Home(HomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}