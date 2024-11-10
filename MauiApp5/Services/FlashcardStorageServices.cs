using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using MauiApp5.Models;

namespace MauiApp5.Services
{
    public class FlashcardStorageService
    {
        private readonly string filePath;

        public FlashcardStorageService()
        {
            // Sets save path
            filePath = Path.Combine(FileSystem.AppDataDirectory, "flashcardSets.json");
        }

        // Save all JSON
        public async Task SaveFlashcardSetsAsync(List<FlashcardSet> flashcardSets)
        {
            var json = JsonSerializer.Serialize(flashcardSets);
            await File.WriteAllTextAsync(filePath, json);
        }

        // Load JSON
        public async Task<List<FlashcardSet>> LoadFlashcardSetsAsync()
        {
            if (!File.Exists(filePath))
                return new List<FlashcardSet>();

            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<List<FlashcardSet>>(json) ?? new List<FlashcardSet>();
        }
    }
}
