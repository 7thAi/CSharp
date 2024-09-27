using System;
using System.Linq;

namespace ПР2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[] sizes = { 100, 1000, 10000 };
            Console.WriteLine("Введите целевое число для поиска: ");
            int target = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Выберите метод поиска:");
            Console.WriteLine("1. Линейный поиск");
            Console.WriteLine("2. Бинарный поиск");
            int choice = Convert.ToInt32(Console.ReadLine());

            foreach (var size in sizes)
            {
                Console.WriteLine($"\nРазмер массива: {size}\n");
                int[] array = program.Array(size);
                int? result;

                switch (choice)
                {
                    case 1:
                        result = LinearSearch(array, target);
                        break;
                    case 2:
                        result = BinarySearch(array, target);
                        break;
                    default:
                        Console.WriteLine("Ошибка, выберите метод 1 или 2!");
                        return;
                }

                if (result.HasValue)
                {
                    Console.WriteLine($"Элемент найден: {result.Value}");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Элемент не найден");
                    Console.ReadLine();
                }
            }
        }

        // Генерируем массив
        public int[] Array(int size)
        {
            Random rnd = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(-999, 999);
            }

            return array;
        }

        // Линейный поиск
        public static int? LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return array[i];
                }
            }
            return null;
        }

        // Бинарный поиск
        public static int? BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                {
                    return array[mid];
                }
                else if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return null;
        }
    }
}