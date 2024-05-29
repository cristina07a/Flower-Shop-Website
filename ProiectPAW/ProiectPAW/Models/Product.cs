using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPAW.Models
{
    public class Product
    {
        [Key] public int productID { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public int? price { get; set; }
        public int?  availableStock { get; set; }
        public int? categoryID { get; set; }

        [ForeignKey("categoryID")]
        public Category? Categories { get; set; }

        public int? providerID { get; set; }
        [ForeignKey("providerID")]
        public Provider? Providers { get; set; }

        public ICollection<OrderProduct>? OrderProduct { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
        public ICollection<Review>? Reviews { get; set; }


    }
}