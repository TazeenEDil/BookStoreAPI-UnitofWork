using BookStoreAPI.DTOs;

namespace BookStoreAPI.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookReadDto>> GetAllAsync();
        Task<BookReadDto> GetByIdAsync(int id);
        Task CreateAsync(BookCreateDto dto);
        Task UpdateAsync(int id, BookUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
