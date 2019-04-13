using System.Windows;

namespace Demo.Visual
{
    public class VisualContainer:FrameworkElement
    {
        private readonly SectorVisual _visual = new SectorVisual();

        protected override System.Windows.Media.Visual GetVisualChild(int index)
        {
            return _visual;
        }

        protected override int VisualChildrenCount => 1;
    }
}
