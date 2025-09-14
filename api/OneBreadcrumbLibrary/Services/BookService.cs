using OneBreadcrumbLibrary.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OneBreadcrumbLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly string filePath = "books.json";

        public BookService()
        {
        }

        private List<Book> LoadBooks()
        {
            if (!File.Exists(filePath))
            {
                var books = new List<Book>();
                SaveBooks(books);
                return books;
            }

            var json = File.ReadAllText(filePath);
            var bookList = JsonSerializer.Deserialize<BookList>(json) ?? new BookList();
            return bookList?.Books ?? new List<Book>();
        }

        private void SaveBooks(List<Book> books)
        {
            var wrapper = new BookListWrapper { Books = books };
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(filePath, JsonSerializer.Serialize(wrapper, options));
        }

        public Task<BookResponse> GetBookById(int id)
        {
            var books = LoadBooks();
            var book = books.Where(b => b.Id == id).FirstOrDefault();
            return Task.FromResult(
                new BookResponse
                {
                    Book = book,
                    Status = true
                });
        }

        public Task<Response> AddBook(Book book)
        {
            var books = LoadBooks();

            if (books.Where(b => b.Isbn == book.Isbn).Any()) return Task.FromResult(
                new Response
                {
                    Status = false,
                    ErrorMessage = "Not Found"
                });

            book.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            books.Add(book);
            SaveBooks(books);
            return Task.FromResult(new Response{ Status = true });
        }

        public Task<Response> UpdateBook(Book book)
        {
            var books = LoadBooks();

            var index = books.FindIndex(b => b.Id == book.Id);
            if (index == -1) return Task.FromResult(
                new Response
                {
                    Status = false,
                    ErrorMessage = "Not Found"
                });

            books[index] = book;
            SaveBooks(books);
            return Task.FromResult(new Response { Status = true });
        }

        public Task<Response> DeleteBook(int id)
        {
            var books = LoadBooks();
            var book = books.Where(b => b.Id == id).FirstOrDefault();
            if (book == null) return Task.FromResult(
                new Response
                {
                    Status = false,
                    ErrorMessage = "Not Found"
                });

            books.Remove(book);
            SaveBooks(books);
            return Task.FromResult(new Response { Status = true });
        }

        private class BookListWrapper
        {
            [JsonPropertyName("books")]
            public List<Book>? Books { get; set; }
        }

        public Task<GetAllBooksResponse> GetAllBooks()
        {
            var result = new GetAllBooksResponse();
            result.Books = LoadBooks();
            result.Status = true;
            return Task.FromResult(result);
        }

    }
}
