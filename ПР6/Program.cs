using System;
using System.Collections.Generic;

class LibraryItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public LibraryItem(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
}

class Book : LibraryItem
{
    public string Genre { get; set; }

    public Book(string title, string author, int year, string genre)
        : base(title, author, year)
    {
        Genre = genre;
    }
}

class Magazine : LibraryItem
{
    public int IssueNumber { get; set; }

    public Magazine(string title, string author, int year, int issueNumber)
        : base(title, author, year)
    {
        IssueNumber = issueNumber;
    }
}

class Borrower
{
    public string Name { get; set; }
    public List<LibraryItem> BorrowedItems { get; private set; } = new List<LibraryItem>();
    public double Fine { get; private set; }

    public Borrower(string name)
    {
        Name = name;
    }

    public void BorrowItem(LibraryItem item)
    {
        BorrowedItems.Add(item);
        Console.WriteLine($"{Name} взял(а) '{item.Title}'.");
    }

    public void ReturnItem(LibraryItem item, bool isLate)
    {
        if (BorrowedItems.Remove(item))
        {
            Console.WriteLine($"{Name} вернул(а) '{item.Title}'.");
            if (isLate)
            {
                Fine += 5.0; // Штраф за просрочку
                Console.WriteLine($"Штраф за просрочку: 5.0");
            }
        }
        else
        {
            Console.WriteLine($"{Name} не взял(а) '{item.Title}'.");
        }
    }

    public void CalculateFine()
    {
        Console.WriteLine($"Общий штраф {Name}: {Fine}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var book1 = new Book("1984", "Джордж Оруэлл", 1949, "Фантастика");
        var book2 = new Book("Война и мир", "Лев Толстой", 1869, "Роман");
        var magazine1 = new Magazine("National Geographic", "Разные", 2023, 1);

        var borrower = new Borrower("Иван");

        borrower.BorrowItem(book1);
        borrower.BorrowItem(magazine1);

        borrower.ReturnItem(book1, true);

        borrower.ReturnItem(magazine1, false);

        borrower.CalculateFine();

        // Доп
        Console.WriteLine();
        Console.WriteLine("Введите количество книг для добавления в систему:");
        int numberOfBooks = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfBooks; i++)
        {
            Console.WriteLine($"Введите данные для книги {i + 1}:");
            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Автор: ");
            string author = Console.ReadLine();
            Console.Write("Жанр: ");
            string genre = Console.ReadLine();
            Console.Write("Год издания: ");
            int year = int.Parse(Console.ReadLine());

            var newBook = new Book(title, author, year, genre);
            Console.WriteLine($"Книга '{newBook.Title}' добавлена в систему.");
        }

        Console.ReadLine();
    }
}
