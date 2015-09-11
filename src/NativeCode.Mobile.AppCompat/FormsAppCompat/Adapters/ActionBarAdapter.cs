#pragma warning disable 0809

namespace NativeCode.Mobile.AppCompat.FormsAppCompat.Adapters
{
    using System;
    using System.Collections.Generic;

    using Android.App;
    using Android.Graphics.Drawables;
    using Android.Support.V7.App;
    using Android.Widget;

    using Java.Lang;

    using ActionBar = Android.App.ActionBar;
    using View = Android.Views.View;

    /// <summary>
    /// Adapts a <see cref="Android.Support.V7.App.ActionBar"/> to a <see cref="Android.App.ActionBar"/>.
    /// </summary>
    public class ActionBarAdapter : ActionBar
    {
        private readonly Dictionary<IOnMenuVisibilityListener, MenuVisibilityListenerAdapter> menuVisibilityListeners =
            new Dictionary<IOnMenuVisibilityListener, MenuVisibilityListenerAdapter>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionBarAdapter"/> class.
        /// </summary>
        /// <param name="appCompatDelegateProvider">The application delegate provider.</param>
        public ActionBarAdapter(IAppCompatDelegateProvider appCompatDelegateProvider)
        {
            this.AppCompatDelegateProvider = appCompatDelegateProvider;
        }

        public override View CustomView
        {
            get { return this.SupportActionBar.CustomView; }
            set { this.SupportActionBar.CustomView = value; }
        }

        public override ActionBarDisplayOptions DisplayOptions
        {
            get { return (ActionBarDisplayOptions)this.SupportActionBar.DisplayOptions; }
            set { this.SupportActionBar.DisplayOptions = (int)value; }
        }

        public override int Height
        {
            get { return this.SupportActionBar.Height; }
        }

        public override bool IsShowing
        {
            get
            {
                if (this.SupportActionBar != null)
                {
                    return this.SupportActionBar.IsShowing;
                }

                return false;
            }
        }

        public override int NavigationItemCount
        {
            get { return this.SupportActionBar.NavigationItemCount; }
        }

        public override ActionBarNavigationMode NavigationMode
        {
            get { return (ActionBarNavigationMode)this.SupportActionBar.NavigationMode; }
            set { this.SupportActionBar.NavigationMode = (int)value; }
        }

        public override int SelectedNavigationIndex
        {
            get { return this.SupportActionBar.SelectedNavigationIndex; }
        }

        [Obsolete("Will be removed in a future version.", false)]
        public override Tab SelectedTab
        {
            get { return TabAdapter.ForSupportTab(this.SupportActionBar.SelectedTab); }
        }

        public override ICharSequence SubtitleFormatted
        {
            get { return this.SupportActionBar.SubtitleFormatted; }
            set { this.SupportActionBar.SubtitleFormatted = value; }
        }

        public override int TabCount
        {
            get { return this.SupportActionBar.TabCount; }
        }

        public override ICharSequence TitleFormatted
        {
            get
            {
                if (this.SupportActionBar != null)
                {
                    return this.SupportActionBar.TitleFormatted;
                }

                return null;
            }

            set
            {
                if (this.SupportActionBar == null)
                {
                    return;
                }

                this.SupportActionBar.TitleFormatted = value;
            }
        }

        protected AppCompatDelegate AppCompatDelegate
        {
            get { return this.AppCompatDelegateProvider.AppCompatDelegate; }
        }

        protected IAppCompatDelegateProvider AppCompatDelegateProvider { get; private set; }

        private Android.Support.V7.App.ActionBar SupportActionBar
        {
            get { return this.AppCompatDelegate.SupportActionBar; }
        }

        public override void AddOnMenuVisibilityListener(IOnMenuVisibilityListener listener)
        {
            var @delegate = new MenuVisibilityListenerAdapter(listener);
            this.menuVisibilityListeners.Add(listener, @delegate);
            this.SupportActionBar.AddOnMenuVisibilityListener(@delegate);
        }

        [Obsolete("Will be removed in a future version.", false)]
        public override void AddTab(Tab tab)
        {
            this.SupportActionBar.AddTab(((TabAdapter)tab).SupportTab);
        }

        [Obsolete("Will be removed in a future version.", false)]
        public override void AddTab(Tab tab, bool setSelected)
        {
            this.SupportActionBar.AddTab(((TabAdapter)tab).SupportTab, setSelected);
        }

