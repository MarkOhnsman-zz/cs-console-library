using System;
using ConsoleApplication.Models;

namespace ConsoleApplication
{
    public class Program
    {

        public static string GetUserInput(Library library)
        {
            var userInput = Console.ReadLine();
            if (userInput == "exit")
            {
                library.InLib = false;
            }
            return userInput;
        }
        public static void Main(string[] args)
        {
            var library = new Library();
            var book = new Book("HeadFirst with C#", "Andrew Stellman");
            library.AddBook(book);
            book = new Book("C# Game Programming: For Serious Game Creation", "Daniel Schuller");
            library.AddBook(book);
            book = new Book("Pro C# 5.0 and the .NET 4.5 Framework", "Andrew Troelsen");
            library.AddBook(book);
            book = new Book("Harry Potter and the Sorcers Stone", "JK Rowling");
            library.AddBook(book);
            var books = library.GetBooks();

            while (library.InLib)
            {
                
                library.PrintMenu();
                var request = GetUserInput(library);
                Console.Clear();
                library.RequestValidate(request);
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Goodbye!");
        }
    }
}
