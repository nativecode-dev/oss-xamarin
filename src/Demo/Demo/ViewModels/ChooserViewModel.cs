namespace Demo.ViewModels
{
    using System.Windows.Input;

    using Xamarin.Forms;

    public class ChooserViewModel : ViewModel
    {
        public ChooserViewModel()
        {
            this.MasterDetailPatternOneCommand = new Command(App.ShowMasterDetailPatternOne);
            this.MasterDetailPatternTwoCommand = new Command(App.ShowMasterDetailPatternTwo);
            this.TabbedCommand = new Command(App.ShowTabbed);
        }

        public ICommand MasterDetailPatternOneCommand { get; private set; }

        public ICommand MasterDetailPatternTwoCommand { get; private set; }

        public ICommand TabbedCommand { get; private set; }
    }
}