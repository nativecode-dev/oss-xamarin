namespace NativeCode.Mobile.AppCompat.Renderers.Helpers
{
    using System;
    using System.Reflection;

    public static class ReflectionHelper
    {
        public const BindingFlags InstanceNonPublic = BindingFlags.Instance | BindingFlags.NonPublic;

        public const BindingFlags InternalStatic = BindingFlags.NonPublic | BindingFlags.Static;

        public static readonly object[] EmptyParameters = new object[0];

        public static void SetFieldValue(object instance, string name, object value)
        {
            var field = instance.GetType().GetField(name, InstanceNonPublic);

            if (field == null)
            {
                throw new MissingFieldException(instance.GetType().Name, name);
            }

            field.SetValue(instance, value);
        }
    }
}