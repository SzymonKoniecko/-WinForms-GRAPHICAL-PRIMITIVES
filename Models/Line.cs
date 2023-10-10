namespace Zad1.Models
{
    public class Line
    {
        public Pen Pen { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Graphics Graphics { get; set; }
        public Line(Pen pen, Point start, Point end)
        {
            Pen = pen;
            StartPoint = start;
            EndPoint = end;
        }

        public Line()
        {
        }

        public void Draw(Graphics graphics)
        {
            Graphics = graphics;
            Graphics.DrawLine(Pen, StartPoint, EndPoint);
        }
    }
}
