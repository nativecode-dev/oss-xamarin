namespace NativeCode.Mobile.AppCompat.Renderers.Extensions
{
    using NativeCode.Mobile.AppCompat.Controls;

    public static class CommandExtensions
    {
        public static void ExecuteCommand(this ICommandProvider provider)
        {
            var command = provider.Command;
            var parameter = provider.CommandParameter;

            if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }
    }
}