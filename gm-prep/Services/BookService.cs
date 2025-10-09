using api.Model;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

public class BookService: IBookService
{
    private BookDbContext _books;
    public BookService(BookDbContext books)
    {
        _books = books;
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        if (string.IsNullOrEmpty(book.Id))
            book.Id = ObjectId.GenerateNewId().ToString();

        await _books.books.AddAsync(book);
        await _books.SaveChangesAsync();
        return book;
    }

    public async Task<bool> DeleteBookAsync(string id)
    {
        var bookToDelete = await _books.books.FirstOrDefaultAsync<Book>(b => b.Id.Equals(id));
        if (bookToDelete is null)
            throw new ArgumentException("The book to delete cannot be deleted");

        _books.books.Remove(bookToDelete);
        var result = await _books.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Book> GetBookByIdAsync(string id)
    {
        var book = await _books.books.FirstOrDefaultAsync(b => b.Id.Equals(id));
        if (book is null)
            throw new ArgumentException($"Book with id: {id}, not found");
        return book;
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _books.books.OrderBy(b => b.Id).AsNoTracking().ToListAsync();
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        var bookToUpdate = await _books.books.FirstOrDefaultAsync(b => b.Id == book.Id);

        if (bookToUpdate is null) throw new ArgumentException($"Book not found");

        bookToUpdate.Title = book.Title;
        bookToUpdate.Author.Name = book.Author.Name;

        _books.books.Update(bookToUpdate);
        await _books.SaveChangesAsync();

        return bookToUpdate;
    }
}