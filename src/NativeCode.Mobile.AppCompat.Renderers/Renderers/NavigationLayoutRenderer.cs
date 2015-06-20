namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System.Collections.Generic;
    using System.Linq;

    using Android.Support.Design.Widget;
    using Android.Views;

    using NativeCode.Mobile.AppCompat.Controls;
    using NativeCode.Mobile.AppCompat.Extensions;

    using Xamarin.Forms.Platform.Android;

    public class NavigationLayoutRenderer : ViewRenderer<NavigationLayout, NavigationView>, NavigationView.IOnNavigationItemSelectedListener
    {
        private readonly Dictionary<IMenuItem, NavigationLayoutMenu> mappings = new Dictionary<IMenuItem, NavigationLayoutMenu>();

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            var menu = this.mappings[menuItem];

            if (menu.Command != null && menu.Command.CanExecute(menu.CommandParameter))
            {
                menu.Command.Execute(menu.CommandParameter);
                return true;
            }

            return false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.mappings.Any())
            {
                foreach (var kvp in this.mappings)
                {
                    kvp.Key.Dispose();
                }

                this.mappings.Clear();
            }

            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<NavigationLayout> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var context = this.Context.GetAppCompatThemedContext();
                var control = new NavigationView(context);
                control.SetFitsSystemWindows(true);
                control.SetNavigationItemSelectedListener(this);

                this.SetNativeControl(control);

                this.UpdateHeaderView();
                this.UpdateMenuItems();
            }
        }

        private void UpdateHeaderView()
        {
            if (this.Element.HeaderView != null)
            {
                // TODO: It's adding it, but it never shows up in the XML in monitor.
                var renderer = RendererFactory.GetRenderer(this.Element.HeaderView);
                this.Control.AddHeaderView(renderer.ViewGroup);
            }
        }

        private void UpdateMenuItems()
        {
            this.mappings.Clear();

            for (var index = 0; index < this.Element.Children.Count; index++)
            {
                // NOTE: Not sure if it's just my local machine or not, but this doesn't seem to resolve until compile-time.
                var menu = (NavigationLayoutMenu)this.Element.Children[index];
                var item = this.Control.Menu.Add(0, index, index, menu.Text);

                if (menu.Icon != null)
                {
                    item.SetIcon(menu.Icon.ToBitmapDrawable());
                }
#if DEBUG
                item.SetIcon(Resource.Drawable.abc_ic_search_api_mtrl_alpha);
#endif
                this.mappings.Add(item, menu);
            }
        }
    }
}