namespace NativeCode.Mobile.AppCompat.Renderers.Extensions
{
    using System;
    using System.Reflection;

    using Xamarin.Forms;

    /// <summary>
    /// Provides extensions for <see cref="Entry" /> instances.
    /// </summary>
    public static class EntryExtensions
    {
        private const string EntrySendCompleted = "SendCompleted";

        /// <summary>
        /// Invokes the send completed.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public static void InvokeSendCompleted(this Entry entry)
        {
            var type = entry.GetType();
            var method = type.GetMethod(EntrySendCompleted, BindingFlags.Instance | BindingFlags.NonPublic);

            if (method == null)
            {
                throw new MissingMethodException(type.Name, EntrySendCompleted);
            }

            method.Invoke(entry, new object[0]);
        }
    }
}