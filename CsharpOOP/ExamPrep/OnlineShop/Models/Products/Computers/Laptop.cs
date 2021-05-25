using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    class Laptop:Computer
    {
        private const double OVERALL_PERFOR = 10;

        public Laptop(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, OVERALL_PERFOR)
        {
        }

       
    }
}
