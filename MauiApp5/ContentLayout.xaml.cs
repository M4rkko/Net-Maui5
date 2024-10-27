namespace MauiApp5;

public partial class ContentLayout : ContentView
{
	public ContentLayout()
	{
		InitializeComponent();
	}
    private async void GoToMain(object sender, EventArgs args)
    {
        await Navigation.PushAsync(new NewPage3());
    }
}