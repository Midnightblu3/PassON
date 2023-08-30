using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PassON.Models
{
    public class SellModel
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of your item")]
        [Display(Name = "Item name:")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a short description of your item")]
        [Display(Name = "Short Description: ")]
        [StringLength(200)]
        public string? ShortDescription { get; set; }


        [Display(Name = "Long Description: ")]
        public string? LongDescription { get; set; }

        [Required(ErrorMessage = "Please enter the price of your item")]
        [Display(Name = "Item price: ")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } = decimal.Zero;

        [Display(Name = "Item image Url: ")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Item Thumbnail image Url: ")]
        public string? ImageThumbnailUrl { get; set; }

        [Required(ErrorMessage = "Please choose if you want to promote your item")]
        [Display(Name = "Do you want to promote your item?: ")]
        public bool IsPromoted { get; set; }


        [Required(ErrorMessage = "Please specify your item's category")]
        [Display(Name = "Item category Id")]
        public int CategoryId { get; set; }


    }
}
