using System;
using System.Diagnostics;

namespace ПР1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = { 1000, 10000, 100000 };
            int numRuns = 5;
            Program program = new Program();
            QSort qSort = new QSort();
            MSort mSort = new MSort();
            ShSort shSort = new ShSort();

            foreach (var size in sizes)
            {
                Console.WriteLine($"\nРазмер массива: {size}\n");

                // Запуск сортировки
                for (int i = 0; i < numRuns; i++)
                {
                    // Создаем массив и клонируем его для каждой из сортировок
                    int[] array = program.Array(size);
                    var bubble = program.Bubble((int[])array.Clone());
                    var insert = program.Insert((int[])array.Clone());
                    var choice = program.Choice((int[])array.Clone());
                    var quickSort = qSort.QuickSort((int[])array.Clone());
                    var mergeSort = mSort.MergeSort((int[])array.Clone());
                    var shakeSort = shSort.ShakeSort((int[])array.Clone());

                    // Выводим результат для текущего запуска
                    Console.WriteLine($"Запуск {i + 1}:");

                    // Пузырьковая сортировка
                    Console.WriteLine("Пузырьковая сортировка:");
                    Console.WriteLine($"Время сортировки: {bubble.Item2} мс");
                    Console.WriteLine($"Количество перестановок: {bubble.Item3}");

                    // Сортировка вставкой
                    Console.WriteLine("Сортировка вставкой:");
                    Console.WriteLine($"Время сортировки: {insert.Item2} мс");
                    Console.WriteLine($"Количество перестановок: {insert.Item3}");

                    // Сортировка выбором
                    Console.WriteLine("Сортировка выбором:");
                    Console.WriteLine($"Время сортировки: {choice.Item2} мс");
                    Console.WriteLine($"Количество перестановок: {choice.Item3}");

                    // Быстрая сортировка
                    Console.WriteLine("Быстрая сортировка:");
                    Console.WriteLine($"Время сортировки: {quickSort.Item2} мс");
                    Console.WriteLine($"Количество перестановок: {quickSort.Item3}");

                    // Сортировка слиянием
                    Console.WriteLine("Сортировка слиянием:");
                    Console.WriteLine($"Время сортировки: {mergeSort.Item2} мс");
                    Console.WriteLine($"Количество перестановок: {mergeSort.Item3}");

                    // Шейкерная сортировка
                    Console.WriteLine("Шейкерная сортировка:");
                    Console.WriteLine($"Время сортировки: {shakeSort.Item2} мс");
                    Console.WriteLine($"Количество перестановок: {shakeSort.Item3}");

                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }

        // Генерируем массив
        public int[] Array(int size)
        {
            Random rnd = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(-1000, 1000);
            }

            return array;
        }

        // Пузырьковая сортировка
        public (int[], long, int) Bubble(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int size = array.Length;
            int count = 0;
            int temp;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        count++;
                    }
                }
            }
            stopwatch.Stop();
            return (array, stopwatch.ElapsedMilliseconds, count);
        }

        // Сортировка вставкой
        public (int[], long, int) Insert(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int size = array.Length;
            int index; 
            int currentNumber;
            int count = 0;

            for (int i = 1; i < size; i++)
            {
                currentNumber = array[i];
                index = i;
                while (index > 0 && currentNumber < array[index - 1])
                {
                    array[index] = array[index - 1];
                    index--;
                    count++;
                }
                array[index] = currentNumber;
                count++;
            }

            stopwatch.Stop();
            return (array, stopwatch.ElapsedMilliseconds, count);
        }

        // Сортировка выбором
        public (int[], long, int) Choice(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int size = array.Length;
            int min;
            int temp;
            int count = 0;

            for (int i = 0; i < size - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;
                    count++;
                }
            }

            stopwatch.Stop();
            return (array, stopwatch.ElapsedMilliseconds, count);
        }
    }

    // Быстрая сортировка
    public class QSort
    {
        public (int[], long, int) QuickSort(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int count = 0;
            QuickSortRecursive(array, 0, array.Length - 1, ref count);

            stopwatch.Stop();
            return (array, stopwatch.ElapsedMilliseconds, count);
        }

        private void QuickSortRecursive(int[] array, int low, int high, ref int count)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high, ref count);

                QuickSortRecursive(array, low, pivotIndex - 1, ref count);
                QuickSortRecursive(array, pivotIndex + 1, high, ref count);
            }
        }

        private int Partition(int[] array, int low, int high, ref int count)
        {
            int pivot = array[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                    count++;
                }
            }

            Swap(array, i + 1, high);
            count++;
            return i + 1;
        }

        private void Swap(int[] array, int i, int j)
        {
            if (i != j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }

    // Сортировка слиянием
    public class MSort
    {
        public (int[], long, int) MergeSort(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int count = 0; 
            MergeSortRecursive(array, 0, array.Length - 1, ref count);

            stopwatch.Stop();
            return (array, stopwatch.ElapsedMilliseconds, count);
        }

        private void MergeSortRecursive(int[] array, int left, int right, ref int count)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                MergeSortRecursive(array, left, mid, ref count);
                MergeSortRecursive(array, mid + 1, right, ref count);

                Merge(array, left, mid, right, ref count);
            }
        }

        private void Merge(int[] array, int left, int mid, int right, ref int count)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
                count++;
            }

            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
                count++;
            }

            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
                count++;
            }
        }
    }

    // Шейкерная сортировка
    public class ShSort
    {
        public (int[], long, int) ShakeSort(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int size = array.Length;
            int left = 0;
            int right = size - 1;
            int temp;
            int count = 0;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        count++;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        count++;
                    }
                }
                left++;
            }

            stopwatch.Stop();
            return (array, stopwatch.ElapsedMilliseconds, count);
        }
    }
}