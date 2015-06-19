namespace NativeCode.Mobile.AppCompat.Controls
{
    using System.Windows.Input;

    public interface ICommandProvider
    {
        ICommand Command { get; }

        object CommandParameter { get; }
    }
}