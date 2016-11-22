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
                int count = 0;
                foreach (Book element in books)
                {
                    count += 1;
                    Console.WriteLine($"{count}. {element.Title}");
                }
                Console.WriteLine($"{count + 1}. Return Book");
                Console.WriteLine("Select the Book you would like to checkout by number:");
                var request = GetUserInput(library);


                int a = 0;
                while (!int.TryParse(request, out a))
                {
                    Console.WriteLine($"Sorry, please provide a number for your request");
                    request = GetUserInput(library);
                }
                if (Int32.Parse(request) > count+1)
                    {
                    Console.WriteLine($"Sorry, I don't understand, please provide a number in the list");
                    request = GetUserInput(library);
                    }
                else if (Int32.Parse(request) == count + 1)
                    {
                        if (library.GetCheckedout().Count > 0)
                            {   
                                Console.WriteLine($"Returning.....");
                                library.ReturnBook();
                                Console.WriteLine($"Book Returned!");
                            }
                        else
                            {
                                Console.WriteLine($"Sorry, there are no books checked out. What would you like to do?");
                                request = GetUserInput(library);
                            }
                    }
                else
                    {
                        if (library.GetCheckedout().Count > 0){
                            Console.WriteLine($"Sorry, you must return your current book first.");
                            request = GetUserInput(library);
                        }else{
                            library.Checkout(Int32.Parse(request));
                            Console.WriteLine($"I hope you enjoy your Book!");
                        }
                    }
            }
        }
    }
}
