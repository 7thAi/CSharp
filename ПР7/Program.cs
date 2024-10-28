using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите инструмент:");
        Console.WriteLine("1. Гитара");
        Console.WriteLine("2. Пианино");

        string choice = Console.ReadLine();

        IPlayable instrument = null;

        switch (choice)
        {
            case "1":
                instrument = new Guitar();
                break;
            case "2":
                instrument = new Piano();
                break;
            default:
                Console.WriteLine("Неправильный выбор.");
                return;
        }

        instrument.Play();
    }
}

public interface IPlayable
{
    void Play();
}

public class Guitar : IPlayable
{
    public void Play()
    {
        Console.WriteLine("Звуки гитары.");
    }
}

public class Piano : IPlayable
{
    public void Play()
    {
        Console.WriteLine("Звуки пианино.");
    }
}