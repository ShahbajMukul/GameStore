namespace GameStore.Api.Dtos;

// We are going to create a DTO (Data Transfer Object) for the Game entity. This DTO will be used to transfer data between the API and the client.
// Dto is used instead of Entity because we don't want to expose the internal structure of the entity to the client. We only want to expose the necessary information.
// This DTO will contain the properties that we want to expose to the client.
// We will create a public record class called GameDto.
// A record is a reference type that provides built-in functionality for encapsulating data. It is similar to a class, but with value-based equality semantics.
// A record is immutable by default, meaning that its properties cannot be changed after the object is created.

public record class GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate);