namespace Demo.ViewModels
{
    using System.Windows.Input;

    using Demo.Views;

    using Xamarin.Forms;

    public class NestNavigationViewModel : ViewModel
    {
        public NestNavigationViewModel()
        {
            this.PopCommand = new Command(async () => await App.Navigation.PopAsync());
            this.PushCommand = new Command(async () => await App.Navigation.PushAsync(new NestNavigationView()));
            this.RootCommand = new Command(async () => await App.Navigation.PopToRootAsync());
        }

        public ICommand PopCommand { get; private set; }

        public ICommand PushCommand { get; private set; }

        public ICommand RootCommand { get; private set; }
    }
}