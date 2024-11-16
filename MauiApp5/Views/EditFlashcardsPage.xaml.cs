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

        // Salvestamine
        public ICommand SaveChangesCommand { get; }

        public EditFlashcardsPage(FlashcardSet flashcardSet)
        {
            InitializeComponent();
            FlashcardSet = flashcardSet;
            SaveChangesCommand = new Command(OnSaveChanges);
            BindingContext = this;

            // Alati on vähemalt 1 Flashcard
            if (FlashcardSet.Flashcards.Count == 0)
            {
                FlashcardSet.Flashcards.Add(new Flashcard { Number = 1 });
            }
            RenumberFlashcards();
        }
        // Pärast salvestamist, nummerdatakse kaardid uuesti
        private void RenumberFlashcards()
        {
            int counter = 1;
            foreach (var flashcard in FlashcardSet.Flashcards)
            {
                flashcard.Number = counter++;
            }
        }

        // Flashcards muutmine ja uue lisamine vajadusel
        private void OnQuestionTextChanged(object sender, TextChangedEventArgs e)
        {
            var lastFlashcard = FlashcardSet.Flashcards[^1];
            if (!string.IsNullOrWhiteSpace(lastFlashcard.Question))
            {
                FlashcardSet.Flashcards.Add(new Flashcard { Number = FlashcardSet.Flashcards.Count + 1 });
            }
        }

        // Salvesta muutused
        private async void OnSaveChanges()
        {
            await _storageService.SaveFlashcardSetsAsync(new List<FlashcardSet> { FlashcardSet });
            await Navigation.PopAsync(); // Tagasi eelmisele lehele
        }

        private void OnRemoveFlashcardClicked(object sender, EventArgs e)
        {
            var flashcard = (Flashcard)((Button)sender).CommandParameter;

            // Kustuta Flashcard 
            FlashcardSet.Flashcards.Remove(flashcard);

            // Kui Flashcards = 0, Lisa uus flashcard
            if (FlashcardSet.Flashcards.Count == 0)
            {
                FlashcardSet.Flashcards.Add(new Flashcard { Number = 1 });
            }
        }


    }
}
