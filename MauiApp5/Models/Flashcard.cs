using System.Collections.ObjectModel;

namespace MauiApp5.Models
{
    public class Flashcard
    {
        public int Number { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    public class FlashcardSet
    {
        public string Name { get; set; }
        public ObservableCollection<Flashcard> Flashcards { get; set; } = new ObservableCollection<Flashcard>();
    }
}
