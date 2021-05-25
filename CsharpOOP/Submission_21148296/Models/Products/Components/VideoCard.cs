using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
   public class VideoCard:Component
    {
        private const double COMP_MODIFIER = 1.15;

        public VideoCard(
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
