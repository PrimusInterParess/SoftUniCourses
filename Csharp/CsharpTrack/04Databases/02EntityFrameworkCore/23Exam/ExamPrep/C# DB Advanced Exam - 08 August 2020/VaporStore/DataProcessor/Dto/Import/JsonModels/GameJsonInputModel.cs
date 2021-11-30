using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import.JsonModels
{
    public class GameJsonInputModel
    {

        public GameJsonInputModel()
        {
            this.Tags = new List<string>();
        }
        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), GlobalConstants.Min_Price_Range, GlobalConstants.Max_Price_Range)]
        public decimal Price { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ReleaseDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Developer { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Genre { get; set; }

        public List<string> Tags { get; set; }




        /*
         * "Name": "Dota 2",
		"Price": 0,
		"ReleaseDate": "2013-07-09",
		"Developer": "Valve",
		"Genre": "Action",
		"Tags": [
			"Multi-player",
			"Co-op",
			"Steam Trading Cards",
			"Steam Workshop",
			"SteamVR Collectibles",
			"In-App Purchases",
			"Valve Anti-Cheat enabled"
		]
         */


        /*
                 *	"Price": 0,
	        	"ReleaseDate": "2013-07-09",
	        	"Developer": "Valid Dev",
	        	"Genre": "Valid Genre",
	        	"Tags": [
	        		"Valid Tag"
	        	]
         *
         */
    }
}
