namespace NativeCode.Mobile.AppCompat.Controls
{
    using NativeCode.Mobile.AppCompat.Controls.Platforms;

    using Xamarin.Forms;

    public class NavigationLayout : Layout<NavigationLayoutMenu>
    {
        public static readonly BindableProperty HeaderViewProperty = BindableProperty.Create<NavigationLayout, NavigationLayoutHeader>(
            x => x.HeaderView,
            default(NavigationLayoutHeader));

        public NavigationLayoutHeader HeaderView
        {
            get { return (NavigationLayoutHeader)this.GetValue(HeaderViewProperty); }
            set { this.SetValue(HeaderViewProperty, value); }
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
        }
    }
}