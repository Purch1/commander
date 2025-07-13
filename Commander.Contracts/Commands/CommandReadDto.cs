namespace Commander.Contracts.Dtos;
    public sealed record CommandReadDto
    (
        int Id,
        string HowTo,
        string Line,
        string Platform
    );
