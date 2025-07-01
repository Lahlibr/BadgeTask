using System.ComponentModel.DataAnnotations;

namespace BadgeTask.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string PName { get; set; }

       

        [Range(0, 999999)]
        public decimal Price { get; set; }
    }
}
