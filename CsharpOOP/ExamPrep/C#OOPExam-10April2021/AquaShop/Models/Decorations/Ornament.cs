using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
   public class Ornament:Decoration
   {
       private const decimal price = 5;
       private const int comfort = 1;

        public Ornament()
            : base(comfort, price)
        {
        }
    }
}
