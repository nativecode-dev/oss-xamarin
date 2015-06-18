namespace NativeCode.Mobile.AppCompat.FormsAppCompat
{
    using Android.Support.Design.Widget;
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

        /// <summary>
        /// Gets the <see cref="CoordinatorLayout"/> used by <see cref="AppCompatFormsApplicationActivity"/>.
        /// </summary>
        /// <returns>Returns a <see cref="CoordinatorLayout" />.</returns>
        CoordinatorLayout GetCoordinatorLayout();
    }
}