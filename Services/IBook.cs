using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialWebAPI.Model;

namespace TutorialWebAPI.Services
{
    interface IBook
    {
        List<Book> GetEveryBook();
        void AddBook(Book book);
        void UpdateBook(string name, Book book);
        Book GetBookByISBN(string ISBN);
        Book GetBookByTitle(string name);
        bool RemoveBook(string ISBN);
    }
}
