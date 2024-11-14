using System.Collections.ObjectModel;
using MauiApp5.Models;
using MauiApp5.Views;

namespace MauiApp5;

public partial class ContentLayout : ContentView
{
    private ObservableCollection<Flashcard> flashcards;

    public ContentLayout()
    {
        InitializeComponent();

        // loob flashcards objekti
        flashcards = new ObservableCollection<Flashcard>();

        // edastab nii Navigation kui ka flashcards MenuEvents konstruktorisse
        BindingContext = new MenuEvents(Navigation, flashcards);
    }
}
