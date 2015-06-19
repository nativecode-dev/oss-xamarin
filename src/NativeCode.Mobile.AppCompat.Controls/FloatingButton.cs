namespace NativeCode.Mobile.AppCompat.Controls
{
    using System.Windows.Input;

    using Xamarin.Forms;

    /// <summary>
    /// Provides a floating action button.
    /// </summary>
    public class FloatingButton : View, ICommandProvider
    {
        public static readonly BindableProperty ButtonSizeProperty = BindableProperty.Create<FloatingButton, FloatingButtonSize>(
            x => x.ButtonSize,
            default(FloatingButtonSize),
            BindingMode.OneWayToSource);

        public static readonly BindableProperty ColorProperty = BindableProperty.Create<FloatingButton, Color>(x => x.Color, default(Color));

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<FloatingButton, ICommand>(x => x.Command, default(ICommand));

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<FloatingButton, object>(
            x => x.CommandParameter,
            default(object));

        public static readonly BindableProperty IconProperty = BindableProperty.Create<FloatingButton, ImageSource>(x => x.Icon, default(ImageSource));

        /// <summary>
        /// Gets or sets the size of the button.
        /// </summary>
        public FloatingButtonSize ButtonSize
        {
            get { return (FloatingButtonSize)this.GetValue(ButtonSizeProperty); }
            set { this.SetValue(ButtonSizeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color of the button.
        /// </summary>
        public Color Color
        {
            get { return (Color)this.GetValue(ColorProperty); }
            set { this.SetValue(ColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        public object CommandParameter
        {
            get { return this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        public ImageSource Icon
        {
            get { return (ImageSource)this.GetValue(IconProperty); }
            set { this.SetValue(IconProperty, value); }
        }
    }
}