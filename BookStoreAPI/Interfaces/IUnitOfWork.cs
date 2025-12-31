namespace BookStoreAPI.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }   
        Task<int> SaveAsync();
    }
}
