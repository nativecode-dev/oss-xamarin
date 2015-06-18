using NativeCode.Mobile.AppCompat.Renderers.Platforms;

using Xamarin.Forms;

[assembly: Dependency(typeof(UserNotifier))]

namespace NativeCode.Mobile.AppCompat.Renderers.Platforms
{
    using System;

    using Android.App;
    using Android.Support.Design.Widget;
    using Android.Views;

    using NativeCode.Mobile.AppCompat.Controls.Platforms;
    using NativeCode.Mobile.AppCompat.FormsAppCompat;

    public class UserNotifier : IUserNotifier
    {
        public void Notify(string message, TimeSpan duration)
        {
            using (var snackbar = Snackbar.Make(this.GetSnackbarAnchorView(), message, (int)duration.TotalMilliseconds))
            {
                snackbar.Show();
            }
        }

        public void NotifyLong(string message)
        {
            this.Notify(message, TimeSpan.FromSeconds(10));
        }

        public void NotifyShort(string message)
        {
            this.Notify(message, TimeSpan.FromSeconds(3));
        }

        private View GetSnackbarAnchorView()
        {
            var provider = Forms.Context as IAppCompatDelegateProvider;

            if (provider == null)
            {
                var activity = (Activity)Forms.Context;
                return activity.FindViewById(Resource.Id.decor_content_parent);
            }

            return provider.GetCoordinatorLayout();
        }
    }
}