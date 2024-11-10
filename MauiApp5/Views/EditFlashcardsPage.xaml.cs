using MauiApp5.Models;
using MauiApp5.Services;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Windows.Input;

namespace MauiApp5.Views
{
    public partial class EditFlashcardsPage : ContentPage
    {
        private readonly FlashcardStorageService _storageService = new FlashcardStorageService();
        public FlashcardSet FlashcardSet { get; set; }

        // Command to save
        public ICommand SaveChangesCommand { get; }

        public EditFlashcardsPage(FlashcardSet flashcardSet)
        {
            InitializeComponent();
            FlashcardSet = flashcardSet;
            SaveChangesCommand = new Command(OnSaveChanges);
            BindingContext = this;
        }

        // Text change and Add new card if needed
        private void OnQuestionTextChanged(object sender, TextChangedEventArgs e)
        {
            var lastFlashcard = FlashcardSet.Flashcards[^1];
            if (!string.IsNullOrWhiteSpace(lastFlashcard.Question))
            {
                FlashcardSet.Flashcards.Add(new Flashcard { Number = FlashcardSet.Flashcards.Count + 1 });
            }
        }

        // Save the changes to the flashcardSet
        private async void OnSaveChanges()
        {
            await _storageService.SaveFlashcardSetsAsync(new List<FlashcardSet> { FlashcardSet });
            await Navigation.PopAsync(); // Go back to the previous page
        }
    }
}
