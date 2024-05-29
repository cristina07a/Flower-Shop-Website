using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPAW.Models
{
    public class ProductImage
    {
        [Key] public int imageID { get; set; }
        public string? path { get; set; }

        public int? productID { get; set; }
        [ForeignKey("productID")]
        public Product? Products { get; set; }
    }
}
