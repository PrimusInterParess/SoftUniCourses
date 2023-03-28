using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class SaleInputModel
    {

        public int CarId { get; set; }

        public int CustomerId { get; set; }
            
        public decimal Discount { get; set; }

        /*
         * "carId": 75,
           "customerId": 22,
           "discount": 30
         */

    }
}
