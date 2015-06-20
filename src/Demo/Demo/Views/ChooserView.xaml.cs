namespace Demo.Views
{
    using Demo.ViewModels;

    using Xamarin.Forms;

    public partial class ChooserView : ContentPage
    {
        public ChooserView()
        {
            this.InitializeComponent();
            this.BindingContext = new ChooserViewModel();
        }
    }
}