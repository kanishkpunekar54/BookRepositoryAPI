using BookRepositoryAPI.Models;

namespace BookRepositoryAPI.Repositories
{
    public class BookRepository
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;

        public virtual IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public virtual Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public virtual void AddBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
        }

        public virtual bool UpdateBook(int id, Book updatedBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return false;
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Year = updatedBook.Year;
            book.Publisher = updatedBook.Publisher;
            book.Price = updatedBook.Price;

            return true;
        }

        public virtual bool DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return false;
            }

            _books.Remove(book);
            return true;
        }
    }

}
