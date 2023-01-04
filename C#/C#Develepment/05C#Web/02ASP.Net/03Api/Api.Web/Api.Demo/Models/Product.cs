using System.ComponentModel.DataAnnotations;

namespace Api.Demo.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ActiveFrom { get; set; }

        public double Price { get; set; }
    }
}
