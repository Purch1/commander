using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        [MaxLength(250)]
        public required string HowTo { get; set; }
        
        [Required]
        public required string Line { get; set; }
        
        [Required]
        public required string Platform { get; set; }
    }
}
