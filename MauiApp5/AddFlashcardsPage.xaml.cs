using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp5.Models;
using Microsoft.Maui.Controls;

namespace MauiApp5.Views
{
    public partial class AddFlashcardsPage : ContentPage
    {
        public FlashcardSet NewFlashcardSet { get; set; } = new FlashcardSet();
        public ObservableCollection<FlashcardSet> FlashcardSets { get; }

        // Command to bind to the save button
        public ICommand SaveFlashcardSetCommand { get; }

        public AddFlashcardsPage(ObservableCollection<FlashcardSet> flashcardSets)
        {
            InitializeComponent();
            FlashcardSets = flashcardSets;

            // Initialize command and bind context
            SaveFlashcardSetCommand = new Command(OnSaveFlashcardSet);
            BindingContext = this;

            // Start with a new flashcard
            NewFlashcardSet.Flashcards.Add(new Flashcard { Number = 1 });
        }

        private void OnQuestionTextChanged(object sender, TextChangedEventArgs e)
        {
            var lastFlashcard = NewFlashcardSet.Flashcards[^1];
            if (!string.IsNullOrWhiteSpace(lastFlashcard.Question))
            {
                NewFlashcardSet.Flashcards.Add(new Flashcard { Number = NewFlashcardSet.Flashcards.Count + 1 });
            }
        }

        private async void OnSaveFlashcardSet()
        {
            if (!string.IsNullOrWhiteSpace(NewFlashcardSet.Name) && NewFlashcardSet.Flashcards.Any(f => !string.IsNullOrWhiteSpace(f.Question)))
            {
                FlashcardSets.Add(NewFlashcardSet); // Save to the provided collection
                await Navigation.PopAsync(); // Navigate back
            }
            else
            {
                await DisplayAlert("Error", "Please provide a set name and at least one flashcard.", "OK");
            }
        }
    }
}
