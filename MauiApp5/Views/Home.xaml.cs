using MauiApp5.Models;
using System.Collections.ObjectModel;

namespace MauiApp5.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

	// nupu vajutusel käivitub
	private async void OnPlayFlashcardsButtonClicked(object sender, EventArgs e)
	{
		var selectedFlashcards = new ObservableCollection<Flashcard>
		{
			new Flashcard { Number = 1, Question = "Capital of france", Answer = "paris"},
			new Flashcard { Number = 2, Question = "Capital of germany", Answer = "berlin"}
		};

		await Navigation.PushAsync(new FlashcardsPlay(selectedFlashcards));
	}
	
}