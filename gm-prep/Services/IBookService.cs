using api.Model;
using MongoDB.Bson;

public interface IBookService
{
    Task<Book> GetBookByIdAsync(ObjectId id);
    Task<List<Book>> GetAllBooksAsync();
    Task<Book> UpdateBookAsync(Book book);
    Task<Book> AddBookAsync(Book book);
    Task<bool> DeleteBookAsync(Book book);
}