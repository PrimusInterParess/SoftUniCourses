using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase.Data.Models
{
  public  class Store
    {

        public Store()
        {
            this.Sales = new List<Sale>();
        }

        public int 	StoreId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        public ICollection<Sale> Sales { get; set; }
    }
}
