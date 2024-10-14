using System;

namespace ПР4
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Shape();

            // Вычисление площади круга
            double radius = 5.0;
            double circleArea = shape.CalculateArea(radius);
            Console.WriteLine($"Площадь круга с радиусом {radius} равна: {circleArea}");

            // Вычисление площади прямоугольника
            double width = 4.0;
            double height = 6.0;
            double rectangleArea = shape.CalculateArea(width, height);
            Console.WriteLine($"Площадь прямоугольника с шириной {width} и высотой {height} равна: {rectangleArea}");

            // Вычисление площади прямоугольного треугольника
            double baseLength = 3.0;
            double triangleHeight = 4.0;
            double rightTriangleArea = shape.CalculateArea(baseLength, triangleHeight, true);
            Console.WriteLine($"Площадь прямоугольного треугольника с основанием {baseLength} и высотой {triangleHeight} равна: {rightTriangleArea}");

            // Вычисление площади не прямоугольного треугольника (например, равностороннего)
            double nonRightTriangleBase = 5.0;
            double nonRightTriangleHeight = 5.0;
            double nonRightTriangleArea = shape.CalculateArea(nonRightTriangleBase, nonRightTriangleHeight, false);
            Console.WriteLine($"Площадь не прямоугольного треугольника с основанием {nonRightTriangleBase} и высотой {nonRightTriangleHeight} равна: {nonRightTriangleArea}");
        }

        public class Shape
        {
            // Метод для вычисления площади круга
            public double CalculateArea(double radius)
            {
                return Math.PI * radius * radius;
            }

            // Метод для вычисления площади прямоугольника
            public double CalculateArea(double width, double height)
            {
                return width * height;
            }

            // Метод для вычисления площади треугольника
            public double CalculateArea(double baseLength, double height, bool isRightTriangle)
            {
                if (isRightTriangle)
                {
                    return 0.5 * baseLength * height;
                }
                else
                {
                    // Используем формулу Герона
                    double s = (baseLength + height + Math.Sqrt(baseLength * baseLength + height * height)) / 2;
                    return Math.Sqrt(s * (s - baseLength) * (s - height) * (s - Math.Sqrt(baseLength * baseLength + height * height)));
                }
            }
        }
    }
}
