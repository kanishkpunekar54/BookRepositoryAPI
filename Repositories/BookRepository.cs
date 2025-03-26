using BookRepositoryAPI.Models;

namespace BookRepositoryAPI.Repositories
{
    public class BookRepository
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;
        public IEnumerable<Book> GetAllBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
        }
        public bool UpdateBook(int id, Book updatedBook)
        {
            var index = _books.FindIndex(b => b.Id == id);
            if (index == -1)
            {
                return false;
            }
            updatedBook.Id = id;
            _books[index] = updatedBook;
            return true;
        }
        public bool DeleteBook(int id) => _books.RemoveAll(b => b.Id == id) > 0;
    }
}
