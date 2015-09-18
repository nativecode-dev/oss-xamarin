namespace NativeCode.Mobile.AppCompat.FormsAppCompat
{
    using Android.Support.Design.Widget;
    using Android.Support.V7.App;
    using Android.Views;
    using Android.Widget;

    /// <summary>
    /// Provides a <see cref="AppCompatDelegate" />-backed activity while maintaining compatibility with $Xamarin.Forms$.
    /// </summary>
    /// <remarks>See <see cref="http://bit.ly/1Lfr30c" /> for information on implementation.</remarks>
    public class AppCompatFormsApplicationActivity : AppCompatFormsActivity, IAppCompatCoordinatorLayoutProvider
    {
        private CoordinatorLayout coordinator;

        protected bool EnableCoordinatorLayout { get; set; }

        public CoordinatorLayout GetCoordinatorLayout()
        {
            return this.EnableCoordinatorLayout ? this.coordinator : null;
        }

        public override void SetContentView(View view)
        {
            var content = view;

            // We need to create a CoordinatorLayout for Snackbars to find so we get the proper display.
            // This simply wraps the LinearLayout that the FormsApplicationActivity creates.
            // TODO: This relies too much on the implementation detail of the FormsApplicationActivity.
            if (content is LinearLayout && this.EnableCoordinatorLayout)
            {
                this.coordinator = this.Inflate<CoordinatorLayout>(Resource.Layout.appcompat_coordinator, null);
                this.coordinator.AddView(this.Toolbar);
                this.coordinator.AddView(view);

                this.Disposables.Add(this.coordinator);

                content = this.coordinator;
            }

            this.AppCompatDelegate.SetContentView(content);
        }

        public override void SetContentView(View view, ViewGroup.LayoutParams @params)
        {
            this.AppCompatDelegate.SetContentView(view, @params);
        }

        public override void SetContentView(int layoutResId)
        {
            this.AppCompatDelegate.SetContentView(layoutResId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.coordinator = null;
            }

            base.Dispose(disposing);
        }

        private T Inflate<T>(int id, ViewGroup viewGroup) where T : View
        {
            var inflated = this.LayoutInflater.Inflate(id, viewGroup);
            return inflated.FindViewById<T>(inflated.Id);
        }
    }
}