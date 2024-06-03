namespace GameStore.Api.Dtos;

public record class UpdateGameDto
(
    [Required][StringLength(50)] string Name, // Name is required and has a maximum length of 50 characters
    [Required][StringLength(20)] string Genre,
    [Range(1, 120)] decimal Price,
    [Required] DateOnly ReleaseDate
);
