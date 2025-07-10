using System.ComponentModel.DataAnnotations;

namespace Commander.Domain.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public required string HowTo { get; set; }

        [Required]
        public required string Line { get; set; }

        [Required]
        public required string Platform { get; set; }
    }
}
