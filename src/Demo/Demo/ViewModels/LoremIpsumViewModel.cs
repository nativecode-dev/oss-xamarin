namespace Demo.ViewModels
{
    using System.IO;
    using System.Reflection;
    using System.Windows.Input;

    using NativeCode.Mobile.AppCompat.Controls.Platforms;

    using PropertyChanged;

    using Xamarin.Forms;

    public class LoremIpsumViewModel : ViewModel
    {
        private const string LoremIpsumResourceKey = "Demo.Resources.loremipsum.txt";

        public LoremIpsumViewModel()
        {
            this.AddTextCommand = new Command(this.ExecuteAddText);
            this.Text = this.GetResourceText();
            this.Title = "More Lorem Ipsum?";
        }

        [DoNotNotify]
        public ICommand AddTextCommand { get; private set; }

        public string Text { get; set; }

        private void ExecuteAddText()
        {
            this.Text += this.GetResourceText();
            var notifier = DependencyService.Get<IUserNotifier>();
            notifier.NotifyShort(string.Format("Text is now {0} characters long.", this.Text.Length));
        }

        private string GetResourceText()
        {
            var stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(LoremIpsumResourceKey);

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}