using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp5.Models;
using MauiApp5.Services;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Threading.Tasks;

namespace MauiApp5.Views
{
    public partial class AddFlashcardsPage : ContentPage
    {
        private readonly FlashcardStorageService _storageService = new FlashcardStorageService();
        public FlashcardSet NewFlashcardSet { get; set; } = new FlashcardSet();
        public ObservableCollection<FlashcardSet> FlashcardSets { get; }

        // Command to bind to the save button
        public ICommand SaveFlashcardSetCommand { get; }

        public AddFlashcardsPage(ObservableCollection<FlashcardSet> flashcardSets)
        {
            InitializeComponent();
            FlashcardSets = flashcardSets;

            // Initialize command and bind context
            SaveFlashcardSetCommand = new Command(async() => await OnSaveFlashcardSet());
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

        private async Task OnSaveFlashcardSet()
        {
            if (!string.IsNullOrWhiteSpace(NewFlashcardSet.Name) && NewFlashcardSet.Flashcards.Any(f => !string.IsNullOrWhiteSpace(f.Question)))
            {
                FlashcardSets.Add(NewFlashcardSet); // Save to the provided collection
                await _storageService.SaveFlashcardSetsAsync(FlashcardSets.ToList()); // "Save all" to Storage
                await Navigation.PopAsync(); // Navigate back
            }
            else
            {
                await DisplayAlert("Error", "Please provide a set name and at least one flashcard.", "OK");
            }
        }
    }
}
