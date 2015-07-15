namespace NativeCode.Mobile.AppCompat.Renderers
{
    using System;
    using System.Reflection;

    using NativeCode.Mobile.AppCompat.Controls;
    using NativeCode.Mobile.AppCompat.Helpers;
    using NativeCode.Mobile.AppCompat.Renderers.Renderers;

    using Xamarin.Forms;

    /// <summary>
    /// Enables renderers for various aspects of the library.
    /// </summary>
    public static class FormsAppCompat
    {
        private const string RegistrarType = "Xamarin.Forms.Registrar, Xamarin.Forms.Core";

        private static readonly object RegistrarInstance;

        private static readonly MethodInfo RegisterMethod;

        /// <summary>
        /// Initializes static members of the <see cref="FormsAppCompat"/> class.
        /// </summary>
        static FormsAppCompat()
        {
            var type = Type.GetType(RegistrarType, true);
            var property = type.GetProperty("Registered", ReflectionHelper.NonPublicStatic);
            RegistrarInstance = property.GetValue(null);
            RegisterMethod = property.PropertyType.GetMethod("Register", ReflectionHelper.InstancePublic);
        }

        /// <summary>
        /// Enables registration of all renderers.
        /// </summary>
        public static void EnableAll()
        {
            EnableAndroidRenderers();
            EnableAppCompatRenderers();
            EnableMasterDetailRenderer();
        }

        /// <summary>
        /// Enables Android-specific renderers.
        /// </summary>
        public static void EnableAndroidRenderers()
        {
            RegisterType(typeof(Card), typeof(CardRenderer));
            RegisterType(typeof(FloatingButton), typeof(FloatingButtonRenderer));
            RegisterType(typeof(NavigationLayout), typeof(NavigationLayoutRenderer));
        }

        /// <summary>
        /// Enables compatibility renderers.
        /// </summary>
        public static void EnableAppCompatRenderers()
        {
            RegisterType(typeof(Button), typeof(AppCompatButtonRenderer));
            RegisterType(typeof(Entry), typeof(AppCompatEntryLayoutRenderer));
            RegisterType(typeof(Picker), typeof(AppCompatSpinnerRenderer));
            RegisterType(typeof(Switch), typeof(AppCompatSwitchRenderer));
        }

        /// <summary>
        /// Enables the <see cref="AppCompatMasterDetailRenderer"/>.
        /// </summary>
        public static void EnableMasterDetailRenderer()
        {
            RegisterType(typeof(MasterDetailPage), typeof(AppCompatMasterDetailRenderer));
        }

        private static void RegisterType(Type handler, Type target)
        {
            RegisterMethod.Invoke(RegistrarInstance, new object[] { handler, target });
        }
    }
}