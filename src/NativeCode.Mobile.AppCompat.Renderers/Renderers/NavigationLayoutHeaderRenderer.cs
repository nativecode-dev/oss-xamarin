using NativeCode.Mobile.AppCompat.Controls;
using NativeCode.Mobile.AppCompat.Controls.Platforms;
using NativeCode.Mobile.AppCompat.Renderers.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(NavigationLayoutHeader), typeof(NavigationLayoutHeaderRenderer))]

namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using Android.Widget;

    using NativeCode.Mobile.AppCompat.Controls.Platforms;
    using NativeCode.Mobile.AppCompat.Extensions;

    using Xamarin.Forms.Platform.Android;

    public class NavigationLayoutHeaderRenderer : ViewRenderer<NavigationLayoutHeader, FrameLayout>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationLayoutHeader> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var context = this.Context.GetAppCompatThemedContext();
                var control = new FrameLayout(context);

                this.SetNativeControl(control);
            }
        }
    }
}