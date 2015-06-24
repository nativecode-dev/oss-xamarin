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
            var activity = (Activity)Forms.Context;
            var view = activity.FindViewById(Resource.Id.decor_content_parent);
            var provider = Forms.Context as IAppCompatCoordinatorLayoutProvider;

            if (provider == null)
            {
                return view;
            }

            return provider.GetCoordinatorLayout() ?? view;
        }
    }
}