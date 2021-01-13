using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCover.Models
{
    public class OrderDetails
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string name { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string email { get; set; }


        [Required]
        [Column(TypeName = "text")]
        public string phone { get; set; }


        [Required]
        [Column(TypeName = "text")]
        public string city { get; set; }


        [Required]
        [Column(TypeName = "text")]
        public string address { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string shipping { get; set; }


        [Required]
        [Column(TypeName = "float")]
        public float price { get; set; }


        [Required]
        [Column(TypeName = "text")]
        public string shippingStatus { get; set; }

        
        [Column(TypeName = "text")]
        public string remark { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string date { get; set; }






    }
}