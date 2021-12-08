using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {

        public Product()
        {
            this.Sales = new List<Sale>();
        }

        public int ProductId { get; set; }


        [Required]
        [MaxLength(50)]
        [DefaultValue("Dani E Golem")]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
