using System.Windows.Input;

namespace MauiApp5
{
    class MenuEvents
    {
        public ICommand GoToCommand { get; }
        public INavigation Navigation { get; set; }
        public MenuEvents(INavigation navigation)
        {
            GoToCommand = new Command<string>(GoToPage);
            Navigation = navigation;
        }
        private async void GoToPage(string pageName)
        {
            ////if (pageName.CompareTo("Page-3") == 0)
            //{
                //await Navigation.PushAsync(new NewPage3());
            //}
            switch (pageName)
            {
                case "Page-1":
                    await Navigation.PushAsync(new NewPage1());
                    break;

                case "Page-2":
                    await Navigation.PushAsync(new NewPage2());
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
