namespace NativeCode.Mobile.AppCompat.FormsAppCompat.Adapters
{
    using Android.App;

    using SupportActionBar = Android.Support.V7.App.ActionBar;

    /// <summary>
    /// Adapts a <see cref="Android.Support.V7.App.ActionBar.LayoutParams"/> to a <see cref="Android.App.ActionBar.LayoutParams"/>.
    /// </summary>
    internal class LayoutParamsAdapter : SupportActionBar.LayoutParams
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutParamsAdapter"/> class.
        /// </summary>
        /// <param name="layoutParams">The layout parameters.</param>
        public LayoutParamsAdapter(ActionBar.LayoutParams layoutParams) : base(layoutParams.Width, layoutParams.Height, (int)layoutParams.Gravity)
        {
        }
    }
}