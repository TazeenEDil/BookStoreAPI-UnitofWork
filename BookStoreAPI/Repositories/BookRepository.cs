using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Data;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context) { }

        public async Task<Book> GetBookByTitleAsync(string title)
        {
            return await _context.Books
                .FirstOrDefaultAsync(b => b.Title == title);
        }
    }
}
