namespace Zad1.Models
{
    public class Circle
    {
        public Pen Pen { get; set; }
        public Point Point { get; set; }
        public int Radius { get; set; }
        public Graphics Graphics { get; set; }
        public void Draw(object sender, PaintEventArgs e)
        {
            Graphics = e.Graphics;
            Graphics.DrawEllipse(Pen, Point.X - Radius, Point.Y - Radius, 2 * Radius, 2 * Radius);
        }
    }
}
