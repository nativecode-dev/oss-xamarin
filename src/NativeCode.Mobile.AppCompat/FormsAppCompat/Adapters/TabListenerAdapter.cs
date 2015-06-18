namespace NativeCode.Mobile.AppCompat.FormsAppCompat.Adapters
{
    using System;

    using Android.App;

    using JavaObject = Java.Lang.Object;
    using SupportActionBar = Android.Support.V7.App.ActionBar;
    using SupportFragmentTransaction = Android.Support.V4.App.FragmentTransaction;

    /// <summary>
    /// Adapts a <see cref="Android.Support.V7.App.ActionBar.ITabListener"/> to a <see cref="Android.App.ActionBar.ITabListener"/>.
    /// </summary>
    [Obsolete("Will be removed in a future version.", false)]
    internal class TabListenerAdapter : JavaObject, SupportActionBar.ITabListener
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabListenerAdapter"/> class.
        /// </summary>
        /// <param name="listener">The listener.</param>
        /// <param name="tab">The tab.</param>
        [Obsolete("Will be removed in a future version.", false)]
        internal TabListenerAdapter(ActionBar.ITabListener listener, ActionBar.Tab tab)
        {
            this.Tab = tab;
            this.TabListener = listener;
        }

        /// <summary>
        /// Gets the original tab.
        /// </summary>
        protected ActionBar.Tab Tab { get; private set; }

        /// <summary>
        /// Gets the original listener.
        /// </summary>
        protected ActionBar.ITabListener TabListener { get; private set; }

        [Obsolete("Will be removed in a future version.", false)]
        public void OnTabReselected(SupportActionBar.Tab tab, SupportFragmentTransaction fragmentTransaction)
        {
            this.TabListener.OnTabReselected(this.Tab, null);
        }

        [Obsolete("Will be removed in a future version.", false)]
        public void OnTabSelected(SupportActionBar.Tab tab, SupportFragmentTransaction fragmentTransaction)
        {
            this.TabListener.OnTabSelected(this.Tab, null);
        }

        [Obsolete("Will be removed in a future version.", false)]
        public void OnTabUnselected(SupportActionBar.Tab tab, SupportFragmentTransaction fragmentTransaction)
        {
            this.TabListener.OnTabUnselected(this.Tab, null);
        }
    }
}