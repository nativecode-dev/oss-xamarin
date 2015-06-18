namespace NativeCode.Mobile.AppCompat.Extensions
{
    using System;

    using Android.Content;
    using Android.Support.V7.App;

    using NativeCode.Mobile.AppCompat.FormsAppCompat;

    /// <summary>
    /// Provides extensions for <see cref="Context" /> instances.
    /// </summary>
    public static class ContextExtensions
    {
        /// <summary>
        /// Gets the <see cref="AppCompatDelegate" /> from a <see cref="Context" />.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns a <see cref="AppCompatDelegate" />.</returns>
        public static AppCompatDelegate GetAppCompatDelegate(this Context context)
        {
            return context.GetAppCompatDelegateProvider().AppCompatDelegate;
        }

        /// <summary>
        /// Gets a <see cref="IAppCompatDelegateProvider" /> from a <see cref="Context" />.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns a <see cref="IAppCompatDelegateProvider" />.</returns>
        /// <exception cref="System.InvalidOperationException">Could not cast $IAppCompatDelegateProvider$ interface from the provided context.</exception>
        public static IAppCompatDelegateProvider GetAppCompatDelegateProvider(this Context context)
        {
            var provider = context as IAppCompatDelegateProvider;

            if (provider == null)
            {
                throw new InvalidOperationException("Could not cast IAppCompatDelegateProvider interface from the provided context.");
            }

            return provider;
        }

        /// <summary>
        /// Gets a themed <see cref="Context" />.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns a <see cref="Context" />.</returns>
        public static Context GetAppCompatThemedContext(this Context context)
        {
            return context.GetAppCompatDelegate().SupportActionBar.ThemedContext;
        }

        /// <summary>
        /// Gets the support action bar.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns a <see cref="ActionBar" />.</returns>
        public static ActionBar GetSupportActionBar(this Context context)
        {
            return context.GetAppCompatDelegate().SupportActionBar;
        }
    }
}