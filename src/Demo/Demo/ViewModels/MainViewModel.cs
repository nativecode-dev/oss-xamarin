namespace Demo.ViewModels
{
    using System.Windows.Input;

    using NativeCode.Mobile.AppCompat.Controls;
    using NativeCode.Mobile.AppCompat.Controls.Platforms;

    using PropertyChanged;

    using Xamarin.Forms;

    public class MainViewModel : ViewModel
    {
        private int counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.FloatingButtonCommand = new Command(this.HandleFloatingButtonCommand);
            this.ShowSnackBar = new Command(this.HandleShowSnackBar);
            this.Title = "Main";
        }

        [DoNotNotify]
        public ICommand FloatingButtonCommand { get; private set; }

        [DoNotNotify]
        public ICommand ShowSnackBar { get; private set; }

        private void HandleFloatingButtonCommand()
        {
        }

        private void HandleShowSnackBar()
        {
            var notifier = DependencyService.Get<IUserNotifier>();
            notifier.NotifyShort(string.Format("You hit me {0} times!!!", ++this.counter));
        }
    }
}