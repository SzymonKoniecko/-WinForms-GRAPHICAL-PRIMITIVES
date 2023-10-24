namespace Zad1.Models
{
    public class Circle
    {
        public Pen Pen { get; set; }
        public Point StartCirclePoint { get; set; }
        public int Radius { get; set; }
        public Graphics Graphics { get; set; }
        public Circle(Pen pen, Point point, int radius)
        {
            Pen = pen;
            StartCirclePoint = point;
            Radius = radius;
        }

        public Circle()
        {
        }

        public void Draw(Graphics graphics)
        {
            Graphics = graphics;
            Graphics.DrawEllipse(Pen, StartCirclePoint.X - Radius, StartCirclePoint.Y - Radius, 2 * Radius, 2 * Radius);
        }
    }
}
