namespace NativeCode.Mobile.AppCompat.FormsAppCompat.Adapters
{
    using Android.App;

    using JavaObject = Java.Lang.Object;
    using SupportActionBar = Android.Support.V7.App.ActionBar;

    /// <summary>
    /// Adapts a <see cref="Android.Support.V7.App.ActionBar.IOnMenuVisibilityListener"/> to a <see cref="Android.App.ActionBar.IOnMenuVisibilityListener"/>.
    /// </summary>
    internal class MenuVisibilityListenerAdapter : JavaObject, SupportActionBar.IOnMenuVisibilityListener
    {
        private readonly ActionBar.IOnMenuVisibilityListener listener;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuVisibilityListenerAdapter"/> class.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public MenuVisibilityListenerAdapter(ActionBar.IOnMenuVisibilityListener listener)
        {
            this.listener = listener;
        }

        public void OnMenuVisibilityChanged(bool isVisible)
        {
            this.listener.OnMenuVisibilityChanged(isVisible);
        }
    }
}