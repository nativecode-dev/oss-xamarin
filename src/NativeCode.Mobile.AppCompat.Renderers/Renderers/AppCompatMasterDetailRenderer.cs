namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using Android.App;
    using Android.Support.V4.Widget;
    using Android.Support.V7.App;

    using NativeCode.Mobile.AppCompat.Extensions;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using View = Android.Views.View;

    public class AppCompatMasterDetailRenderer : MasterDetailRenderer
    {
        private CustomActionBarDrawerToggle toggle;

        public override void SetDrawerListener(IDrawerListener listener)
        {
            base.SetDrawerListener(this.toggle);
        }

        protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
        {
            base.OnElementChanged(oldElement, newElement);

            if (oldElement == null && newElement != null)
            {
                this.SetFitsSystemWindows(true);

                var activity = (Activity)this.Context;
                this.toggle = new CustomActionBarDrawerToggle(this, activity, this) { DrawerIndicatorEnabled = true };

                var actionbar = this.Context.GetSupportActionBar();
                actionbar.SetDisplayHomeAsUpEnabled(true);
                actionbar.SetHomeButtonEnabled(true);

                this.toggle.SyncState();
            }
        }

        private class CustomActionBarDrawerToggle : ActionBarDrawerToggle
        {
            private readonly AppCompatDelegate appCompatDelegate;

            private readonly AppCompatMasterDetailRenderer renderer;

            public CustomActionBarDrawerToggle(AppCompatMasterDetailRenderer renderer, Activity activity, DrawerLayout drawerLayout)
                : base(activity, drawerLayout, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close)
            {
                this.renderer = renderer;
                this.appCompatDelegate = activity.GetAppCompatDelegate();
            }

            public override void OnDrawerClosed(View drawerView)
            {
                base.OnDrawerClosed(drawerView);
                this.appCompatDelegate.InvalidateOptionsMenu();
                this.renderer.OnDrawerClosed(drawerView);
            }

            public override void OnDrawerOpened(View drawerView)
            {
                base.OnDrawerOpened(drawerView);
                this.appCompatDelegate.InvalidateOptionsMenu();
                this.renderer.OnDrawerOpened(drawerView);
            }

            public override void OnDrawerSlide(View drawerView, float slideOffset)
            {
                base.OnDrawerSlide(drawerView, slideOffset);
                this.renderer.OnDrawerSlide(drawerView, slideOffset);
            }

            public override void OnDrawerStateChanged(int newState)
            {
                base.OnDrawerStateChanged(newState);
                this.renderer.OnDrawerStateChanged(newState);
            }
        }
    }
}