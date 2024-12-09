using MauiApp5.Models;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace MauiApp5.Views
{
	public partial class FlashcardsPlay : ContentPage
	{
		private readonly ObservableCollection<Flashcard> _flashcards;
		private int _currentIndex;
		private bool _isShowingQuestion;

		public FlashcardsPlay(ObservableCollection<Flashcard> flashcards)
		{
			InitializeComponent();
			_flashcards = flashcards ?? new ObservableCollection<Flashcard>();
			_currentIndex = 0;
			_isShowingQuestion = true;

			if (_flashcards.Count > 0)
			{
				ShowFlashcard();
			}
			else
			{
				DisplayAlert("No Flashcards", "Please add flashcards to start playing.", "OK");
			}
		}

		private void ShowFlashcard()
		{
			if (_flashcards.Count > 0)
			{
				var currentFlashcard = _flashcards[_currentIndex];
				questionLabel.Text = currentFlashcard.Question;
				answerLabel.Text = currentFlashcard.Answer;
				_isShowingQuestion = true;
				UpdateVisibility();
			}
		}

		private async void OnFlipCardClicked(object sender, EventArgs e)
		{
			// Perform flip animation
			await flashcardGrid.RotateYTo(90, 250);
			_isShowingQuestion = !_isShowingQuestion;
			UpdateVisibility();
			await flashcardGrid.RotateYTo(0, 250);
		}

		private void UpdateVisibility()
		{
			questionLabel.IsVisible = _isShowingQuestion;
			answerLabel.IsVisible = !_isShowingQuestion;
		}

		private async void OnNextClicked(object sender, EventArgs e)
		{
			_currentIndex++;
			if (_currentIndex >= _flashcards.Count)
			{
				bool restart = await DisplayAlert("All Done!", "Restart or go back to the home page?", "Restart", "Home");

				if (restart)
				{
					_currentIndex = 0; // Restart
				}
				else
				{
					await Navigation.PopToRootAsync(); // Go back to home
					return;
				}
			}

			ShowFlashcard();
		}
	}
}
