using Frontend.Models;

namespace Frontend.Clients;

public class GamesClients
{
    private readonly List<GameSummary> games = [
   new GameSummary { Id = 1, Name = "The Witcher 3: Wild Hunt", Genre = "RPG", Price = 29.99m, ReleaseDate = new
DateOnly(2015, 5, 19) },
new GameSummary { Id = 2, Name = "Grand Theft Auto V", Genre = "Action", Price = 29.99m, ReleaseDate = new
DateOnly(2013, 9, 17) },
new GameSummary { Id = 3, Name = "Red Dead Redemption 2", Genre = "Action", Price = 59.99m, ReleaseDate = new
DateOnly(2018, 10, 26) },
new GameSummary { Id = 4, Name = "The Elder Scrolls V: Skyrim", Genre = "RPG", Price = 19.99m, ReleaseDate = new
DateOnly(2011, 11, 11) },
new GameSummary { Id = 5, Name = "The Legend of Zelda: Breath of the Wild", Genre = "Action", Price = 59.99m,
ReleaseDate = new DateOnly(2017, 3, 3) },
new GameSummary { Id = 6, Name = "Horizon Zero Dawn", Genre = "Action", Price = 19.99m, ReleaseDate = new DateOnly(2017,
2, 28) },
new GameSummary { Id = 7, Name = "God of War", Genre = "Action", Price = 19.99m, ReleaseDate = new DateOnly(2018, 4, 20)
},
new GameSummary { Id = 8, Name = "Bloodborne", Genre = "Action", Price = 19.99m, ReleaseDate = new DateOnly(2015, 3, 24)
},
new GameSummary { Id = 9, Name = "Uncharted 4: A Thief's End", Genre = "Action", Price = 19.99m, ReleaseDate = new
DateOnly(2016, 5, 10) },
new GameSummary { Id = 10, Name = "Marvel's Spiderman - Miles Morales", Genre = "Action", Price = 49.99m, ReleaseDate =
new DateOnly(2020, 11, 12) },
new GameSummary { Id = 11, Name = "Detroit: Become Human", Genre = "Adventure", Price = 19.99m, ReleaseDate = new
DateOnly(2018, 5, 25) },
];

    /* This gets all the genres into this array so that we can convert from Id to Name for the game summarys */
    private readonly Genre[] genres = new GenreClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);

        var GameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(GameSummary);
    }



    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    private GameSummary GetGameSummaryById(int id)
    {
        var game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        // Validate that the genre id is not null or whitespace so that we can get the genre name
        ArgumentException.ThrowIfNullOrWhiteSpace(id);

        // This is a simple way to get the genre from the genre id
        return genres.Single(genre => genre.Id == int.Parse(id));
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

        Genre genre = GetGenreById(updatedGame.GenreId);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);
        games.Remove(game);
    }

}

