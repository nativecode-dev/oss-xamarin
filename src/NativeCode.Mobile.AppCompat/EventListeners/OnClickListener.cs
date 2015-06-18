namespace NativeCode.Mobile.AppCompat.EventListeners
{
    using System;

    using Android.Views;

    /// <summary>
    /// Provides a simple wrapper for handling <see cref="View.IOnClickListener"/> implementations.
    /// </summary>
    public class OnClickListener : EventListener, View.IOnClickListener
    {
        private readonly Action<View> callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnClickListener" /> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public OnClickListener(Action<View> callback)
        {
            this.callback = callback;
        }

        /// <summary>
        /// Called when the <see cref="View" /> is clicked.
        /// </summary>
        /// <param name="view">The view.</param>
        public void OnClick(View view)
        {
            this.callback(view);
        }
    }
}