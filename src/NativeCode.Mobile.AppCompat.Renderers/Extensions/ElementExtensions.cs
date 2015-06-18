namespace NativeCode.Mobile.AppCompat.Renderers.Extensions
{
    using System;
    using System.Linq;

    using Xamarin.Forms;

    /// <summary>
    /// Provides extensions for <see cref="Element" /> instances.
    /// </summary>
    public static class ElementExtensions
    {
        private const string ButtonController = "IButtonController";

        private const string ButtonControllerSendClicked = "SendClicked";

        /// <summary>
        /// Tries to cast the element to a button controller and invoke the SendClicked method.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <exception cref="System.MissingMethodException">Could not find SendClicked method.</exception>
        /// <remarks>The IButtonController is an internal interface, so we have to use reflection.</remarks>
        public static void InvokeSendClicked(this Element element)
        {
            var type = GetImplementedInterface(element, ButtonController);
            var method = type.GetMethod(ButtonControllerSendClicked);

            if (method == null)
            {
                throw new MissingMethodException(type.Name, ButtonControllerSendClicked);
            }

            method.Invoke(element, new object[0]);
        }

        private static Type GetImplementedInterface(object instance, string name)
        {
            var type = instance.GetType().GetInterfaces().Single(x => x.Name == ButtonController);

            if (type == null)
            {
                throw new InvalidCastException("Type does not implement interface " + name + ".");
            }

            return type;
        }
    }
}