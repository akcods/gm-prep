using api.Model;
namespace api.Types;

public class Query
{
    private readonly IBookService _bookService;
    public Query(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        return await _bookService.GetAllBooksAsync();
    }
}