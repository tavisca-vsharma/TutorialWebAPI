using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TutorialWebAPI.Model;

namespace TutorialWebAPI.Services
{
    public class BookServices : IBook
    {
        private List<Book> _bookList = new List<Book>();
        public BookServices()
        {
            LoadByJsonToList();
        }

        public void LoadByJsonToList()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\visharma\source\repos\TutorialWebAPI\TutorialWebAPI\Data\BookData.json"))
            {
                string json = r.ReadToEnd();
                _bookList = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }
        public void SaveToJsonFromList()
        {
            string json = JsonConvert.SerializeObject(_bookList.ToArray());
            System.IO.File.WriteAllText(@"C:\Users\visharma\source\repos\TutorialWebAPI\TutorialWebAPI\Data\BookData.json", json);
        }

        public void AddBook(Book book)
        {
            _bookList.Add(book);
            SaveToJsonFromList();
        }

        public List<Book> GetEveryBook()
        {
            return _bookList;
        }


        public Book GetBookByTitle(string name)
        {
            return _bookList.Where(b => b.title == name).FirstOrDefault();
        }

        public Book GetBookByISBN(string ISBN)
        {
            return _bookList.Where(b => b.ISBN == ISBN).FirstOrDefault();

        }

        public void UpdateBook(string name, Book book)
        {
            foreach (var item in _bookList.Where(w => w.title == name))
            {
                item.price = book.price;
                item.author = book.author;
            }
            SaveToJsonFromList();
        }
        public bool RemoveBook(string ISBN)
        {
            bool result = false;
            for (int i =0;i<_bookList.Count;i++)
            {
                if (_bookList[i].ISBN == ISBN)
                {
                    result = _bookList.Remove(i);
                }
            }
            SaveToJsonFromList();
            return result;
        }
    }
}
