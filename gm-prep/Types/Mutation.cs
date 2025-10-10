using api.Model;
namespace api.Types;
public class Mutation
{
    public async Task<Book> AddBook(Book book, [Service] IBookService bookService)
    {
        return await bookService.AddBookAsync(book);
    }
    public async Task<Book> UpdateBook(Book book, [Service] IBookService bookService)
    {
        return await bookService.UpdateBookAsync(book);
    }
    public async Task<bool> DeleteBook(string id, [Service] IBookService bookService)
    {
        return await bookService.DeleteBookAsync(id);
    }
}