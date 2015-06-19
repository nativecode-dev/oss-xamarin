namespace NativeCode.Mobile.AppCompat.Controls
{
    using Xamarin.Forms;

    public class NavigationLayout : Layout<NavigationMenu>
    {
        public static readonly BindableProperty HeaderViewProperty = BindableProperty.Create<NavigationLayout, View>(x => x.HeaderView, default(View));

        public View HeaderView
        {
            get { return (View)this.GetValue(HeaderViewProperty); }
            set { this.SetValue(HeaderViewProperty, value); }
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
        }
    }
}