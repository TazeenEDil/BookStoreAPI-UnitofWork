namespace BookStoreAPI.DTOs.Base
{
    public abstract class BookBaseDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }
}
