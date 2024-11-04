using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student(1, "Антон", 20, 3.5),
            new Student(2, "Борис>", 22, 3.8),
            new Student(3, "Валерия", 21, 2.9),
            new Student(4, "Григорий", 23, 3.6)
        };

        Console.WriteLine("Информация о студентах:");
        DisplayStudents(students);

        // сортировка по имени
        students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));
        Console.WriteLine("\nСтуденты отсортированы по имени:");
        DisplayStudents(students);

        // сортировка по возрасту
        students.Sort((s1, s2) => s1.Age.CompareTo(s2.Age));
        Console.WriteLine("\nСтуденты отсортированы по возрасту:");
        DisplayStudents(students);

        // сортировка по среднему баллу
        students.Sort((s1, s2) => s1.GPA.CompareTo(s2.GPA));
        Console.WriteLine("\nСтуденты отсортированы по среднему баллу:");
        DisplayStudents(students);
    }

    static void DisplayStudents(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, GPA: {student.GPA}");
        }
    }
}

struct Student
{
    public int Id;
    public string Name;
    public int Age;
    public double GPA;

    public Student(int id, string name, int age, double gpa)
    {
        Id = id;
        Name = name;
        Age = age;
        GPA = gpa;
    }
}