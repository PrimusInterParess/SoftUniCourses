using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto.JsonModels
{
    public class TicketInputModel
    {
        [Range(typeof(decimal),"1.00","100.00")]
        public decimal Price { get; set; }

        [Range(1,10)]
        public sbyte RowNumber { get; set; }

        public int PlayId { get; set; }

        /*
              *         "Price": 7.63,
             "RowNumber": -5,
             "PlayId": 4

         */
    }
}
