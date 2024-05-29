using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ProiectPAW.Models
{
    public class Order
    {
        [Key] public int orderID { get; set; }
        public DateTime? dateOfPlacement { get; set; }
        public string? status { get; set; }
        public string? mesaj { get; set; }

        public int? telefon { get; set; }
        public string? adresa { get; set; }
        public double? TotalPrice { get; set; }

        public ICollection<OrderProduct>? OrderProducts { get; set; }

        public string? userID { get; set; }
        [ForeignKey("userID")]
        public IdentityUser? User { get; set; }

    }
}
