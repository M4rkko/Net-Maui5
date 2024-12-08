using MauiApp5.Models;
using MauiApp5.Services;
using System.Collections.ObjectModel;

namespace MauiApp5.Views;

public partial class HomePage : ContentPage
{
	private readonly FlashcardStorageService _storageService = new FlashcardStorageService();
	public ObservableCollection<FlashcardSet> FlashcardSets { get; set; } = new ObservableCollection<FlashcardSet>();
	public FlashcardSet SelectedFlashcardSet { get; set; }

	public HomePage()
	{
		InitializeComponent();
		LoadFlashcardSets();
	}

	private async void LoadFlashcardSets()
	{
		var sets = await _storageService.LoadFlashcardSetsAsync();
		foreach (var set in sets)
		{
			FlashcardSets.Add(set);
		}
	}

	// nupu vajutusel käivitub
	private async void OnPlayFlashcardsButtonClicked(object sender, EventArgs e)
	{
		// reloadib, et oleks viimati lisatud set nähtaval
		var updatedSets = await _storageService.LoadFlashcardSetsAsync();

		// updateb seda
		FlashcardSets.Clear();
		foreach (var set in updatedSets)
		{
			FlashcardSets.Add(set);
		}

		if (FlashcardSets.Count == 0)
		{
			// kui pole flashcardsete
			await Application.Current.MainPage.DisplayAlert("No Flashcards available", "Please create a flashcard set before playing", "OK");
			return;
		}

		// kasutaja valib seti
		string[] setNames = FlashcardSets.Select(set => set.Name).ToArray();
		string selectedSetName = await DisplayActionSheet("Select a set to play", "cancel", null, setNames);

		if (selectedSetName == "cancel" || string.IsNullOrEmpty(selectedSetName))
		{
			// kasutaja canceldas või ei valind
			return;
		}

		// otsib valitud seti
		var selectedSet = FlashcardSets.FirstOrDefault(set => set.Name == selectedSetName);

		if (selectedSet != null)
		{
			await Navigation.PushAsync(new FlashcardsPlay(selectedSet.Flashcards));
		}
		else
		{
			await Application.Current.MainPage.DisplayAlert("Error", "Error occured while selecting the flashcard set.", "OK");
		}
	}
	
}