using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCover.Models
{
    public class CategoriesDetails
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string category { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string type { get; set; }
    }
}