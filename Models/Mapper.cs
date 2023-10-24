using Zad1.Models.ImportExport;

namespace Zad1.Models
{
    public static class Mapper
    {
        public static List<CircleDto> GetCircleDtos(List<Circle> circles)
        {
            List<CircleDto> circleDtos = new List<CircleDto>();
            foreach (var circle in circles)
            {
                CircleDto circleDto = new()
                {
                    Width = circle.Pen.Width,
                    ColorName = circle.Pen.Color.Name,
                    StartCirclePoint = circle.StartCirclePoint,
                    Radius = circle.Radius
                };
                circleDtos.Add(circleDto);
            }
            return circleDtos;
        }
        public static List<Circle> GetCircles(List<CircleDto> circleDtos)
        {
            List<Circle> circles = new List<Circle>();
            foreach (var circleDto in circleDtos)
            {
                Circle circle = new()
                {
                    Pen = new Pen(Color.FromName(circleDto.ColorName), circleDto.Width),
                    StartCirclePoint = circleDto.StartCirclePoint,
                    Radius = circleDto.Radius,

                };
                circles.Add(circle);
            }
            return circles;
        }
        public static List<CustomRectangleDto> GetCustomRectangleDtos(List<CustomRectangle> customRectangles)
        {
            List<CustomRectangleDto> customRectangleDtos = new List<CustomRectangleDto>();
            foreach (var customRectangle in customRectangles)
            {
                CustomRectangleDto customRectangleDto = new()
                {
                    Width = customRectangle.Pen.Width,
                    ColorName = customRectangle.Pen.Color.Name,
                    Rectangle = customRectangle.Rectangle,
                };
                customRectangleDtos.Add(customRectangleDto);
            }
            return customRectangleDtos;
        }
        public static List<CustomRectangle> GetCustomRectangles(List<CustomRectangleDto> customRectangleDtos)
        {
            List<CustomRectangle> customRectangles = new List<CustomRectangle>();
            foreach (var customRectangleDto in customRectangleDtos)
            {
                CustomRectangle customRectangle = new()
                {
                    Pen = new Pen(Color.FromName(customRectangleDto.ColorName), customRectangleDto.Width),
                    Rectangle = customRectangleDto.Rectangle,
                };
                customRectangles.Add(customRectangle);
            }
            return customRectangles;
        }
        public static List<LineDto> GetLineDtos(List<Line> lines)
        {
            List<LineDto> lineDtos = new List<LineDto>();
            foreach (var line in lines)
            {
                LineDto lineDto = new()
                {
                    Width = line.Pen.Width,
                    ColorName = line.Pen.Color.Name,
                    StartPoint = line.StartPoint,
                    EndPoint = line.EndPoint
                };
                lineDtos.Add(lineDto);
            }
            return lineDtos;
        }
        public static List<Line> GetLines(List<LineDto> lineDtos)
        {
            List<Line> lines = new List<Line>();
            foreach (var lineDto in lineDtos)
            {
                Line line = new()
                {
                    Pen = new Pen(Color.FromName(lineDto.ColorName), lineDto.Width),
                    StartPoint = lineDto.StartPoint,
                    EndPoint = lineDto.EndPoint

                };
                lines.Add(line);
            }
            return lines;
        }
    }
}