        [Obsolete("Will be removed in a future version.", false)]
        public override void AddTab(Tab tab, int position)
        {
            this.SupportActionBar.AddTab(((TabAdapter)tab).SupportTab, position);
        }

        [Obsolete("Will be removed in a future version.", false)]
        public override void AddTab(Tab tab, int position, bool setSelected)
        {
            this.SupportActionBar.AddTab(((TabAdapter)tab).SupportTab, position, setSelected);
        }

        [Obsolete("Will be removed in a future version.", false)]
        public override Tab NewTab()
        {
            return new TabAdapter(this.SupportActionBar.NewTab());
        }

        [Obsolete("Will be removed in a future version.", false)]
        public override void SetListNavigationCallbacks(ISpinnerAdapter adapter, IOnNavigationListener callback)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Will be removed in a future version.", false)]
        public override void RemoveTab(Tab tab)
        {
            this.SupportActionBar.RemoveTab(((TabAdapter)tab).SupportTab);
        }

        [Obsolete("Will be removed in a future version.", false)]
        public override void SelectTab(Tab tab)
        {
            if (tab != null)
            {
                this.SupportActionBar.SelectTab(((TabAdapter)tab).SupportTab);
            }
        }

        [Obsolete("Will be removed in a future version.", false)]
        public override Tab GetTabAt(int index)
        {
            return TabAdapter.ForSupportTab(this.SupportActionBar.GetTabAt(index));
        }

        public override void Hide()
        {
            this.SupportActionBar.Hide();
        }

        public override void RemoveAllTabs()
        {
            this.SupportActionBar.RemoveAllTabs();
        }

        public override void RemoveOnMenuVisibilityListener(IOnMenuVisibilityListener listener)
        {
            if (this.menuVisibilityListeners.ContainsKey(listener))
            {
                using (var @delegate = this.menuVisibilityListeners[listener])
                {
                    this.SupportActionBar.RemoveOnMenuVisibilityListener(@delegate);
                }
            }
        }

        public override void RemoveTabAt(int position)
        {
            this.SupportActionBar.RemoveTabAt(position);
        }

        public override void SetBackgroundDrawable(Drawable drawable)
        {
            // NOTE: Setting this gives us a gray background for some reason. Maybe that's a Forms default?
            // this.SupportActionBar.SetBackgroundDrawable(drawable);
        }

        public override void SetCustomView(View view, LayoutParams layoutParams)
        {
            this.SupportActionBar.SetCustomView(view, new LayoutParamsAdapter(layoutParams));
        }

        public override void SetCustomView(int resId)
        {
            this.SupportActionBar.SetCustomView(resId);
        }

        public override void SetDisplayHomeAsUpEnabled(bool showHomeAsUp)
        {
            this.SupportActionBar.SetDisplayHomeAsUpEnabled(showHomeAsUp);
        }

        public override void SetDisplayOptions(ActionBarDisplayOptions options, ActionBarDisplayOptions mask)
        {
            this.SupportActionBar.SetDisplayOptions((int)options, (int)mask);
        }

        public override void SetDisplayShowCustomEnabled(bool showCustom)
        {
            this.SupportActionBar.SetDisplayShowCustomEnabled(showCustom);
        }

        public override void SetDisplayShowHomeEnabled(bool showHome)
        {
            this.SupportActionBar.SetDisplayShowHomeEnabled(showHome);
        }

        public override void SetDisplayShowTitleEnabled(bool showTitle)
        {
            this.SupportActionBar.SetDisplayShowTitleEnabled(showTitle);
        }

        public override void SetDisplayUseLogoEnabled(bool useLogo)
        {
            this.SupportActionBar.SetDisplayUseLogoEnabled(useLogo);
        }

        public override void SetIcon(Drawable icon)
        {
            this.SupportActionBar.SetIcon(icon);
        }

        public override void SetIcon(int resId)
        {
            this.SupportActionBar.SetIcon(resId);
        }

        public override void SetLogo(Drawable logo)
        {
            this.SupportActionBar.SetLogo(logo);
        }

        public override void SetLogo(int resId)
        {
            this.SupportActionBar.SetLogo(resId);
        }

        public override void SetSelectedNavigationItem(int position)
        {
            this.SupportActionBar.SetSelectedNavigationItem(position);
        }

        public override void SetSubtitle(int resId)
        {
            this.SupportActionBar.SetSubtitle(resId);
        }

        public override void SetTitle(int resId)
        {
            this.SupportActionBar.SetTitle(resId);
        }

        public override void Show()
        {
            this.SupportActionBar.Show();
        }
    }
}

#pragma warning restore 0809
