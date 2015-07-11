namespace NativeCode.Mobile.AppCompat.Controls
{
    using System.Windows.Input;

    using Xamarin.Forms;

    public class NavigationLayoutMenu : View, ICommandProvider
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create<NavigationLayoutMenu, ICommand>(x => x.Command, default(ICommand));

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<NavigationLayoutMenu, object>(x => x.CommandParameter, default(object));

        public static readonly BindableProperty GroupProperty = BindableProperty.Create<NavigationLayoutMenu, int>(x => x.Group, default(int));

        public static readonly BindableProperty IconProperty = BindableProperty.Create<NavigationLayoutMenu, ImageSource>(x => x.Icon, default(ImageSource));

        public static readonly BindableProperty TextProperty = BindableProperty.Create<NavigationLayoutMenu, string>(x => x.Text, default(string));

        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        public int Group
        {
            get { return (int)this.GetValue(GroupProperty); }
            set { this.SetValue(GroupProperty, value); }
        }

        public ImageSource Icon
        {
            get { return (ImageSource)this.GetValue(IconProperty); }
            set { this.SetValue(IconProperty, value); }
        }

        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }
    }
}