namespace NativeCode.Mobile.AppCompat.Controls
{
    using Xamarin.Forms;

    public class NavigationLayout : Layout<NavigationLayoutMenu>
    {
        public static readonly BindableProperty HeaderViewProperty = BindableProperty.Create<NavigationLayout, ContentView>(
            x => x.HeaderView,
            default(ContentView));

        public ContentView HeaderView
        {
            get { return (ContentView)this.GetValue(HeaderViewProperty); }
            set { this.SetValue(HeaderViewProperty, value); }
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
        }
    }
}