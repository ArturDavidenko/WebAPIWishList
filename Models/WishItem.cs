using System.ComponentModel.DataAnnotations;

namespace WebAPIWishList.Models
{
    public class WishItem
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
