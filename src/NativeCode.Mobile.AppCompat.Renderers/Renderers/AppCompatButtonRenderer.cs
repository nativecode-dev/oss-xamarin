namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System;

    using Android.Support.V7.Widget;

    using NativeCode.Mobile.AppCompat.Extensions;
    using NativeCode.Mobile.AppCompat.Renderers.Extensions;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using JavaObject = Java.Lang.Object;
    using View = Android.Views.View;

    /// <summary>
    /// Provides a renderer for a <see cref="Button" /> to give it a Material Design in Android.
    /// </summary>
    /// <remarks>We can safely override the control creation code since <see cref="AppCompatButton" /> derives from <see cref="Button" />.</remarks>
    public class AppCompatButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            // NOTE: It is imperative that we set the control prior to the base method so that it can do all of the necessary
            // setup with property bindings. Since we're using a AppCompatButton, we have to mimic the calls that are used
            // in the base method.
            if (this.Control == null)
            {
                var context = this.Context.GetAppCompatThemedContext();
                var control = new AppCompatButton(context);
                this.SetNativeControl(control);

                control.SetOnClickListener(ButtonClickListener.Instance);
                control.Tag = this;
                this.SetNativeControl(control);
                control.AddOnAttachStateChangeListener(this);
            }

            base.OnElementChanged(e);
        }

        private class ButtonClickListener : JavaObject, IOnClickListener
        {
            private static readonly Lazy<ButtonClickListener> DefaultInstance = new Lazy<ButtonClickListener>(() => new ButtonClickListener());

            public static ButtonClickListener Instance => DefaultInstance.Value;

            public void OnClick(View view)
            {
                var renderer = view.Tag as AppCompatButtonRenderer;

                renderer?.Element.InvokeSendClicked();
            }
        }
    }
}