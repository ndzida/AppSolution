using System.Windows.Input;

namespace MainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand New = new RoutedUICommand("New", "New", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.N, ModifierKeys.Control) });

        public static readonly RoutedUICommand Edit = new RoutedUICommand("Edit", "Edit", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.E, ModifierKeys.Control) });

        public static readonly RoutedUICommand Save = new RoutedUICommand("Save", "Save", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.S, ModifierKeys.Control) });

        public static readonly RoutedUICommand Delete = new RoutedUICommand("Delete", "Delete", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.D, ModifierKeys.Control) });
    }
}
