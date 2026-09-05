using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA_0lab.Models
{
    public class Triangle
    {
        // Свойства класса (три точки)
        public Point2D P1 { get; private set; }
        public Point2D P2 { get; private set; }
        public Point2D P3 { get; private set; }

        // Конструктор
        public Triangle(Point2D p1, Point2D p2, Point2D p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        // Метод для перемещения по X
        public void AddX(int x)
        {
            P1.AddX(x);
            P2.AddX(x);
            P3.AddX(x);
        }

        // Метод для перемещения по Y
        public void AddY(int y)
        {
            P1.AddY(y);
            P2.AddY(y);
            P3.AddY(y);
        }
    }
}
