using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const decimal price = 10;
        private const int comfort = 5;

        public Plant()
            : base(comfort, price)
        {
        }
    }
}
