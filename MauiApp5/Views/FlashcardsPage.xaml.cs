using System.Collections.ObjectModel;
using MauiApp5.Models;
using MauiApp5.Services;
using Microsoft.Maui.Controls;

namespace MauiApp5.Views
{
    public partial class FlashcardsPage : ContentPage
    {
        private readonly FlashcardStorageService _storageService = new FlashcardStorageService();
        public ObservableCollection<FlashcardSet> FlashcardSets { get; set; } = new ObservableCollection<FlashcardSet>();

        public FlashcardsPage()
        {
            InitializeComponent();
            BindingContext = this;
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

        private async void OnAddFlashcardSetClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddFlashcardsPage(FlashcardSets));
        }

        private async void OnDeleteFlashcardSetClicked(object sender, EventArgs e)
        {
            var flashcardSet = (FlashcardSet)((ImageButton)sender).CommandParameter;
            bool confirm = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this flashcard set?", "Yes", "No");
            if (confirm)
            {
                FlashcardSets.Remove(flashcardSet);
                await _storageService.SaveFlashcardSetsAsync(FlashcardSets.ToList());
            }
        }
        private async void OnEditFlashcardSetClicked(object sender, EventArgs e)
        {
            var flashcardSet = (FlashcardSet)((ImageButton)sender).CommandParameter;
            await Navigation.PushAsync(new EditFlashcardsPage(flashcardSet));
        }
    }
}

