using BookRepositoryAPI.Models;
using BookRepositoryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookRepositoryAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookRepository _repository;
        public BookController(BookRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<Book> Get() => _repository.GetAllBooks();

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _repository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public ActionResult<Book> Add(Book book)
        {
            _repository.AddBook(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            return _repository.UpdateBook(id, book) ? NoContent() : NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _repository.DeleteBook(id) ? NoContent() : NotFound();
        }
    }
}
