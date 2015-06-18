namespace Demo.Views
{
    using Demo.ViewModels;

    using Xamarin.Forms;

    public partial class LoremIpsumView : ContentPage
    {
        public LoremIpsumView()
        {
            this.InitializeComponent();
            this.BindingContext = new LoremIpsumViewModel();
        }
    }
}