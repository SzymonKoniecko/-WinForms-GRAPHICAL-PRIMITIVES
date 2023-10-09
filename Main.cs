using Zad1.Models;

namespace Zad1
{
    public partial class Main : Form
    {
        private TextBox colorTextBox;
        private TextBox thicknessTextBox;
        private Button drawButton;
        private Color circleColor = Color.Blue;
        private int circleThickness = 2;
        private static Point startPoint;
        private static Point endPoint;
        private bool isDrawing = false;
        private List<Circle> _Circles = new List<Circle>();
        public Main()
        {

            this.Text = "Panel graficzny";
            this.Size = new Size(1200, 800);

            Label colorLabel = new Label();
            colorLabel.Text = "Kolor linii:";
            colorLabel.Location = new Point(10, 10);

            colorTextBox = new TextBox();
            colorTextBox.Location = new Point(120, 10);
            colorTextBox.Text = "Blue";

            Label thicknessLabel = new Label();
            thicknessLabel.Text = "Grubość linii:";
            thicknessLabel.Location = new Point(10, 40);

            thicknessTextBox = new TextBox();
            thicknessTextBox.Location = new Point(120, 40);
            thicknessTextBox.Text = "2";

            drawButton = new Button();
            drawButton.Text = "Edytuj";
            drawButton.Location = new Point(10, 70);
            drawButton.Click += new EventHandler(Changer);

            this.Controls.Add(colorLabel);
            this.Controls.Add(colorTextBox);
            this.Controls.Add(thicknessLabel);
            this.Controls.Add(thicknessTextBox);
            this.Controls.Add(drawButton);
            this.DoubleBuffered = true;
            this.MouseUp += new MouseEventHandler(MouseUpEvent);
            this.MouseDown += new MouseEventHandler(MouseReleaseEvent);
            this.MouseMove += new MouseEventHandler(MouseMoveEvent);
            this.Paint += new PaintEventHandler(PaintEvent);
        }
        private void MouseReleaseEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                endPoint = startPoint;
                isDrawing = true;
            }
        }
        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                endPoint = e.Location;
                this.Paint += new PaintEventHandler(PaintEvent);
                this.Invalidate();
            }
        }
        private void MouseUpEvent(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            CircleInit();
            this.Paint += new PaintEventHandler(PaintEvent);
            if (e.Button == MouseButtons.Left)
            {

            }
            else if (e.Button == MouseButtons.Right)
            {
                // idk
            }
        }
        private void PaintEvent(object sender, PaintEventArgs e)
        {
            foreach (var circle in _Circles)
            {
                circle.Draw(this, e);
            }
        }
    }
}
