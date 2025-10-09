using api.Model;
using MongoDB.Bson;

public interface IBookService
{
    Task<Book> GetBookByIdAsync(string id);
    Task<List<Book>> GetAllBooksAsync();
    Task<Book> UpdateBookAsync(Book book);
    Task<Book> AddBookAsync(Book book);
    Task<bool> DeleteBookAsync(string id);
}