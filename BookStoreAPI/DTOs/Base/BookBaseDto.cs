using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs.Base
{
    public abstract class BookBaseDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(150, ErrorMessage = "Title cannot exceed 150 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [MaxLength(100, ErrorMessage = "Author cannot exceed 100 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be between 0.01 and 999999.99")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "CategoryId is required")]
        public int CategoryId { get; set; }
    }
}