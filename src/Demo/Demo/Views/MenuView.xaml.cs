namespace Demo.Views
{
    using Demo.ViewModels;

    using Xamarin.Forms;

    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            this.InitializeComponent();
            this.BindingContext = new MenuViewModel();
        }
    }
}