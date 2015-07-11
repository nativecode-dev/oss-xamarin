namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System.ComponentModel;

    using Android.Support.V7.Widget;
    using Android.Widget;

    using NativeCode.Mobile.AppCompat.Controls;
    using NativeCode.Mobile.AppCompat.EventListeners;
    using NativeCode.Mobile.AppCompat.Extensions;
    using NativeCode.Mobile.AppCompat.Helpers;
    using NativeCode.Mobile.AppCompat.Renderers.Extensions;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class CardRenderer : ViewRenderer<Card, CardView>
    {
        private OnClickListener onClickListener;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.onClickListener != null)
            {
                this.onClickListener.Dispose();
                this.onClickListener = null;
            }

            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Card> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var context = this.Context.GetAppCompatThemedContext();
                var control = new CardView(context);

                if (this.Element.Command != null)
                {
                    control.Clickable = true;
                    control.SetOnClickListener(this.onClickListener = new OnClickListener(v => this.Element.ExecuteCommand()));
                }

                this.SetNativeControl(control);

                this.UpdateCardBackgroundColor();
                this.UpdateContentPadding();
                this.UpdateElevation();
                this.UpdateRadius();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                this.UpdateCardBackgroundColor();
            }
            else if (e.PropertyName == Xamarin.Forms.Layout.PaddingProperty.PropertyName)
            {
                this.UpdateContentPadding();
            }
            else if (e.PropertyName == Card.ElevationProperty.PropertyName)
            {
                this.UpdateElevation();
            }
            else if (e.PropertyName == Card.RadiusProperty.PropertyName)
            {
                this.UpdateRadius();
            }
        }

        private void UpdateCardBackgroundColor()
        {
            this.Control.SetCardBackgroundColor(this.Element.BackgroundColor.ToAndroid());
        }

        private void UpdateContentPadding()
        {
            var bottom = (int)this.Element.Padding.Bottom;
            var left = (int)this.Element.Padding.Left;
            var right = (int)this.Element.Padding.Right;
            var top = (int)this.Element.Padding.Top;

            this.Control.SetContentPadding(left, top, right, bottom);
        }

        private void UpdateElevation()
        {
            this.Control.CardElevation = (float)this.Element.Elevation;
            var @params = new LinearLayout.LayoutParams(LayoutParamsHelper.MatchParent, LayoutParamsHelper.WrapContent);
            var elevation = (int)this.Control.CardElevation;
            @params.SetMargins(elevation, elevation, elevation, elevation);
            this.Control.LayoutParameters = @params;
        }

        private void UpdateRadius()
        {
            this.Control.Radius = (float)this.Element.Radius;
        }
    }
}