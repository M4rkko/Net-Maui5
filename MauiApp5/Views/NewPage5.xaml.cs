using MauiApp5.ViewModels;

namespace MauiApp5.Views;

public partial class NewPage5 : ContentPage
{
	public NewPage5()
	{
        InitializeComponent();
		BindingContext = new SettingsViewModel();
	}
}