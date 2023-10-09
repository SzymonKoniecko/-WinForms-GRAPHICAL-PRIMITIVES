using Zad1.Models;

namespace Zad1
{
    partial class Main 
    {
        public void CircleInit()
        {
            Circle circle = new Circle();
            circle.Pen = new(circleColor, circleThickness);
            circle.Radius = CalculateRadius(startPoint, endPoint);
            circle.Point = startPoint;
            _Circles.Add(circle);
        }
        private void Changer(object sender, EventArgs e)
        {
            try
            {
                circleColor = Color.FromName(colorTextBox.Text);
                circleThickness = int.Parse(thicknessTextBox.Text);
                this.Invalidate(); // Odświeżenie obszaru rysowania
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public int CalculateRadius(Point startPoint, Point endPoint)
        {
            double radius = Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));
            return int.Parse(radius.ToString());
        }
    }
}