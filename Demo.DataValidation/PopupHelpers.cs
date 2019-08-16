namespace Demo.DataValidation
{
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls.Primitives;

    public class PopupHelpers
    {
        public static bool GetMoveWithPlacementTarget(DependencyObject obj)
        {
            return (bool)obj.GetValue(MoveWithPlacementTargetProperty);
        }

        public static void SetMoveWithPlacementTarget(DependencyObject obj, bool value)
        {
            obj.SetValue(MoveWithPlacementTargetProperty, value);
        }

        // Using a DependencyProperty as the backing store for MoveWithPlacementTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MoveWithPlacementTargetProperty =
            DependencyProperty.RegisterAttached("MoveWithPlacementTarget", typeof(bool), typeof(PopupHelpers), new PropertyMetadata(false,OnMoveWithPlacementTargetChanged));

        private static void OnMoveWithPlacementTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Popup pop)) return;
            pop.Opened += delegate
            {
                DependencyObject dp = (d as Popup).PlacementTarget;
                if (dp == null) return;
                Window win = Window.GetWindow(dp);
                if (win == null) return;
                win.LocationChanged += delegate
                {
                    UpdatePopupPosition(pop);
                };
                win.SizeChanged += delegate { UpdatePopupPosition(pop); };
            };
        }

        private static void UpdatePopupPosition(Popup pop)
        {
            if (pop == null || pop.IsOpen == false) return;
            MethodInfo method = typeof(Popup).GetMethod(
                "UpdatePosition",
                BindingFlags.Instance | BindingFlags.NonPublic);
            if (method == null) return;
            try
            {
                method.Invoke(pop, null);
            }
            catch { }
        }
    }
}
