namespace NativeCode.Mobile.AppCompat.FormsAppCompat
{
    using Android.Support.V7.App;

    /// <summary>
    /// Provides a contract to furnish a <see cref="AppCompatDelegate" /> instance.
    /// </summary>
    public interface IAppCompatDelegateProvider
    {
        /// <summary>
        /// Gets the <see cref="AppCompatDelegate" /> instance.
        /// </summary>
        AppCompatDelegate AppCompatDelegate { get; }
    }
}