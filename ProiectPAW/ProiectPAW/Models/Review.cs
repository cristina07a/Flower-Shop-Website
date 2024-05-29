using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPAW.Models
{
    public class Review
    {
        [Key] public int reviewID { get; set; }
        public string? textContent { get; set; }
        public int? numberOfStars { get; set; }
        public int? productID { get; set; }

        [ForeignKey("productID")]
        public Product? Products { get; set; }
    }
}
