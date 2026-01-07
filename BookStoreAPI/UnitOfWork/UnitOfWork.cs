using BookStoreAPI.Data;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Repositories;


namespace BookStoreAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IBookRepository Books { get; }
        public ICategoryRepository Categories { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Books = new BookRepository(context);
            Categories = new CategoryRepository(context);
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
            => _context.Dispose();
    }
}
