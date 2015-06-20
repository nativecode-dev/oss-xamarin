namespace NativeCode.Mobile.AppCompat.Renderers
{
    using System;
    using System.Reflection;

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
            EnableAppCompatReplacements();
            EnableMasterDetailRenderer();
        }

        /// <summary>
        /// Enables registration of $AppCompat$ renderers.
        /// </summary>
        public static void EnableAppCompatReplacements()
        {
            RegisterType(typeof(Button), typeof(AppCompatButtonRenderer));
            RegisterType(typeof(Entry), typeof(AppCompatEntryRenderer));
            RegisterType(typeof(Switch), typeof(AppCompatSwitchRenderer));
        }

        /// <summary>
        /// Enables registration of the <see cref="AppCompatMasterDetailRenderer"/>.
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