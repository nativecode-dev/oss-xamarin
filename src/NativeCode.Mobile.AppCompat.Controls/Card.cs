namespace NativeCode.Mobile.AppCompat.Controls
{
    using Xamarin.Forms;

    public class Card : ContentView
    {
        public static readonly BindableProperty RadiusProperty = BindableProperty.Create<Card, double>(x => x.Radius, 10.0d);

        public Card()
        {
            this.Padding = new Thickness(20);
        }

        public double Radius
        {
            get { return (double)this.GetValue(RadiusProperty); }
            set { this.SetValue(RadiusProperty, value); }
        }

        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            if (this.Content != null)
            {
                return this.Content.GetSizeRequest(widthConstraint, heightConstraint);
            }

            return base.OnSizeRequest(widthConstraint, heightConstraint);
        }
    }
}