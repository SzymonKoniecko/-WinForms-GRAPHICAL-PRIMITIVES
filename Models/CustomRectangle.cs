namespace Zad1.Models
{
    public class CustomRectangle
    {
        public Pen Pen { get; set; }
        public Rectangle Rectangle { get; set; }
        public Graphics Graphics { get; set; }

        public CustomRectangle(Pen pen, Rectangle rect)
        {
            Pen = pen;
            Rectangle = rect;
        }

        public CustomRectangle()
        {
        }

        public void Draw(Graphics graphics)
        {
            Graphics = graphics;
            Graphics.DrawRectangle(Pen, Rectangle);
        }
    }
}