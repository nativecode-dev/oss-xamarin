namespace Demo.Views
{
    using Demo.ViewModels;

    using Xamarin.Forms;

    public partial class MainView : ContentPage
    {
        public MainView()
        {
            this.InitializeComponent();
            this.BindingContext = new MainViewModel();

            this.ToolbarItems.Add(new ToolbarItem("Action Item 1", null, () => { }, ToolbarItemOrder.Secondary));
            this.ToolbarItems.Add(new ToolbarItem("Action Item 2", null, () => { }, ToolbarItemOrder.Secondary));
            this.ToolbarItems.Add(new ToolbarItem("Action Item 3", null, () => { }, ToolbarItemOrder.Secondary));
        }
    }
}