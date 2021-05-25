using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class Motherboard : Component
    {
        private const double COMP_MODIFIER = 1.25;

        public Motherboard(
            int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance,
            double generation)
            : base(id, manufacturer, model, price, overallPerformance, generation, COMP_MODIFIER)
        {
        }
    }
}
