using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double fuelAvailable = 65;
        private const double fuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, fuelAvailable, fuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            double result = this.HorsePower * 0.97;

            /// ????????????????????????????????????????!!!!!!!!!!!!!!!!!!!1
            this.HorsePower = Convert.ToInt32(result);
        }
    }
}
