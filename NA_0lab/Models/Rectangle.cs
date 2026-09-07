using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA_0lab.Models
{
    public class Rectangle
    {
        // Свойства класса
        public Point2D TopLeft { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        // Конструктор — создаем через начальную точку и длины сторон
        public Rectangle(Point2D topLeft, int width, int height)
        {
            TopLeft = topLeft;
            Width = width;
            Height = height;
        }

        public void AddX(int x)
        {
            TopLeft.AddX(x);
        }

        public void AddY(int y)
        {
            TopLeft.AddY(y);
        }

        // Вспомогательные методы для получения других углов
        public Point2D TopRight => new Point2D(TopLeft.X + Width, TopLeft.Y);
        public Point2D BottomLeft => new Point2D(TopLeft.X, TopLeft.Y + Height);
        public Point2D BottomRight => new Point2D(TopLeft.X + Width, TopLeft.Y + Height);
    }
}
