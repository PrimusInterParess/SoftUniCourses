

namespace SMS.Data.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SMS.Data.Models;
public class User
{



    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [MaxLength(20)]
    public string Username { get; set; }

    [Required]
    [MaxLength(64)]
    public string Password { get; set; }

    [Required]
    [MaxLength(340)]
    public string Email { get; set; }

    public string CartId { get; set; }
    [Required]
    [ForeignKey(nameof(CartId))]
    public Cart Cart { get; set; }
}