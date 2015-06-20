namespace NativeCode.Mobile.AppCompat.Renderers.Helpers
{
    using System;
    using System.Reflection;

    internal static class ReflectionHelper
    {
        public static readonly object[] EmptyParameters = new object[0];

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