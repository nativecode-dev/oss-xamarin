namespace NativeCode.Mobile.AppCompat.FormsAppCompat
{
    using Android.Support.Design.Widget;

    public interface IAppCompatCoordinatorLayoutProvider
    {
        /// <summary>
        /// Gets the <see cref="CoordinatorLayout"/> used by <see cref="AppCompatFormsApplicationActivity"/>.
        /// </summary>
        /// <returns>Returns a <see cref="CoordinatorLayout" />.</returns>
        CoordinatorLayout GetCoordinatorLayout();
    }
}