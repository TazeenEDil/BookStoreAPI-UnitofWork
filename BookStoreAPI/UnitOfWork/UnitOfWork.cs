using BookStoreAPI.Data;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Repositories;

namespace BookStoreAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IBookRepository Books { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Books = new BookRepository(context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
