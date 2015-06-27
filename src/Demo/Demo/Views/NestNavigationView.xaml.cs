namespace Demo.Views
{
    using Demo.ViewModels;

    using Xamarin.Forms;

    public partial class NestNavigationView : ContentPage
    {
        public NestNavigationView()
        {
            this.InitializeComponent();
            this.BindingContext = new NestNavigationViewModel();
        }
    }
}