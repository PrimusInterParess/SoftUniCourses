using System.ComponentModel.DataAnnotations;

namespace SMS.Models.Products;

public class CreateProductViewModel
{
    [Required]
    [StringLength(20,MinimumLength = 4,ErrorMessage = "{0} name should be between {2} and {1} characters!")]
    public string Name { get; set; }

    public string Price { get; set; }
    
}

//Product
//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 4 and max length 20 (required)
//•	Has Price – a decimal (in range 0.05 – 1000)
//•	Has a Cart – a Cart object
