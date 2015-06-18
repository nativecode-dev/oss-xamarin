namespace NativeCode.Mobile.AppCompat.Controls.Platforms
{
    using System;

    /// <summary>
    /// Provides a contract to display user notifications.
    /// </summary>
    public interface IUserNotifier
    {
        /// <summary>
        /// Displays a notification message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="duration">The duration.</param>
        void Notify(string message, TimeSpan duration);

        /// <summary>
        /// Displays a long notification message.
        /// </summary>
        /// <param name="message">The message.</param>
        void NotifyLong(string message);

        /// <summary>
        /// Displays a short notification message.
        /// </summary>
        /// <param name="message">The message.</param>
        void NotifyShort(string message);
    }
}