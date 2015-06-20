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
            this.HomeText = "Home";

            this.LoremIpsumCommand = new Command(async () => await App.Navigation.PushAsync(new LoremIpsumView()));
            this.LoremIpsumText = "Lorem Ipsum";

            this.Title = "Menu";
        }

        [DoNotNotify]
        public ICommand HomeCommand { get; private set; }

        public string HomeText { get; set; }

        [DoNotNotify]
        public ICommand LoremIpsumCommand { get; private set; }

        public string LoremIpsumText { get; set; }
    }
}