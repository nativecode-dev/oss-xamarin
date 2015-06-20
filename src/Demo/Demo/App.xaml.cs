namespace Demo
{
    using Demo.Views;

    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            ShowChooser();
        }

        internal static MasterDetailPage MasterDetail { get; private set; }

        internal static INavigation Navigation { get; private set; }

        public static void ShowChooser()
        {
            Current.MainPage = new ChooserView();
        }

        public static void ShowMasterDetailPatternOne()
        {
            var master = CreateMasterDetailPage(new MenuView(), new MainView());
            Current.MainPage = CreateNavigationPage(master);
        }

        public static void ShowMasterDetailPatternTwo()
        {
            var master = CreateMasterDetailPage(new MenuView(), CreateNavigationPage(new MainView()));
            Current.MainPage = master;
        }

        private static MasterDetailPage CreateMasterDetailPage(Page master, Page detail)
        {
            return MasterDetail = new MasterDetailPage { Detail = detail, Master = master, MasterBehavior = GetMasterBehavior(), Title = "AppCompat Demo" };
        }

        private static NavigationPage CreateNavigationPage(Page page)
        {
            var navigation = new NavigationPage(page);

            navigation.Popped += (sender, args) => HideMenu();
            navigation.PoppedToRoot += (sender, args) => HideMenu();
            navigation.Pushed += (sender, args) => HideMenu();

            Navigation = navigation.Navigation;

            return navigation;
        }

        private static MasterBehavior GetMasterBehavior()
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                return MasterBehavior.Popover;
            }

            return MasterBehavior.SplitOnLandscape;
        }

        private static void HideMenu()
        {
            if (MasterDetail.MasterBehavior == MasterBehavior.Popover)
            {
                MasterDetail.IsPresented = false;
            }
        }
    }
}