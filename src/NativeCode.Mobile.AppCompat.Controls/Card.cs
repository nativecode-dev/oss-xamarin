namespace NativeCode.Mobile.AppCompat.Controls
{
    using System.Windows.Input;

    using Xamarin.Forms;

    public class Card : ContentView, ICommandProvider
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create<FloatingButton, ICommand>(x => x.Command, default(ICommand));

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<FloatingButton, object>(
            x => x.CommandParameter,
            default(object));

        public static readonly BindableProperty ElevationProperty = BindableProperty.Create<Card, double>(x => x.Elevation, default(double));

        public static readonly BindableProperty RadiusProperty = BindableProperty.Create<Card, double>(x => x.Radius, 5.0d);

        public Card()
        {
            this.Padding = new Thickness(5);
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

        public double Elevation
        {
            get { return (double)this.GetValue(ElevationProperty); }
            set { this.SetValue(ElevationProperty, value); }
        }

        public double Radius
        {
            get { return (double)this.GetValue(RadiusProperty); }
            set { this.SetValue(RadiusProperty, value); }
        }
    }
}