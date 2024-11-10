using System.Collections.ObjectModel;
using MauiApp5.Models;

namespace MauiApp5.Views
{
    public partial class FlashcardsPage : ContentPage
    {
        public ObservableCollection<FlashcardSet> FlashcardSets { get; set; } = new ObservableCollection<FlashcardSet>();

        public FlashcardsPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void OnAddFlashcardSetClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddFlashcardsPage(FlashcardSets));
        }

        private async void OnDeleteFlashcardSetClicked(object sender, EventArgs e)
        {
            var flashcardSet = (FlashcardSet)((Button)sender).CommandParameter;
            bool confirm = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this flashcard set?", "Yes", "No");
            if (confirm)
            {
                FlashcardSets.Remove(flashcardSet);
            }
        }
    }
}

