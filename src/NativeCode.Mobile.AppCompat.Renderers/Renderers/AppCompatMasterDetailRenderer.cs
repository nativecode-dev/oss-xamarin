namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System.ComponentModel;

    using Android.App;
    using Android.Provider;
    using Android.Support.V4.Widget;
    using Android.Support.V7.App;

    using NativeCode.Mobile.AppCompat.Extensions;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using ActionBar = Android.Support.V7.App.ActionBar;
    using PropertyChangingEventArgs = Xamarin.Forms.PropertyChangingEventArgs;
    using RendererResource = Resource;
    using View = Android.Views.View;

    public class AppCompatMasterDetailRenderer : MasterDetailRenderer
    {
        private CustomActionBarDrawerToggle actionBarDrawerToggle;

        protected ActionBar ActionBar
        {
            get { return this.Context.GetSupportActionBar(); }
        }

        protected MasterDetailPage MasterDetailPage
        {
            get { return (MasterDetailPage)this.Element; }
        }

        public override void SetDrawerListener(IDrawerListener listener)
        {
            base.SetDrawerListener(this.actionBarDrawerToggle);
        }

        protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
        {
            base.OnElementChanged(oldElement, newElement);

            if (oldElement != null)
            {
                oldElement.PropertyChanged -= this.HandleMasterDetailPagePropertyChanged;
                oldElement.PropertyChanging -= this.HandleMasterDetailPagePropertyChanging;
            }

            if (newElement != null)
            {
                newElement.PropertyChanged += this.HandleMasterDetailPagePropertyChanged;
                newElement.PropertyChanging += this.HandleMasterDetailPagePropertyChanging;
            }

            if (oldElement == null && newElement != null)
            {
                this.SetFitsSystemWindows(true);

                var activity = (Activity)this.Context;

                this.actionBarDrawerToggle = new CustomActionBarDrawerToggle(this, activity, this) { DrawerIndicatorEnabled = true };

                this.ActionBar.SetDisplayHomeAsUpEnabled(true);
                this.ActionBar.SetHomeButtonEnabled(true);

                this.actionBarDrawerToggle.SyncState();

                this.BindNavigationEventHandlers();
            }
        }

        protected void UpdateHomeAsUpIndicator(bool navigable)
        {
            if (navigable && this.actionBarDrawerToggle.DrawerIndicatorEnabled)
            {
                this.ActionBar.SetDisplayHomeAsUpEnabled(false);
                this.actionBarDrawerToggle.DrawerIndicatorEnabled = false;
                this.ActionBar.SetDisplayHomeAsUpEnabled(true);
            }
            else if (!this.actionBarDrawerToggle.DrawerIndicatorEnabled)
            {
                this.actionBarDrawerToggle.DrawerIndicatorEnabled = true;
            }
        }

        private void BindNavigationEventHandlers()
        {
            var navigation = this.MasterDetailPage.Detail as NavigationPage;

            if (navigation != null)
            {
                navigation.Popped += this.HandleNavigationPopped;
                navigation.Pushed += this.HandleNavigationPushed;
            }
        }

        private void UnbindNavigationEventHandlers()
        {
            var navigation = this.MasterDetailPage.Detail as NavigationPage;

            if (navigation != null)
            {
                navigation.Popped -= this.HandleNavigationPopped;
                navigation.Pushed -= this.HandleNavigationPushed;
            }
        }

        private void HandleMasterDetailPagePropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName == "Detail")
            {
                this.UnbindNavigationEventHandlers();
            }
        }

        private void HandleMasterDetailPagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Detail")
            {
                this.BindNavigationEventHandlers();
            }
        }

        private void HandleNavigationPopped(object sender, NavigationEventArgs e)
        {
            var canNavigateBack = ((NavigationPage)sender).Navigation.NavigationStack.Count > 1;
            this.UpdateHomeAsUpIndicator(canNavigateBack);
        }

        private void HandleNavigationPushed(object sender, NavigationEventArgs e)
        {
            var canNavigateBack = ((NavigationPage)sender).Navigation.NavigationStack.Count > 1;
            this.UpdateHomeAsUpIndicator(canNavigateBack);
        }

        private class CustomActionBarDrawerToggle : ActionBarDrawerToggle
        {
            private readonly AppCompatDelegate appCompatDelegate;

            private readonly AppCompatMasterDetailRenderer owner;

            public CustomActionBarDrawerToggle(AppCompatMasterDetailRenderer owner, Activity activity, DrawerLayout drawerLayout)
                : base(activity, drawerLayout, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close)
            {
                this.appCompatDelegate = activity.GetAppCompatDelegate();
                this.owner = owner;
            }

            public override void OnDrawerClosed(View drawerView)
            {
                base.OnDrawerClosed(drawerView);
                this.appCompatDelegate.InvalidateOptionsMenu();
                this.owner.OnDrawerClosed(drawerView);
            }

            public override void OnDrawerOpened(View drawerView)
            {
                base.OnDrawerOpened(drawerView);
                this.appCompatDelegate.InvalidateOptionsMenu();
                this.owner.OnDrawerOpened(drawerView);
            }

            public override void OnDrawerSlide(View drawerView, float slideOffset)
            {
                base.OnDrawerSlide(drawerView, slideOffset);
                this.owner.OnDrawerSlide(drawerView, slideOffset);
            }

            public override void OnDrawerStateChanged(int newState)
            {
                base.OnDrawerStateChanged(newState);
                this.owner.OnDrawerStateChanged(newState);
            }
        }
    }
}