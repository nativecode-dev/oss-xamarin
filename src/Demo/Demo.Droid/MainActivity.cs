namespace Demo.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;

    using NativeCode.Mobile.AppCompat.FormsAppCompat;
    using NativeCode.Mobile.AppCompat.Renderers;
    using NativeCode.Mobile.AppCompat.Renderers.Renderers;

    using Xamarin.Forms;

    [Activity(ConfigurationChanges = AppConfig, MainLauncher = true, Theme = AppTheme)]
    public class MainActivity : AppCompatFormsApplicationActivity
    {
        private const ConfigChanges AppConfig = ConfigChanges.Orientation | ConfigChanges.ScreenSize;

        private const string AppTheme = "@style/AppTheme";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Forms.Init(this, savedInstanceState);
            FormsAppCompat.EnableAll();

            this.LoadApplication(new App());
        }
    }
}