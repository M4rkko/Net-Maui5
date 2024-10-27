using System.Windows.Input;

namespace MauiApp5;

public partial class ContentLayout : ContentView
{
 
	public ContentLayout()
	{
       
		InitializeComponent();
        BindingContext = new MenuEvents(Navigation);
    }
        
    
}