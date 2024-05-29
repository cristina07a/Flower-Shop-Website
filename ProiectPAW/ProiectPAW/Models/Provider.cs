using System.ComponentModel.DataAnnotations;

namespace ProiectPAW.Models
{
    public class Provider
    {
        [Key] public int providerID { get; set; }
        public string? name { get; set; }

        public ICollection<Product>? Products { get; set; }

    }
}
