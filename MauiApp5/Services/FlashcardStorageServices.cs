using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using MauiApp5.Models;
using System.Collections.ObjectModel;

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
		public async Task<ObservableCollection<FlashcardSet>> LoadFlashcardSetsAsync()
		{
			try
			{
				if (!File.Exists(filePath))
					return new ObservableCollection<FlashcardSet>();

				var json = await File.ReadAllTextAsync(filePath);
				return JsonSerializer.Deserialize<ObservableCollection<FlashcardSet>>(json)
					   ?? new ObservableCollection<FlashcardSet>();
			}
			catch (Exception ex)
			{
				// Handle exceptions (e.g., logging)
				Console.WriteLine($"Error loading flashcard sets: {ex.Message}");
				return new ObservableCollection<FlashcardSet>();
			}
		}
	}
}
