using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetBookByTitleAsync(string title);
    }
}
