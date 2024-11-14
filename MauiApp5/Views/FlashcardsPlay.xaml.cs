// FlashcardsPlay.xaml.cs
using MauiApp5.Models;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace MauiApp5.Views
{
    public partial class FlashcardsPlay : ContentPage
    {
        private ObservableCollection<Flashcard> _flashcards;
        private int _currentIndex;
        public FlashcardsPlay(ObservableCollection<Flashcard> flashcards)
        {
            InitializeComponent();
            _flashcards = flashcards;
            _currentIndex = 0;

            // kuvab esimese flashcardi
            ShowFlashcard();
        }

        private void ShowFlashcard()
        {
            if (_flashcards.Count > 0)
            {
                var currentFlashcard = _flashcards[_currentIndex];
                questionLabel.Text = currentFlashcard.Question;
                answerLabel.Text = currentFlashcard.Answer;
                answerLabel.IsVisible = false; //peidab algul vastuse
            }
        }

        private void OnShowAnswerClicked(object sender, EventArgs e)
        {
            answerLabel.IsVisible = true;
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            //liigub järgmisele kaardile
            _currentIndex++;
            if (_currentIndex >= _flashcards.Count)
            {
                // küsib kasutajalt kas restart v avalehele
                bool restart = await DisplayAlert("Läbi!",
                    "naaseme avalehele või alustame uuesti?",
                    "alusta uuesti",
                    "avalehele");

                if(restart)
                {
                    _currentIndex = 0; //alustab uuesti
                }
                else
                {
                    // avalehele
                    await Navigation.PopToRootAsync();
                    return;
                }
            }


            ShowFlashcard();
        }
    }
}
