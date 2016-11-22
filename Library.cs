using System.Collections.Generic;

namespace ConsoleApplication.Models{

    public class Library
    {
        public bool InLib = true;
        public List<Book> AvailableBooks = new List<Book>();
        public List<Book> CheckedOutBooks = new List<Book>();

        public void AddBook(Book book){
            AvailableBooks.Add(book);
        }

        public List<Book> GetBooks(){
            return AvailableBooks;
        }

        public void Checkout(int index){
            CheckedOutBooks.Add(AvailableBooks[index-1]);
            AvailableBooks.Remove(AvailableBooks[index-1]);
        }

        public void ReturnBook(){
            AvailableBooks.Add(CheckedOutBooks[0]);
            CheckedOutBooks.Remove(CheckedOutBooks[0]);
        }
        public List<Book> GetCheckedout(){
            return CheckedOutBooks;
        }
    }

}