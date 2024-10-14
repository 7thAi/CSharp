using System;

namespace ПР3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("1234", "Гоголь", 1900);
            Book book2 = new Book("абвгд", "Пушкин", 1800);
            Book book3 = new Book();

            Student student1 = new Student("Иван", 20, "Информатика");
            Student student2 = new Student("Мария", 22, "Экономика");
            Student student3 = new Student();

            Car car1 = new Car("Toyota", "Camry", 2020);
            Car car2 = new Car("Honda", "Civic", 2019);
            Car car3 = new Car();

            // Отображение информации о книгах
            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();

            // Вызов методов для каждого студента
            student1.DisplayInfo();
            student1.Study();

            student2.DisplayInfo();
            student2.Study();

            student3.DisplayInfo();
            student3.Study();

            // Вызов методов для каждого автомобиля
            car1.DisplayInfo();
            car1.StartEngine();

            car2.DisplayInfo();
            car2.StartEngine();

            car3.DisplayInfo();
            car3.StartEngine();
        }

        public class Book
        {
            // Поля
            private string title;
            private string author;
            private int yearPublished;

            // Свойства
            public string Title
            {
                get { return title; }
                set { title = Title; }
            }

            public string Author
            {
                get { return author; }
                set { author = Author; }
            }

            public int YearPublished
            {
                get { return yearPublished; }
                set { yearPublished = YearPublished; }
            }

            // Конструктор без параметров
            public Book()
            {
                title = "Неизвестно";
                author = "Неизвестно";
                yearPublished = 0;
            }

            // Конструктор с параметрами
            public Book(string title, string author, int yearPublished)
            {
                this.title = title;
                this.author = author;
                this.yearPublished = yearPublished;
            }

            // Метод для отображения информации о книге
            public void DisplayInfo()
            {
                Console.WriteLine($"Название: {Title}");
                Console.WriteLine($"Автор: {Author}");
                Console.WriteLine($"Год публикации: {YearPublished}");
                Console.WriteLine();
            }
        }

        public class Student
        {
            // Поля
            private string name;
            private int age;
            private string major;

            // Свойства
            public string Name
            {
                get { return name; }
                set { name = Name; }
            }

            public int Age
            {
                get { return age; }
                set { age = Age; }
            }

            public string Major
            {
                get { return major; }
                set { major = Major; }
            }

            // Конструктор без параметров
            public Student()
            {
                name = "Неизвестно";
                age = 0;
                major = "Неизвестно";
            }

            // Конструктор с параметрами
            public Student(string name, int age, string major)
            {
                this.name = name;
                this.age = age;
                this.major = major;
            }

            // Метод, который выводит сообщение о том, что студент учится
            public void Study()
            {
                Console.WriteLine($"{Name} учится.");
                Console.WriteLine();
            }

            // Метод для отображения информации о студенте
            public void DisplayInfo()
            {
                Console.WriteLine($"Имя: {Name}");
                Console.WriteLine($"Возраст: {Age}");
                Console.WriteLine($"Специальность: {Major}");
                Console.WriteLine();
            }
        }

        public class Car
        {
            // Поля
            private string make;
            private string model;
            private int year;

            // Свойства
            public string Make
            {
                get { return make; }
                set { make = Make; }
            }

            public string Model
            {
                get { return model; }
                set { model = Model; }
            }

            public int Year
            {
                get { return year; }
                set { year = Year; }
            }

            // Конструктор без параметров
            public Car()
            {
                make = "Неизвестно";
                model = "Неизвестно";
                year = 0;
            }

            // Конструктор с параметрами
            public Car(string make, string model, int year)
            {
                this.make = make;
                this.model = model;
                this.year = year;
            }

            // Метод для запуска двигателя
            public void StartEngine()
            {
                Console.WriteLine($"Двигатель автомобиля {Make} {Model} запущен.");
                Console.WriteLine();
            }

            // Метод для отображения информации о автомобиле
            public void DisplayInfo()
            {
                Console.WriteLine($"Марка: {Make}");
                Console.WriteLine($"Модель: {Model}");
                Console.WriteLine($"Год выпуска: {Year}");
                Console.WriteLine();
            }
        }
    }
}