namespace NativeCode.Mobile.AppCompat.Extensions
{
    using System;
    using System.Reflection;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using View = Android.Views.View;

    /// <summary>
    /// Provides extensions for <see cref="View" /> instances.
    /// </summary>
    public static class ViewExtensions
    {
        private static readonly Type PlatformType = Type.GetType("Xamarin.Forms.Platform.Android.Platform, Xamarin.Forms.Platform.Android", true);

        internal static BindableProperty RendererProperty
        {
            get
            {
                var property = PlatformType.GetField("RendererProperty", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

                if (property != null)
                {
                    return (BindableProperty)property.GetValue(null);
                }

                // TODO: This might need a more specific exception.
                throw new InvalidCastException("Cannot convert to a BindableProperty.");
            }
        }

        /// <summary>
        /// Attempts to get the <see cref="IVisualElementRenderer" /> for a given <see cref="BindableObject" />.
        /// </summary>
        /// <param name="bindableObject">The $bindable$ object.</param>
        /// <returns>Returns a <see cref="IVisualElementRenderer" />.</returns>
        public static IVisualElementRenderer GetRenderer(this BindableObject bindableObject)
        {
            return (IVisualElementRenderer)bindableObject.GetValue(RendererProperty);
        }

        /// <summary>
        /// Attempts to get a native Android <see cref="View" />.
        /// </summary>
        /// <param name="bindableObject">The $bindable$ object.</param>
        /// <returns>Returns a <see cref="View" />.</returns>
        public static View GetNativeView(this BindableObject bindableObject)
        {
            return bindableObject.GetRenderer().ViewGroup.RootView;
        }
    }
}