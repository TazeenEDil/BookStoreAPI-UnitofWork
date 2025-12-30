using BookStoreAPI.DTOs;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Interfaces.Services;
using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookReadDto>> GetAllAsync()
        {
            var books = await _unitOfWork.Books.GetAllAsync();

            return books.Select(b => new BookReadDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Price = b.Price
            });
        }

        public async Task<BookReadDto> GetByIdAsync(int id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if (book == null) return null;

            return new BookReadDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };
        }

        public async Task CreateAsync(BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Price = dto.Price
            };

            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(int id, BookUpdateDto dto)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if (book == null) throw new Exception("Book not found");

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Price = dto.Price;

            _unitOfWork.Books.Update(book);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if (book == null) throw new Exception("Book not found");

            _unitOfWork.Books.Delete(book);
            await _unitOfWork.SaveAsync();
        }
    }
}
