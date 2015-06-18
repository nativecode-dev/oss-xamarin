namespace NativeCode.Mobile.AppCompat.Extensions
{
    using Android.App;

    /// <summary>
    /// Provides extensions for <see cref="Activity" /> instances.
    /// </summary>
    public static class ActivityExtensions
    {
        /// <summary>
        /// Starts another Android activity.
        /// </summary>
        /// <typeparam name="TActivity">The type of the activity.</typeparam>
        /// <param name="activity">The activity.</param>
        public static void StartActivity<TActivity>(this Activity activity) where TActivity : Activity
        {
            activity.StartActivity(typeof(TActivity));
        }
    }
}