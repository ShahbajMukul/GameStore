using GameStore.Api.Dtos;
using Microsoft.VisualBasic;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpoint = "GetGame";


    private static readonly List<GameDto> games =
        new()
        {
        new GameDto(1, "Cyberpunk 2077", "Action RPG", 59.99m, new DateOnly(2020, 12, 10)),
        new GameDto(2, "The Witcher 3: Wild Hunt", "Action RPG", 39.99m, new DateOnly(2015, 5, 19)),
        new GameDto(3, "Red Dead Redemption 2", "Action-Adventure", 59.99m, new DateOnly(2018, 10, 26)),
        new GameDto(4, "Grand Theft Auto V", "Action-Adventure", 29.99m, new DateOnly(2013, 9, 17)),
        new GameDto(5, "The Elder Scrolls V: Skyrim", "Action RPG", 39.99m, new DateOnly(2011, 11, 11))
        };

    // This is an extension method, so it must be static
    // we are extending this because that's the standard way to add endpoints to the app
    // this helps because we can keep the Program.cs file clean
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("/games")
        .WithParameterValidation(); // WithParameterValidation is used to validate the parameters of the route // This is used to group the routes together under the /games path, otherwise we would have to repeat /games in each route

        // GET /games
        group.MapGet("/", () => games);

        // GET /games/{id}
        group.MapGet("/{id}", (int id) =>
        {
            var game = games.Find(game => game.Id == id);

            if (game is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(game);

        }
        ).WithName("GetGame"); // WithName is used to give a name to the route

        // POST /games
        group.MapPost("/", (CreateGameDto gameDto) =>
        {

            var newGame = new GameDto(games.Count + 1, gameDto.Name, gameDto.Genre, gameDto.Price, gameDto.ReleaseDate);
            games.Add(newGame);
            return Results.CreatedAtRoute("GetGame", new { id = newGame.Id }, newGame);
        });


        // PUT /games/{id}
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var indexOfGame = games.FindIndex(game => game.Id == id);

            if (indexOfGame == -1)
            {
                return Results.NotFound();
            }

            games[indexOfGame] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );
            return Results.NoContent();
        });

        // DELETE /games/{id}
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });

        app.MapGet("/about", () => "Welcome to GameStore! We are a leading online platform for purchasing and downloading games. Our mission is to provide gamers with a seamless and enjoyable gaming experience. Explore our vast collection of games, discover new releases, and connect with a vibrant community of gamers. Start your gaming journey with GameStore today!");


        return group;
    }
}
