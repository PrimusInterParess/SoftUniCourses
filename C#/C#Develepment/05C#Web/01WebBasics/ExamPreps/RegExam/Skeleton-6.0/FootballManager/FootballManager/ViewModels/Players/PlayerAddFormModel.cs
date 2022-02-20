namespace FootballManager.ViewModels.Players
{
    using System.ComponentModel.DataAnnotations;

    using static Constants.IntegerConstants;
    public class PlayerAddFormModel
    {


        [Required]
        [StringLength(PlayerNameMaxLength, MinimumLength = MinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = MinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Position { get; set; }

        [Required]
        [Range(RangeMinValue, RangeMaxValue)]
        public byte Speed { get; set; }

        [Required]
        [Range(RangeMinValue, RangeMaxValue)]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }


    //[Key]
    //public string Id { get; set; } = Guid.NewGuid().ToString();

    //[Required]
    //[MaxLength(PlayerNameMaxLength)]
    //public string FullName { get; set; }

    //[Required]
    //public string ImageUrl { get; set; }

    //[Required]
    //[MaxLength(DefaultMaxLength)]
    //public string Position { get; set; }

    //[Required]
    //[MaxLength(SpeedEnduranceMaxLength)]
    //public byte Speed { get; set; }

    //[Required]
    //[MaxLength(SpeedEnduranceMaxLength)]
    //public byte Endurance { get; set; }

    //[Required]
    //[MaxLength(DescriptionMaxLength)]
    //public string Description { get; set; }
}
