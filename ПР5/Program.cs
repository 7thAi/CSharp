using System;

namespace ПР5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VolumeCalculator calculator = new VolumeCalculator();

            // Вычисление объема шара
            double sphereRadius = 5.0;
            double sphereVolume = calculator.CalculateVolume(sphereRadius);
            Console.WriteLine($"Объем шара с радиусом {sphereRadius} равен {sphereVolume}");

            // Вычисление объема прямоугольного параллелепипеда
            double length = 4.0, width = 3.0, height = 2.0;
            double boxVolume = calculator.CalculateVolume(length, width, height);
            Console.WriteLine($"Объем прямоугольного параллелепипеда с размерами {length} x {width} x {height} равен {boxVolume}");

            // Вычисление объема цилиндра
            double cylinderRadius = 3.0, cylinderHeight = 7.0;
            double cylinderVolume = calculator.CalculateVolume(cylinderRadius, cylinderHeight);
            Console.WriteLine($"Объем цилиндра с радиусом {cylinderRadius} и высотой {cylinderHeight} равен {cylinderVolume}");

            Console.ReadLine();
        }
    }

    class VolumeCalculator
    {
        private const double Pi = Math.PI;

        // Метод для вычисления объема шара
        public double CalculateVolume(double radius)
        {
            return (4.0 / 3.0) * Pi * Math.Pow(radius, 3);
        }

        // Метод для вычисления объема прямоугольного параллелепипеда
        public double CalculateVolume(double length, double width, double height)
        {
            return length * width * height;
        }

        // Метод для вычисления объема цилиндра
        public double CalculateVolume(double radius, double height)
        {
            return Pi * Math.Pow(radius, 2) * height;
        }
    }
}
