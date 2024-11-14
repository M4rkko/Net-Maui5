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

        // Loo flashcards objekt
        flashcards = new ObservableCollection<Flashcard>();

        // Edasta nii Navigation kui ka flashcards MenuEvents konstruktorisse
        BindingContext = new MenuEvents(Navigation, flashcards);
    }
}
