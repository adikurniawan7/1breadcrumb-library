using OneBreadcrumbLibrary.Models;

namespace OneBreadcrumbLibrary.Services
{
    public interface IBookService
    {
        public Task<GetAllBooksResponse> GetAllBooks();
        public Task<BookResponse> GetBookById(int id);
        public Task<Response> AddBook(Book book);
        public Task<Response> UpdateBook(Book book);
        public Task<Response> DeleteBook(int id);
    }
}
