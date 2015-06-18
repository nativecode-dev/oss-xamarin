namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System;

    using Android.Support.V7.Widget;
    using Android.Util;
    using Android.Widget;

    using NativeCode.Mobile.AppCompat.Extensions;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using Size = Xamarin.Forms.Size;
    using Switch = Xamarin.Forms.Switch;

    /// <summary>
    /// Provides a renderer for a <see cref="SwitchCompat" /> widget.
    /// </summary>
    /// <remarks>Unfortunately, <see cref="SwitchCompat" /> does not derive from <see cref="Xamarin.Forms.Switch" />, so we have copy the
    /// <see cref="SwitchRenderer" /> code and mimic it.</remarks>
    public class AppCompatSwitchRenderer : ViewRenderer<Switch, SwitchCompat>, CompoundButton.IOnCheckedChangeListener
    {
        public AppCompatSwitchRenderer()
        {
            this.AutoPackage = false;
        }

        public override SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
            var sizeRequest = base.GetDesiredSize(widthConstraint, heightConstraint);

            if (Math.Abs(sizeRequest.Request.Width) < 0.0)
            {
                var num = widthConstraint;

                if (widthConstraint <= 0)
                {
                    num = (int)this.GetThemeAttributeDp(16843632);
                }
                else if (widthConstraint <= 0)
                {
                    num = 100;
                }

                sizeRequest = new SizeRequest(new Size(num, sizeRequest.Request.Height), new Size(num, sizeRequest.Minimum.Height));
            }

            return sizeRequest;
        }

        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            ((IElementController)this.Element).SetValueFromRenderer(Switch.IsToggledProperty, isChecked);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.Control != null)
            {
                if (this.Element != null)
                {
                    this.Element.Toggled -= this.HandleToggled;
                }

                this.Control.SetOnCheckedChangeListener(null);
            }

            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.Toggled -= this.HandleToggled;
            }

            if (e.NewElement == null)
            {
                return;
            }

            if (this.Control == null)
            {
                var control = new SwitchCompat(this.Context.GetAppCompatThemedContext());
                control.SetOnCheckedChangeListener(this);
                this.SetNativeControl(control);
            }

            e.NewElement.Toggled += this.HandleToggled;
            this.Control.Checked = e.NewElement.IsToggled;
        }

        private double GetThemeAttributeDp(int resource)
        {
            using (var outValue = new TypedValue())
            {
                if (!this.Context.Theme.ResolveAttribute(resource, outValue, true))
                {
                    return -1.0;
                }

                double pixels = TypedValue.ComplexToDimension(outValue.Data, this.Context.Resources.DisplayMetrics);

                return this.Context.FromPixels(pixels);
            }
        }

        private void HandleToggled(object sender, EventArgs e)
        {
            this.Control.Checked = this.Element.IsToggled;
        }
    }
}