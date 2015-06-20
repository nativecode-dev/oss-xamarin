namespace NativeCode.Mobile.AppCompat.Renderers.Extensions
{
    using System;
    using System.Reflection;

    using NativeCode.Mobile.AppCompat.Renderers.Helpers;

    using Xamarin.Forms;

    /// <summary>
    /// Provides extensions for <see cref="Element" /> instances.
    /// </summary>
    public static class ElementExtensions
    {
        private const string ButtonControllerType = "Xamarin.Forms.IButtonController, Xamarin.Forms.Core";

        private const string ButtonControllerSendClicked = "SendClicked";

        private static readonly MethodInfo MethodSendClicked;

        /// <summary>
        /// Initializes static members of the <see cref="ElementExtensions"/> class.
        /// </summary>
        static ElementExtensions()
        {
            var type = Type.GetType(ButtonControllerType, true);
            MethodSendClicked = type.GetMethod(ButtonControllerSendClicked);
        }

        /// <summary>
        /// Tries to cast the element to a button controller and invoke the SendClicked method.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <exception cref="System.MissingMethodException">Could not find SendClicked method.</exception>
        /// <remarks>The IButtonController is an internal interface, so we have to use reflection.</remarks>
        public static void InvokeSendClicked(this Element element)
        {
            MethodSendClicked.Invoke(element, ReflectionHelper.EmptyParameters);
        }
    }
}