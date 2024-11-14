using System.Windows.Input;
using MauiApp5.Views;
using System.Collections.ObjectModel;
using MauiApp5.Models;

namespace MauiApp5
{
    class MenuEvents
    {
        public ICommand GoToCommand { get; }
        public INavigation Navigation { get; set; }
        private ObservableCollection<Flashcard> flashcards; // Lisa privaatne väli flashcards

        // Uuendatud konstruktor
        public MenuEvents(INavigation navigation, ObservableCollection<Flashcard> flashcards)
        {
            GoToCommand = new Command<string>(GoToPage);
            Navigation = navigation;
            this.flashcards = flashcards; // Määra flashcards privaatsele väljal
        }

        private async void GoToPage(string pageName)
        {
            switch (pageName)
            {
                case "Page-1":
                    await Navigation.PushAsync(new HomePage());
                    break;

                case "Page-2":
                    await Navigation.PushAsync(new FlashcardsPage());
                    break;

                case "FlashcardsPlay":
                    await Navigation.PushAsync(new FlashcardsPlay(flashcards)); // Edasta flashcards siin
                    break;

                case "Page-3":
                    await Navigation.PushAsync(new NewPage3());
                    break;

                case "Page-4":
                    await Navigation.PushAsync(new NewPage4());
                    break;

                case "Page-5":
                    await Navigation.PushAsync(new NewPage5());
                    break;
            }
        }
    }
}
