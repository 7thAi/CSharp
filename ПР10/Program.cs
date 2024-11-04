using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        UniversalCollection<int> intCollection = new UniversalCollection<int>();

        // Добавляем
        intCollection.Add(10);
        intCollection.Add(20);
        intCollection.Add(30);

        // Удаляем
        intCollection.Remove(20);

        // Выводим оставшиеся элементы
        Console.WriteLine("Оставшиеся элементы в коллекции:");
        intCollection.PrintAll();

        // Получаем элемент по индексу и выводим его на экран
        int index = 1;
        int element = intCollection.Get(index);
        Console.WriteLine($"Элемент по индексу {index}: {element}");
    }
}

public class UniversalCollection<T>
{
    private List<T> elem;

    public UniversalCollection()
    {
        elem = new List<T>();
    }

    // добавляем элемент
    public void Add(T item)
    {
        elem.Add(item);
    }

    // удаляем элемент
    public bool Remove(T item)
    {
        return elem.Remove(item);
    }

    // получаем элемент по индексу
    public T Get(int index)
    {
        return elem[index];
    }

    // получаем и выводим все элементы
    public void PrintAll()
    {
        foreach (var item in elem)
        {
            Console.WriteLine(item);
        }
    }
}