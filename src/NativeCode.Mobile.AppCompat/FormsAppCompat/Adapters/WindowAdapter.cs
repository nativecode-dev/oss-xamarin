namespace NativeCode.Mobile.AppCompat.FormsAppCompat.Adapters
{
    using Android.Content.Res;
    using Android.Graphics;
    using Android.Graphics.Drawables;
    using Android.Media;
    using Android.Net;
    using Android.OS;
    using Android.Support.V7.App;
    using Android.Views;

    using Java.Lang;

    /// <summary>
    /// Adapts an existing <see cref="Window"/> to override required methods to implement <see cref="AppCompatDelegate"/>.
    /// </summary>
    internal class WindowAdapter : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowAdapter"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="appCompatDelegateProvider">The application delegate provider.</param>
        internal WindowAdapter(Window window, IAppCompatDelegateProvider appCompatDelegateProvider) : base(window.Context)
        {
            this.AppCompatDelegateProvider = appCompatDelegateProvider;
            this.Callback = window.Callback;
            this.Window = window;
        }

        public override bool IsFloating
        {
            get { return this.Window.IsFloating; }
        }

        public override LayoutInflater LayoutInflater
        {
            get { return this.Window.LayoutInflater; }
        }

        public override int NavigationBarColor
        {
            get { return this.Window.NavigationBarColor; }
        }

        public override int StatusBarColor
        {
            get { return this.Window.StatusBarColor; }
        }

        public override Stream VolumeControlStream
        {
            get { return this.Window.VolumeControlStream; }
            set { this.Window.VolumeControlStream = value; }
        }

        public override View CurrentFocus
        {
            get { return this.Window.CurrentFocus; }
        }

        public override View DecorView
        {
            get { return this.Window.DecorView; }
        }

        protected IAppCompatDelegateProvider AppCompatDelegateProvider { get; private set; }

        protected AppCompatDelegate AppCompatDelegate
        {
            get { return this.AppCompatDelegateProvider.AppCompatDelegate; }
        }

        protected Window Window { get; private set; }

        public override void AddContentView(View view, ViewGroup.LayoutParams @params)
        {
            this.Window.AddContentView(view, @params);
        }

        public override void CloseAllPanels()
        {
            this.Window.CloseAllPanels();
        }

        public override void ClosePanel(int featureId)
        {
            this.Window.ClosePanel(featureId);
        }

        public override void InvalidatePanelMenu(WindowFeatures featureId)
        {
            this.Window.InvalidatePanelMenu(featureId);
        }

        public override bool IsShortcutKey(Keycode keyCode, KeyEvent e)
        {
            return this.Window.IsShortcutKey(keyCode, e);
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            this.Window.OnConfigurationChanged(newConfig);
        }

        public override void OpenPanel(int featureId, KeyEvent e)
        {
            this.Window.OpenPanel(featureId, e);
        }

        public override View PeekDecorView()
        {
            return this.Window.PeekDecorView();
        }

        public override bool PerformContextMenuIdentifierAction(int id, MenuPerformFlags flags)
        {
            return this.Window.PerformContextMenuIdentifierAction(id, flags);
        }

        public override bool PerformPanelIdentifierAction(int featureId, int id, MenuPerformFlags flags)
        {
            return this.Window.PerformPanelIdentifierAction(featureId, id, flags);
        }

        public override bool PerformPanelShortcut(int featureId, Keycode keyCode, KeyEvent e, MenuPerformFlags flags)
        {
            return this.Window.PerformPanelShortcut(featureId, keyCode, e, flags);
        }

        public override bool RequestFeature(WindowFeatures featureId)
        {
            return this.AppCompatDelegate.RequestWindowFeature((int)featureId);
        }

        public override void RestoreHierarchyState(Bundle savedInstanceState)
        {
            this.Window.RestoreHierarchyState(savedInstanceState);
        }

        public override Bundle SaveHierarchyState()
        {
            return this.Window.SaveHierarchyState();
        }

        public override void SetBackgroundDrawable(Drawable drawable)
        {
            this.Window.SetBackgroundDrawable(drawable);
        }

        public override void SetChildDrawable(int featureId, Drawable drawable)
        {
            this.Window.SetChildDrawable(featureId, drawable);
        }

        public override void SetChildInt(int featureId, int value)
        {
            this.Window.SetChildInt(featureId, value);
        }

        public override void SetContentView(View view)
        {
            this.Window.SetContentView(view);
        }

        public override void SetContentView(View view, ViewGroup.LayoutParams @params)
        {
            this.Window.SetContentView(view, @params);
        }

        public override void SetContentView(int layoutResId)
        {
            this.Window.SetContentView(layoutResId);
        }

        public override void SetFeatureDrawable(WindowFeatures featureId, Drawable drawable)
        {
            this.Window.SetFeatureDrawable(featureId, drawable);
        }

        public override void SetFeatureDrawableAlpha(WindowFeatures featureId, int alpha)
        {
            this.Window.SetFeatureDrawableAlpha(featureId, alpha);
        }

        public override void SetFeatureDrawableResource(WindowFeatures featureId, int resId)
        {
            this.Window.SetFeatureDrawableResource(featureId, resId);
        }

        public override void SetFeatureDrawableUri(WindowFeatures featureId, Uri uri)
        {
            this.Window.SetFeatureDrawableUri(featureId, uri);
        }

        public override void SetFeatureInt(WindowFeatures featureId, int value)
        {
            this.Window.SetFeatureInt(featureId, value);
        }

        public override void SetNavigationBarColor(Color color)
        {
            this.Window.SetNavigationBarColor(color);
        }

        public override void SetStatusBarColor(Color color)
        {
            this.Window.SetStatusBarColor(color);
        }

        public override void SetTitle(ICharSequence title)
        {
            this.Window.SetTitle(title);
        }

        public override void SetTitleColor(Color textColor)
        {
            this.Window.SetTitleColor(textColor);
        }

        public override bool SuperDispatchGenericMotionEvent(MotionEvent e)
        {
            return this.Window.SuperDispatchGenericMotionEvent(e);
        }

        public override bool SuperDispatchKeyEvent(KeyEvent e)
        {
            return this.Window.SuperDispatchKeyEvent(e);
        }

        public override bool SuperDispatchKeyShortcutEvent(KeyEvent e)
        {
            return this.Window.SuperDispatchKeyShortcutEvent(e);
        }

        public override bool SuperDispatchTouchEvent(MotionEvent e)
        {
            return this.Window.SuperDispatchTouchEvent(e);
        }

        public override bool SuperDispatchTrackballEvent(MotionEvent e)
        {
            return this.Window.SuperDispatchTrackballEvent(e);
        }

        public override void TakeInputQueue(InputQueue.ICallback callback)
        {
            this.Window.TakeInputQueue(callback);
        }

        public override void TakeKeyEvents(bool get)
        {
            this.Window.TakeKeyEvents(get);
        }

        public override void TakeSurface(ISurfaceHolderCallback2 callback)
        {
            this.Window.TakeSurface(callback);
        }

        public override void TogglePanel(int featureId, KeyEvent e)
        {
            this.Window.TogglePanel(featureId, e);
        }

        protected override void OnActive()
        {
            this.Window.MakeActive();
        }
    }
}