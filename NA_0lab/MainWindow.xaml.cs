using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NA_0lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Point2D
    {
        //Свойства класса — чтение снаружи, изменение только изнутри класса
        public int X { get; private set; }
        public int Y { get; private set; }
        //Конструктор класса
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }
        //Методы для изменения координат (смещение на заданную величину,
        //а не просто присваивание — поэтому это методы, а не сеттер свойства)
        public void AddX(int x)
        {
            X += x;
        }
        public void AddY(int y)
        {
            Y += y;
        }
    }
}