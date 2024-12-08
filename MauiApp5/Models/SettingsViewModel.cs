using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace MauiApp5.ViewModels
{
	public class SettingsViewModel : INotifyPropertyChanged
	{
		private bool _isDarkMode;

		public bool IsDarkMode
		{
			get => _isDarkMode;
			set
			{
				if (_isDarkMode != value)
				{
					_isDarkMode = value;
					OnPropertyChanged();
					UpdateTheme();
				}
			}
		}

		public SettingsViewModel()
		{
			// Load saved theme preference from Preferences (default to false for Light Mode)
			_isDarkMode = Preferences.Get("IsDarkMode", false);
		}

		private void UpdateTheme()
		{
			// Apply the theme based on the switch's value
			Application.Current.UserAppTheme = _isDarkMode ? AppTheme.Dark : AppTheme.Light;
			// Save the current preference to persist the setting
			Preferences.Set("IsDarkMode", _isDarkMode);
		}

		// Mark the PropertyChanged event as nullable
		public event PropertyChangedEventHandler? PropertyChanged;

		// Trigger the PropertyChanged event when a property value changes
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
