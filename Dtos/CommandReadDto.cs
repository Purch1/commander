namespace Commander.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        public required string HowTo { get; set; }
        public required string Line { get; set; }
        public required string Platform { get; set; }
    }
}
