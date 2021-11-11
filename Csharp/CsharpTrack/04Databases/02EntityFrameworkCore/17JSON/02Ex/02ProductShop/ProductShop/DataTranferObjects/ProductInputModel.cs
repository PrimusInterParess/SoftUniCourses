using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DataTranferObjects
{
    public class ProductInputModel
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? SellerId { get; set; }
        public int? BuyerId { get; set; }


        /*
         *  "Name": "Care One Hemorrhoidal",
            "Price": 932.18,
             "SellerId": 25,
             "BuyerId": 24
         */
    }
}
