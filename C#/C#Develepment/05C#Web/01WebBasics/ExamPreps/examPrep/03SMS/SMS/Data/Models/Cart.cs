using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.Models
{
    public class Cart
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public User User { get; set; }


        private ICollection<Product> Products = new List<Product>();
    }
}
