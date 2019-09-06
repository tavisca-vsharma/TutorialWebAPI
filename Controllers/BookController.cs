using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutorialWebAPI.Model;
using TutorialWebAPI.Services;

namespace TutorialWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //List<Book> booklist = new List<Book>();
        private IBook _book;
        public BookController()
        {

        }
        public BookController(BookServices book)
        {
            _book = book;
        }
        // GET: api/Book/1
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return Ok(_book.GetEveryBook());
        }
        // POST: api/Book
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            _book.AddBook(book);
            return Ok();
        }


        // PUT: api/Book
        //put the data item and replace the data of that row
        [HttpPut("{name}")]
        public ActionResult Put(string name, Book book)
        {

            _book.UpdateBook(name, book);
            return Ok();

        }


        // GET: api/Book
        [HttpGet("{title}")]
        public ActionResult<List<Book>> Get([FromHeader]string title)
        {
            var book = _book.GetBookByTitle(title);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }

        }


        // DELETE: api/ApiWithActions/9781232122
        [HttpDelete("{ISBN}")]
        public ActionResult<string> Delete(string ISBN)
        {
            bool result = _book.RemoveBook(ISBN);
            if (result)
                return Ok("Deleted the book");
            else
                NotFound("book not found");
        }
    }
}
