namespace NativeCode.Mobile.AppCompat.Controls
{
    using System.Windows.Input;

    using Xamarin.Forms;

    public class NavigationMenu : View, ICommandProvider
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create<NavigationMenu, ICommand>(x => x.Command, default(ICommand));

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<NavigationMenu, object>(
            x => x.CommandParameter,
            default(object));

        public static readonly BindableProperty IconProperty = BindableProperty.Create<NavigationMenu, ImageSource>(x => x.Icon, default(ImageSource));

        public static readonly BindableProperty TextProperty = BindableProperty.Create<NavigationMenu, string>(x => x.Text, default(string));

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