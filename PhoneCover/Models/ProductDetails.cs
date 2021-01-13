using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCover.Models
{
    public class ProductDetails
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string name { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string category { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string type { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public float price { get; set; }

        [Column(TypeName = "text")]
        public string  description { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string photoUrl { get; set; }
    }
}
