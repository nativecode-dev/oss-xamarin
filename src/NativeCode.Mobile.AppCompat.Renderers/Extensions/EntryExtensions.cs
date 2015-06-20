namespace NativeCode.Mobile.AppCompat.Renderers.Extensions
{
    using System.Reflection;

    using NativeCode.Mobile.AppCompat.Renderers.Helpers;

    using Xamarin.Forms;

    /// <summary>
    /// Provides extensions for <see cref="Entry" /> instances.
    /// </summary>
    public static class EntryExtensions
    {
        private const string EntrySendCompleted = "SendCompleted";

        private const BindingFlags InstanceNonPublic = BindingFlags.Instance | BindingFlags.NonPublic;

        private static readonly MethodInfo MethodSendCompleted;

        /// <summary>
        /// Initializes static members of the <see cref="EntryExtensions"/> class.
        /// </summary>
        static EntryExtensions()
        {
            var type = typeof(Entry);
            MethodSendCompleted = type.GetMethod(EntrySendCompleted, InstanceNonPublic);
        }

        /// <summary>
        /// Invokes the send completed.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public static void InvokeSendCompleted(this Entry entry)
        {
            MethodSendCompleted.Invoke(entry, ReflectionHelper.EmptyParameters);
        }
    }
}