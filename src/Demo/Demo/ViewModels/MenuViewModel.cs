namespace Demo.ViewModels
{
    using System.Windows.Input;

    using Demo.Views;

    using PropertyChanged;

    using Xamarin.Forms;

    public class MenuViewModel : ViewModel
    {
        public MenuViewModel()
        {
            this.HomeCommand = new Command(App.ShowChooser);
            this.LoremIpsumCommand = new Command(async () => await App.Navigation.PushAsync(new LoremIpsumView()));
            this.NavigationCommand = new Command(async () => await App.Navigation.PushAsync(new NestNavigationView()));

            this.Title = "Menu";
        }

        [DoNotNotify]
        public ICommand HomeCommand { get; private set; }

        [DoNotNotify]
        public ICommand LoremIpsumCommand { get; private set; }

        [DoNotNotify]
        public ICommand NavigationCommand { get; private set; }
    }
}