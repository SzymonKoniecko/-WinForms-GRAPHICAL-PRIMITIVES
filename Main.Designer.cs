using Newtonsoft.Json;
using System;
using System.Drawing;
using Zad1.Models;
using Zad1.Models.ImportExport;

namespace Zad1
{
    partial class Main
    {

        private void Export(object sender, EventArgs e)
        {
            ImportExport importExport = new()
            {
                _circleDtos = Mapper.GetCircleDtos(_circles),
                _rectangleDtos = Mapper.GetCustomRectangleDtos(_rectangles),
                _lineDtos = Mapper.GetLineDtos(_lines)
            };
            var json = JsonConvert.SerializeObject(importExport);
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented // Formatowanie z wcięciami dla czytelności
            };
            File.WriteAllText("Export.json", json);
        }

        private void Import(object sender, EventArgs e)
        {
            try
            {
                string json = File.ReadAllText("Export.json");
                var importExport = JsonConvert.DeserializeObject<ImportExport>(json);
                _lines = Mapper.GetLines(importExport._lineDtos);
                _circles = Mapper.GetCircles(importExport._circleDtos);
                _rectangles = Mapper.GetCustomRectangles(importExport._rectangleDtos);
                Draw(sender, new PaintEventArgs(CreateGraphics(), this.ClientRectangle));
                /*Graphics g = this.CreateGraphics();
                foreach (var circle in _circles)
                {
                    circle.Graphics = g;
                    circle.Draw(g);
                }
                foreach (var line in _lines)
                {
                    line.Graphics = g;
                    line.Draw(g);
                }
                foreach (var rectangle in _rectangles)
                {
                    rectangle.Graphics = g;
                    rectangle.Draw(g);
                }*/
                this.Invalidate();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File doesnt exist");
            }
            catch (JsonException)
            {
                Console.WriteLine("Cannot deserialize object");
            }
        }
        private void PenChanger(object sender, EventArgs e)
        {
            circleColor = Color.FromName(colorFiguresTextBox.Text);
            circleThickness = int.Parse(thicknessTextBox.Text);
            this.Invalidate();
        }
        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (circleRadioBtn.Checked)
                {
                    mouseDownLocation = e.Location;
                    var pen = new Pen(circleColor, circleThickness);
                    currentCircle = new Circle(pen, mouseDownLocation, 0);
                }
                else if (lineRadioBtn.Checked)
                {
                    var pen = new Pen(circleColor, circleThickness);
                    currentLine = new Line(pen, e.Location, e.Location);
                }
                else if (rectangleRadioBtn.Checked)
                {
                    var pen = new Pen(circleColor, circleThickness);
                    startMouseDownLocation = e.Location;
                    var rect = new Rectangle(startMouseDownLocation, new Size(0, 0));
                    currentRectangle = new CustomRectangle(pen, rect);
                }
            }
        }
        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (circleRadioBtn.Checked)
            {
                if (currentCircle != null)
                {
                    int deltaX = e.X - mouseDownLocation.X;
                    int deltaY = e.Y - mouseDownLocation.Y;
                    currentCircle.Radius = (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                    this.Invalidate();
                }
            }
            else if (lineRadioBtn.Checked)
            {
                if (currentLine != null)
                {
                    currentLine.EndPoint = e.Location;
                    this.Invalidate();
                }
            }
            else if (rectangleRadioBtn.Checked)
            {
                if (currentRectangle != null)
                {
                    int width = e.X - startMouseDownLocation.X;
                    int height = e.Y - startMouseDownLocation.Y;
                    var rect = new Rectangle(startMouseDownLocation, new Size(width, height));
                    currentRectangle.Rectangle = rect;
                    this.Invalidate();
                }
            }
        }
        private void MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && currentCircle != null)
            {
                if (circleRadioBtn.Checked)
                {
                    mouseDownLocation = Point.Empty;
                    _circles.Add(currentCircle);
                    currentCircle = null;
                }
            }
            if (e.Button == MouseButtons.Left && currentLine != null)
            {
                if (lineRadioBtn.Checked)
                {
                    currentLine.EndPoint = e.Location;
                    _lines.Add(currentLine);
                    currentLine = null;
                }
            }
            if (e.Button == MouseButtons.Left && currentRectangle != null)
            {
                if (rectangleRadioBtn.Checked)
                {
                    int width = e.X - startMouseDownLocation.X;
                    int height = e.Y - startMouseDownLocation.Y;
                    var rect = new Rectangle(startMouseDownLocation, new Size(width, height));
                    currentRectangle.Rectangle = rect;
                    _rectangles.Add(currentRectangle);
                    currentRectangle = null;
                }
            }
        }
        private void Draw(object sender, PaintEventArgs e)
        {
            foreach (var circle in _circles)
            {
                circle.Draw(e.Graphics);
            }
            foreach (var line in _lines)
            {
                line.Draw(e.Graphics);
            }
            foreach (var rectangle in _rectangles)
            {
                rectangle.Draw(e.Graphics);
            }
            if (circleRadioBtn.Checked)
            {
                if (currentCircle != null)
                {
                    currentCircle.Draw(e.Graphics);
                }
            }
            else if (lineRadioBtn.Checked)
            {
                if (currentLine != null)
                {
                    currentLine.Draw(e.Graphics);
                }
            }
            else if (rectangleRadioBtn.Checked)
            {
                if (currentRectangle != null)
                {
                    currentRectangle.Draw(e.Graphics);
                }
            }
        }
    }
}