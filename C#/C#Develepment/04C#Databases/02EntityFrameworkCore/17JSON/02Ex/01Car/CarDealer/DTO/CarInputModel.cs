using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Models;

namespace CarDealer.DTO
{
    public class CarInputModel
    {
        public CarInputModel()
        {
            this.PartsId = new List<int>();
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int TravelledDistance { get; set; }

        public List<int> PartsId { get; set; }


        /*
         *    "make": "Opel",
              "model": "Omega",
              "travelledDistance": 176664996,
              "partsId": [
                38,
                102,
                23,
                116,
                46,
                68,
                88,
                104,
                71,
                32,
                114
              ]
         */
    }
}
