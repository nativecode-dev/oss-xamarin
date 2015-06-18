namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System;
    using System.Reflection;

    using Xamarin.Forms;

    /// <summary>
    /// Allows registration of renderers.
    /// </summary>
    public static class AppCompatRenderers
    {
        private const string RegistrarType = "Xamarin.Forms.Registrar, Xamarin.Forms.Core";

        private static readonly object RegistrarInstance;

        private static readonly MethodInfo RegisterMethod;

        /// <summary>
        /// Initializes static members of the <see cref="AppCompatRenderers"/> class.
        /// </summary>
        static AppCompatRenderers()
        {
            var type = Type.GetType(RegistrarType, true);
            var property = type.GetProperty("Registered", BindingFlags.NonPublic | BindingFlags.Static);
            RegistrarInstance = property.GetValue(null);
            RegisterMethod = property.PropertyType.GetMethod("Register", BindingFlags.Instance | BindingFlags.Public);
        }

        /// <summary>
        /// Enables registration of all renderers.
        /// </summary>
        public static void EnableAll()
        {
            EnableMasterDetailRenderer();
            EnableAppCompatReplacements();
        }

        /// <summary>
        /// Enables registration of the <see cref="AppCompatMasterDetailRenderer"/>.
        /// </summary>
        public static void EnableMasterDetailRenderer()
        {
            RegisterType(typeof(MasterDetailPage), typeof(AppCompatMasterDetailRenderer));
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

        private static void RegisterType(Type handler, Type target)
        {
            RegisterMethod.Invoke(RegistrarInstance, new object[] { handler, target });
        }
    }
}