namespace Git.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.IntegerConstants;
    public class User
    {
            [Key]
            public string Id { get; init; } = Guid.NewGuid().ToString();

            [Required]
            [MaxLength(DefaultMaxLength)]
            public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IEnumerable<Repository> Repositories { get; init; } = new HashSet<Repository>();

        public IEnumerable<Commit> Commits { get; init; } = new HashSet<Commit>();
    }
}
