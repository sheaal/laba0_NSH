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
    public partial class MainWindow : Window
    {
        // Хранение текущей фигуры
        private Triangle _currentTriangle;
        private MyRectangle _currentRectangle;
        private bool _isTriangle = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawTriangle(Triangle triangle)
        {
            Scene.Children.Clear();

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

            Scene.Children.Add(line1);
            Scene.Children.Add(line2);
            Scene.Children.Add(line3);
        }

        private void RandomTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            _currentTriangle = new Triangle(
                new Point2D(random.Next(50, 350), random.Next(50, 300)),
                new Point2D(random.Next(50, 350), random.Next(50, 300)),
                new Point2D(random.Next(50, 350), random.Next(50, 300))
            );
            _isTriangle = true;
            DrawTriangle(_currentTriangle);
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

        private void DrawUserTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentTriangle = new Triangle(
                    new Point2D(int.Parse(P1X.Text), int.Parse(P1Y.Text)),
                    new Point2D(int.Parse(P2X.Text), int.Parse(P2Y.Text)),
                    new Point2D(int.Parse(P3X.Text), int.Parse(P3Y.Text))
                );
                _isTriangle = true;
                DrawTriangle(_currentTriangle);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа в поля координат!", "Ты инвалид", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DrawTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTriangle = new Triangle(
                new Point2D(100, 100),
                new Point2D(200, 100),
                new Point2D(150, 200)
            );
            _isTriangle = true;
            DrawTriangle(_currentTriangle);
        }

        private void DrawRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            _currentRectangle = new MyRectangle(new Point2D(100, 100), 150, 100);
            _isTriangle = false;
            DrawRectangle(_currentRectangle);
        }

        private void DrawSquareButton_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            int side = random.Next(30, 150);

            _currentRectangle = new MyRectangle(
                new Point2D(random.Next(50, 300), random.Next(50, 200)),
                side, side
            );
            _isTriangle = false;
            DrawRectangle(_currentRectangle);
        }

        private void MoveLeftButton_Click(object sender, RoutedEventArgs e)
        {
            MoveShape(-10, 0);
        }

        private void MoveRightButton_Click(object sender, RoutedEventArgs e)
        {
            MoveShape(10, 0);
        }

        private void MoveUpButton_Click(object sender, RoutedEventArgs e)
        {
            MoveShape(0, -10);
        }

        private void MoveDownButton_Click(object sender, RoutedEventArgs e)
        {
            MoveShape(0, 10);
        }

        private void MoveShape(int deltaX, int deltaY)
        {
            if (_isTriangle && _currentTriangle != null)
            {
                _currentTriangle.AddX(deltaX);
                _currentTriangle.AddY(deltaY);
                DrawTriangle(_currentTriangle);
            }
            else if (!_isTriangle && _currentRectangle != null)
            {
                _currentRectangle.AddX(deltaX);
                _currentRectangle.AddY(deltaY);
                DrawRectangle(_currentRectangle);
            }
        }
    }
}