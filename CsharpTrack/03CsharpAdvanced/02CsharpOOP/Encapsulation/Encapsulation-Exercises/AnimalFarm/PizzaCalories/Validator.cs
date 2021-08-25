using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class Validator
    {
        public static void ThrowIfFlourTypeIsInvalid(string atype, string massege)
        {
            string type = atype.ToLower();

            if (type != "white" &&
                type != "wholegrain" &&
                type != "crispy" &&
                type != "chewy" &&
                type != "homemade")
            {
                throw new ArgumentException(massege);
            }

        }

        public static void ThrowIfWeightIsOutSideBounds(int min, int max, double value, string massage)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(massage);
            }

        }

        public static void TrowIfToppingIsInvalid(string avalue, string massage)
        {
            string value = avalue.ToLower();

            if (value != "meat" &&
                value != "veggies" &&
                value != "cheese" &&
                value != "sauce")
            {
                throw new ArgumentException(massage);
            }
        }

        public static void ThrowIfPizzaNameIsInvalid(int min, int max, string avalue)
        {
            string value = avalue.ToLower();


            if (value.Length < min || value.Length > 15)
            {
                throw new ArgumentException($"Pizza name should be between {min} and {max} symbols.");
            }
        }


    }
}
