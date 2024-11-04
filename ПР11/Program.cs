using System;
using System.Text.RegularExpressions;

namespace ПР11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            isString();
            isData();
            isMail();
            isNUMBER();
            isURL();
            isCapitalLetter();
            isNumFormat();
            isHeadword();
            isFruit();
            isIP();
        }

        // Task1
        static void isString()
        {
            string s = "Ястрочка123";
            string sPattern = "^[a-zA-Z0-9]+$";
            bool isValidS = Regex.IsMatch(s, sPattern);
            Console.WriteLine($"Is valid s: {isValidS}");
        }

        // Task2
        static void isData()
        {
            string s = "Даты: 12.05.2023, 01.01.2024.";
            string sPattern = @"bd{2}.d{2}.d{4}b";
            MatchCollection matches = Regex.Matches(s, sPattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Found date: {match.Value}");
            }
        }

        // Task3
        static void isMail()
        {
            string s = "example@example.com";
            string sPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$";
            bool isValidEmail = Regex.IsMatch(s, sPattern);
            Console.WriteLine($"Is valid email: {isValidEmail}");
        }

        // Task4
        static void isNUMBER()
        {
            string s = "У меня 2 яблока и 3 апельсина.";
            string sPattern = @"d+";
            string result = Regex.Replace(s, sPattern, "NUMBER");
            Console.WriteLine($"Result: {result}");
        }

        // Task5
        static void isURL()
        {
            string s = "Посетите наш сайт по адресу https://example.com или www.example.org.";
            string sPattern = @"bhttps?://[^s]+|www.[^s]+b";
            MatchCollection matches = Regex.Matches(s, sPattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Found URL: {match.Value}");
            }
        }

        // Task6
        static void isCapitalLetter()
        {
            string s = "пример строки";
            string sPattern = "[A-Z]";
            bool hasUpperCase = Regex.IsMatch(s, sPattern);
            Console.WriteLine($"Contains uppercase letter: {hasUpperCase}");
        }

        // Task7
        static void isNumFormat()
        {
            string s = "Мой номер телефона +123-456-7890123.";
            string sPattern = @"\+\d{3}-\d{3}-\d{7}";
            MatchCollection matches = Regex.Matches(s, sPattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Found phone number: {match.Value}");
            }
        }

        // Task 8
        static void isHeadword()
        {
            string s = "это пример строки с Заглавной буквой.";
            string sPattern = @"b[A-Z][a-zA-Z]*b";
            bool hasCapitalWord = Regex.IsMatch(s, sPattern);
            Console.WriteLine($"Contains capitalized word: {hasCapitalWord}");
        }

        // Task9
        static void isFruit()
        {
            string s = "I like apple and orange.";
            string sPattern = @"b(apple|orange)b";
            string result = Regex.Replace(s, sPattern, "fruit");
            Console.WriteLine($"Result: {result}");
        }

        //Task 10
        static void isIP()
        {
            string s = "192.168.1.1";
            string sPattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?).(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?).(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?).(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            bool isValidIP = Regex.IsMatch(s, sPattern);
            Console.WriteLine($"Is valid IP address: {isValidIP}");
        }
    }
}