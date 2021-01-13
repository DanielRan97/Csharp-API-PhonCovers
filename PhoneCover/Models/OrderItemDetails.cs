using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCover.Models
{
    public class OrderItemDetails
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int orderId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int productId { get; set; }

        [Column(TypeName = "float")]
        public float? productPrice { get; set; }

        [Column(TypeName = "float")]
        public float? quantity { get; set; }
    }
}