using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Navigation
        public ICollection<Book> Books { get; set; }
    }
}
