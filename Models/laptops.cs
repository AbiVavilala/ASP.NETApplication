using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptops.Models
{
    public class Laptops
    {
        [Key]
        [MaxLength(50)] // Adjust the maximum length as needed
        public string LaptopName { get; set; }

        public int Username { get; set; }

        [MaxLength(100)] // Adjust the maximum length as needed
        public string Location { get; set; }

        [MaxLength(50)] // Adjust the maximum length as needed
        public string Status { get; set; }


         
    }
}