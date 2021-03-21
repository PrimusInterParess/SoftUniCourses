using System;
using System.Collections.Generic;
using System.Text;

namespace Shirt
{
    class Shirt
    {
        //public string Size;
        //public decimal Price;
        //public int Quantity;

        public string Size { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }


        public void Wash()
        {
            Console.WriteLine("T-shirt was dirty,now is washed!");
        }
    }
}
 