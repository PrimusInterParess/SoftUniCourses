﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        private const double COMP_MODIFIER = 1.20;

        public SolidStateDrive(
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