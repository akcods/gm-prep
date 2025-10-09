using api.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _booksService;
    public BookController(IBookService bookService)
    {
        _booksService = bookService;
    }

    [HttpPost]
    public async Task<ActionResult<Book>> AddBook([FromBody] Book book)
    {
        return await _booksService.AddBookAsync(book);
    }
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAllBooks()
    {
        return await _booksService.GetAllBooksAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBookById(string id)
    {
        try
        {
            return await _booksService.GetBookByIdAsync(id);
        }
        catch (Exception ex)
        {
            return NotFound($"Book not found, {ex.Message}");
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult<Book>> UpdateBook(Book book)
    {
        try
        {
            return await _booksService.UpdateBookAsync(book);
        }
        catch (Exception ex)
        {
            return NotFound($"Book not found, {ex.Message}");
        }
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteBook(string id)
    {
        try
        {
            await _booksService.DeleteBookAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound($"Book not found, {ex.Message}");
        }
    }


}