using System.Windows;
using System.Windows.Media;

namespace Demo.Visual
{
    public class SectorVisual:DrawingVisual
    {
        public SectorVisual()
        {
            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext c = geometry.Open())
            {
                c.BeginFigure(new Point(200, 200), true, true);

                c.LineTo(new Point(175, 50), true, true);

                c.ArcTo(new Point(20, 150), new Size(1, 1), 0, true, SweepDirection.Counterclockwise,
                    true, true);

                c.LineTo(new Point(200, 200), true, true);
            }

            using (DrawingContext context = RenderOpen())
            {
                Pen pen = new Pen(Brushes.Black, 1);
                context.DrawGeometry(Brushes.CornflowerBlue, pen, geometry);
            }
        }
    }
}
