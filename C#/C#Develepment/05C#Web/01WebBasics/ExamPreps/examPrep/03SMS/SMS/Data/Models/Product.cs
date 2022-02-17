using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Data.Models;

namespace SMS.Data.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string  Name { get; set; }

        public decimal Price { get; set; }

        public string CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }

        

    }
}
