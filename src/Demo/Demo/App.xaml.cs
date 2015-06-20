namespace Demo
{
    using Demo.Views;

    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.MainPage = CreateMainPage();
        }

        internal static MasterDetailPage MasterDetail { get; private set; }

        internal static INavigation Navigation { get; private set; }

        private static Page CreateMainPage()
        {
            var master = CreateMasterDetailPage(new MenuView(), new MainView());
            var navigation = CreateNavigationPage(master);

            return navigation;
        }

        private static MasterDetailPage CreateMasterDetailPage(Page master, Page detail)
        {
            return MasterDetail = new MasterDetailPage { Detail = detail, Master = master, MasterBehavior = MasterBehavior.Popover, Title = "AppCompat Demo" };
        }

        private static NavigationPage CreateNavigationPage(Page page)
        {
            var navigation = new NavigationPage(page);

            navigation.Popped += (sender, args) => MasterDetail.IsPresented = false;
            navigation.PoppedToRoot += (sender, args) => MasterDetail.IsPresented = false;
            navigation.Pushed += (sender, args) => MasterDetail.IsPresented = false;

            Navigation = navigation.Navigation;

            return navigation;
        }
    }
}