namespace BookStoreAPI.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        Task<int> SaveAsync();
    }
}
