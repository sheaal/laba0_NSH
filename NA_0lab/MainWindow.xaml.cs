using NA_0lab.Models;
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
using MyRectangle = NA_0lab.Models.Rectangle;

namespace NA_0lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void DrawTriangle(Triangle triangle)
        {
            // Очищаем холст, если нужно
            Scene.Children.Clear();

            // Создаем линии между точками
            var line1 = new Line
            {
                X1 = triangle.P1.X,
                Y1 = triangle.P1.Y,
                X2 = triangle.P2.X,
                Y2 = triangle.P2.Y,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };

            var line2 = new Line
            {
                X1 = triangle.P2.X,
                Y1 = triangle.P2.Y,
                X2 = triangle.P3.X,
                Y2 = triangle.P3.Y,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };

            var line3 = new Line
            {
                X1 = triangle.P3.X,
                Y1 = triangle.P3.Y,
                X2 = triangle.P1.X,
                Y2 = triangle.P1.Y,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };

            // Добавляем линии на холст
            Scene.Children.Add(line1);
            Scene.Children.Add(line2);
            Scene.Children.Add(line3);
        }

        private void RandomTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();

            // координаты от 50 до 350
            int x1 = random.Next(50, 350);
            int y1 = random.Next(50, 300);
            int x2 = random.Next(50, 350);
            int y2 = random.Next(50, 300);
            int x3 = random.Next(50, 350);
            int y3 = random.Next(50, 300);

            var p1 = new Point2D(x1, y1);
            var p2 = new Point2D(x2, y2);
            var p3 = new Point2D(x3, y3);

            var triangle = new Triangle(p1, p2, p3);
            DrawTriangle(triangle);
        }

        private void DrawRectangle(MyRectangle rectangle)
        {
            Scene.Children.Clear();

            var p1 = rectangle.TopLeft;
            var p2 = rectangle.TopRight;
            var p3 = rectangle.BottomRight;
            var p4 = rectangle.BottomLeft;

            var line1 = new Line
            {
                X1 = p1.X,
                Y1 = p1.Y,
                X2 = p2.X,
                Y2 = p2.Y,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };

            var line2 = new Line
            {
                X1 = p2.X,
                Y1 = p2.Y,
                X2 = p3.X,
                Y2 = p3.Y,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };

            var line3 = new Line
            {
                X1 = p3.X,
                Y1 = p3.Y,
                X2 = p4.X,
                Y2 = p4.Y,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };

            var line4 = new Line
            {
                X1 = p4.X,
                Y1 = p4.Y,
                X2 = p1.X,
                Y2 = p1.Y,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };

            Scene.Children.Add(line1);
            Scene.Children.Add(line2);
            Scene.Children.Add(line3);
            Scene.Children.Add(line4);
        }

        private void DrawTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем три точки
            var p1 = new Point2D(100, 100);
            var p2 = new Point2D(200, 100);
            var p3 = new Point2D(150, 200);

            // Создаем треугольник
            var triangle = new Triangle(p1, p2, p3);

            // Рисуем его
            DrawTriangle(triangle);
        }

        private void DrawRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            var topLeft = new Point2D(100, 100);
            var rectangle = new MyRectangle(topLeft, 150, 100);

            DrawRectangle(rectangle);
        }
    }
}