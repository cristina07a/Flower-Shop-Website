using System.ComponentModel.DataAnnotations;

namespace ProiectPAW.Models
{
    public class Category
    {
        [Key] public int categoryID { get; set; }
        public string? name { get; set; }

        public ICollection<Product>? Products { get; set; }

    }
}
