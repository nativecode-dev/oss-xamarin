namespace NativeCode.Mobile.AppCompat.Renderers.Helpers
{
    using System;
    using System.Reflection;

    internal static class ReflectionHelper
    {
        public static void SetFieldValue(object instance, string name, object value)
        {
            var field = instance.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);

            if (field == null)
            {
                throw new MissingFieldException(instance.GetType().Name, name);
            }

            field.SetValue(instance, value);
        }
    }
}