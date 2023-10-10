using Zad1.Models;

namespace Zad1
{
    public partial class Main : Form
    {
        private TextBox colorTextBox;
        private TextBox thicknessTextBox;
        private Button drawOptionsBtn;
        private Button exportBtn;
        private Button importBtn;
        private RadioButton lineRadioBtn;
        private RadioButton rectangleRadioBtn;
        private RadioButton circleRadioBtn;
        private List<Circle> _circles = new List<Circle>();
        private List<Line> _lines = new List<Line>();
        private List<CustomRectangle> _rectangles = new List<CustomRectangle>();


        private Circle currentCircle;
        private CustomRectangle currentRectangle;
        private Line currentLine;
        private Point startMouseDownLocation;
        private Point mouseDownLocation;
        private Color circleColor = Color.Blue;
        private int circleThickness = 2;

        public Main()
        {
            Label colorLabel = new Label();
            colorLabel.Text = "Kolor linii:";
            colorLabel.Location = new Point(10, 10);

            colorTextBox = new TextBox();
            colorTextBox.Location = new Point(120, 10);
            colorTextBox.Text = "Blue";

            Label thicknessLabel = new Label();
            thicknessLabel.Text = "Grubość linii:";
            thicknessLabel.Location = new Point(10, 40);
            lineRadioBtn = new RadioButton();
            lineRadioBtn.Text = "Line";
            lineRadioBtn.Location = new Point(300, 10);
            rectangleRadioBtn = new RadioButton();
            rectangleRadioBtn.Text = "Rectangle";
            rectangleRadioBtn.Location = new Point(300, 30);
            circleRadioBtn = new RadioButton();
            circleRadioBtn.Text = "Circle";
            circleRadioBtn.Location = new Point(300, 50);

            exportBtn = new Button();
            exportBtn.Text = "Export";
            exportBtn.Location = new System.Drawing.Point(450, 20);
            importBtn = new Button();
            importBtn.Text = "Import";
            importBtn.Location = new System.Drawing.Point(450, 40);
            importBtn.Click += new EventHandler(Import);
            exportBtn.Click += new EventHandler(Export);
            thicknessTextBox = new TextBox();
            thicknessTextBox.Location = new Point(120, 40);
            thicknessTextBox.Text = "2";
            drawOptionsBtn = new Button();
            drawOptionsBtn.Text = "Edytuj";
            drawOptionsBtn.Location = new Point(10, 70);
            drawOptionsBtn.Click += new EventHandler(PenChanger);

            this.Size = new Size(1200, 800);
            this.Controls.Add(colorLabel);
            this.Controls.Add(colorTextBox);
            this.Controls.Add(thicknessLabel);
            this.Controls.Add(thicknessTextBox);
            this.Controls.Add(drawOptionsBtn);
            this.Controls.Add(lineRadioBtn);
            this.Controls.Add(rectangleRadioBtn);
            this.Controls.Add(circleRadioBtn);
            this.Controls.Add(importBtn);
            this.Controls.Add(exportBtn);
            Text = "Zad1";
            DoubleBuffered = true;
            currentCircle = null;
            mouseDownLocation = Point.Empty;
            MouseDown += MouseDownEvent;
            MouseMove += MouseMoveEvent;
            MouseUp += MouseUpEvent;
            Paint += Draw;
        }
    }
}
