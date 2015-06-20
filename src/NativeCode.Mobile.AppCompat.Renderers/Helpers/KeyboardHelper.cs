namespace NativeCode.Mobile.AppCompat.Renderers.Helpers
{
    using System;
    using System.Reflection;

    using Android.Text;

    using Xamarin.Forms;

    using View = Android.Views.View;

    public static class KeyboardHelper
    {
        private const string KeyboardExtensionsType = "Xamarin.Forms.Platform.Android.KeyboardExtensions, Xamarin.Forms.Platform.Android";

        private const string KeyboardExtensionsToInputType = "ToInputType";

        private const string KeyboardManagerType = "Xamarin.Forms.Platform.Android.KeyboardManager, Xamarin.Forms.Platform.Android";

        private const string KeyboardManagerHideKeyboard = "HideKeyboard";

        private const string KeyboardManagerShowKeyboard = "ShowKeyboard";

        private static readonly MethodInfo MethodToInputType;

        private static readonly MethodInfo MethodHideKeyboard;

        private static readonly MethodInfo MethodShowKeyboard;

        /// <summary>
        /// Initializes static members of the <see cref="KeyboardHelper"/> class.
        /// </summary>
        static KeyboardHelper()
        {
            var keyboardExtensionsType = Type.GetType(KeyboardExtensionsType, true);
            MethodToInputType = keyboardExtensionsType.GetMethod(KeyboardExtensionsToInputType);

            var keyboardManagerType = Type.GetType(KeyboardManagerType, true);
            MethodHideKeyboard = keyboardManagerType.GetMethod(KeyboardManagerHideKeyboard, ReflectionHelper.NonPublicStatic);
            MethodShowKeyboard = keyboardManagerType.GetMethod(KeyboardManagerShowKeyboard, ReflectionHelper.NonPublicStatic);
        }

        public static InputTypes GetInputType(Keyboard keyboard)
        {
            return (InputTypes)MethodToInputType.Invoke(null, new object[] { keyboard });
        }

        public static void HideKeyboard(View view)
        {
            MethodHideKeyboard.Invoke(null, new object[] { view });
        }

        public static void ShowKeyboard(View view)
        {
            MethodShowKeyboard.Invoke(null, new object[] { view });
        }
    }
}