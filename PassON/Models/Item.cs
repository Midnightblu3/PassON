using System.ComponentModel;

namespace PassON.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? ShortDescription { get; set; }

        public string? LongDescription { get; set; }

        public decimal Price { get; set; } = decimal.Zero;

        public string? ImageUrl { get; set; }   

        public string? ImageThumbnailUrl { get; set; }

        public bool IsPromoted { get; set; }

        public bool InStock { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = default!;
    }
}
