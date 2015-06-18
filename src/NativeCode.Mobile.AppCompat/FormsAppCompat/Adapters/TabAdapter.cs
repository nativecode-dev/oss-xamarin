namespace NativeCode.Mobile.AppCompat.FormsAppCompat.Adapters
{
    using System;
    using System.Collections.Generic;

    using Android.App;
    using Android.Graphics.Drawables;
    using Android.Views;

    using Java.Lang;

    using JavaObject = Java.Lang.Object;
    using SupportActionBar = Android.Support.V7.App.ActionBar;

    /// <summary>
    /// Adapts a <see cref="Android.Support.V7.App.ActionBar.Tab"/> to a <see cref="Android.App.ActionBar.Tab"/>.
    /// </summary>
    [Obsolete("Will be removed in a future version.", false)]
    internal class TabAdapter : ActionBar.Tab
    {
        private static readonly Dictionary<SupportActionBar.Tab, ActionBar.Tab> TabMappings = new Dictionary<SupportActionBar.Tab, ActionBar.Tab>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TabAdapter"/> class.
        /// </summary>
        /// <param name="supportTab">The support tab.</param>
        public TabAdapter(SupportActionBar.Tab supportTab)
        {
            this.SupportTab = supportTab;
            TabMappings.Add(supportTab, this);
        }

        public override ICharSequence ContentDescriptionFormatted
        {
            get { return this.SupportTab.ContentDescriptionFormatted; }
        }

        public override View CustomView
        {
            get { return this.SupportTab.CustomView; }
        }

        public override Drawable Icon
        {
            get { return this.SupportTab.Icon; }
        }

        public override int Position
        {
            get { return this.SupportTab.Position; }
        }

        public override JavaObject Tag
        {
            get { return this.SupportTab.Tag; }
        }

        public override ICharSequence TextFormatted
        {
            get { return this.SupportTab.TextFormatted; }
        }

        internal SupportActionBar.Tab SupportTab { get; private set; }

        public override void Select()
        {
            this.SupportTab.Select();
        }

        public override ActionBar.Tab SetContentDescription(int resId)
        {
            this.SupportTab.SetContentDescription(resId);
            return this;
        }

        public override ActionBar.Tab SetContentDescription(ICharSequence contentDesc)
        {
            this.SupportTab.SetContentDescription(contentDesc);
            return this;
        }

        public override ActionBar.Tab SetCustomView(View view)
        {
            this.SupportTab.SetCustomView(view);
            return this;
        }

        public override ActionBar.Tab SetCustomView(int layoutResId)
        {
            this.SupportTab.SetCustomView(layoutResId);
            return this;
        }

        public override ActionBar.Tab SetIcon(Drawable icon)
        {
            this.SupportTab.SetIcon(icon);
            return this;
        }

        public override ActionBar.Tab SetIcon(int resId)
        {
            this.SupportTab.SetIcon(resId);
            return this;
        }

        public override ActionBar.Tab SetTabListener(ActionBar.ITabListener listener)
        {
            this.SupportTab.SetTabListener(new TabListenerAdapter(listener, this));
            return this;
        }

        public override ActionBar.Tab SetTag(JavaObject obj)
        {
            this.SupportTab.SetTag(obj);
            return this;
        }

        public override ActionBar.Tab SetText(int resId)
        {
            this.SupportTab.SetText(resId);
            return this;
        }

        public override ActionBar.Tab SetText(ICharSequence text)
        {
            this.SupportTab.SetText(text);
            return this;
        }

        internal static ActionBar.Tab ForSupportTab(SupportActionBar.Tab supportTab)
        {
            return TabMappings[supportTab];
        }
    }
}