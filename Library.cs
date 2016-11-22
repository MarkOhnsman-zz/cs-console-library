using System;
using System.Collections.Generic;

namespace ConsoleApplication.Models
{

    public class Library
    {
        public bool InLib = true;
        public List<Book> AvailableBooks = new List<Book>();
        public List<Book> CheckedOutBooks = new List<Book>();

        public void AddBook(Book book)
        {
            AvailableBooks.Add(book);
        }

        public List<Book> GetBooks()
        {
            return AvailableBooks;
        }

        public void Checkout(int index)
        {
            CheckedOutBooks.Add(AvailableBooks[index - 1]);
            AvailableBooks.Remove(AvailableBooks[index - 1]);
        }

        public void ReturnBook()
        {
            AvailableBooks.Add(CheckedOutBooks[0]);
            CheckedOutBooks.Remove(CheckedOutBooks[0]);
        }
        public List<Book> GetCheckedout()
        {
            return CheckedOutBooks;
        }

        public void PrintMenu()
        {
            int count = 0;
            foreach (Book element in AvailableBooks)
            {
                count += 1;
                Console.WriteLine($"{count}. {element.Title}");
            }
            Console.WriteLine($"{count + 1}. Return Book");
            Console.WriteLine("Select the Book you would like to checkout by number:");
        }

        public void RequestValidate(string request)
        {
            int a = 0;
            var count = AvailableBooks.Count;
            if (!int.TryParse(request, out a))
            {
                Console.WriteLine($"Sorry, please provide a number for your request");
            }
            else if (Int32.Parse(request) > count + 1)
            {
                Console.WriteLine($"Sorry, I don't understand, please provide a number in the list");
            }
            else if (Int32.Parse(request) == count + 1)
            {
                if (GetCheckedout().Count > 0)
                {
                    Console.WriteLine($"Returning.....");
                    ReturnBook();
                    Console.WriteLine($"Book Returned!");
                }
                else
                {
                    Console.WriteLine($"Sorry, there are no books checked out. What would you like to do?");
                }
            }
            else
            {
                if (GetCheckedout().Count > 0)
                {
                    Console.WriteLine($"Sorry, you must return your current book first.");
                }
                else
                {
                    Checkout(Int32.Parse(request));
                    Console.WriteLine($"I hope you enjoy your Book!");
                }
            }
        }
    }

}