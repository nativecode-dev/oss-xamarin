using NativeCode.Mobile.AppCompat.Controls;
using NativeCode.Mobile.AppCompat.Renderers.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FloatingButton), typeof(FloatingButtonRenderer))]

namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System.ComponentModel;

    using Android.Support.Design.Widget;

    using NativeCode.Mobile.AppCompat.Controls;
    using NativeCode.Mobile.AppCompat.Extensions;

    using Xamarin.Forms.Platform.Android;

    public class FloatingButtonRenderer : InflateViewRenderer<FloatingButton, FloatingActionButton>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<FloatingButton> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var control = this.InflateFloatingActionButton();
                this.SetNativeControl(control);

                this.SetupClickable(this.Control, this.Element.Command, this.Element.CommandParameter);

                this.UpdateColor();
                this.UpdateIcon();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == FloatingButton.ColorProperty.PropertyName)
            {
                this.UpdateColor();
            }
            else if (e.PropertyName == FloatingButton.IconProperty.PropertyName)
            {
                this.UpdateIcon();
            }
        }

        private FloatingActionButton InflateFloatingActionButton()
        {
            if (this.Element.ButtonSize == FloatingButtonSize.Mini)
            {
                return this.InflateNativeControl<FloatingActionButton>(Resource.Layout.fab_mini);
            }

            return this.InflateNativeControl<FloatingActionButton>(Resource.Layout.fab_normal);
        }

        private void UpdateColor()
        {
            // TODO: Need to update the BackgroundTintList property.
        }

        private void UpdateIcon()
        {
            if (this.Element.Icon != null)
            {
                this.Control.SetImageDrawable(this.Element.Icon.ToBitmapDrawable());
            }
        }
    }
}