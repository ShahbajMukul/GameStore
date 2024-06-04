using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public required string Name { get; set; }
    [Required(ErrorMessage = "The Genre field is required.")]
    public string? GenreId { get; set; }
    [Required]
    [Range(0.00, 200)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? Description { get; set; }
}
