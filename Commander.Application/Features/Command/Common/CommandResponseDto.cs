namespace Commander.Contracts.Dtos;
    public sealed record CommandResponseDto
    (
        string Id,
        string HowTo,
        string Line,
        string Platform,
        string CreatedAt,
        string UpdatedAt
    );