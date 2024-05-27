using Frontend.Models;

namespace Frontend.Clients;

public class GenreClient
{
    private readonly Genre[] genres = new Genre[]
    {
        new Genre { Id = 1, Name = "Action" },
        new Genre { Id = 2, Name = "Adventure" },
        new Genre { Id = 3, Name = "RPG" },
        new Genre { Id = 4, Name = "Simulation" },
        new Genre { Id = 5, Name = "Strategy" },
        new Genre { Id = 6, Name = "Sports" },
        new Genre { Id = 7, Name = "Puzzle" },
        new Genre { Id = 8, Name = "Idle" },
        new Genre { Id = 9, Name = "Casual" },
        new Genre { Id = 10, Name = "Horror" },
        new Genre { Id = 11, Name = "Survival" },
        new Genre { Id = 12, Name = "MMO" },
        new Genre { Id = 13, Name = "Racing" },
        new Genre { Id = 14, Name = "Fighting" },
        new Genre { Id = 15, Name = "Shooter" },
        new Genre { Id = 16, Name = "Sandbox" },
        new Genre { Id = 17, Name = "Open World" },
        new Genre { Id = 18, Name = "Battle Royale" },
        new Genre { Id = 19, Name = "Metroidvania" },
        new Genre { Id = 20, Name = "Platformer" },
        new Genre { Id = 21, Name = "Roguelike" },
        new Genre { Id = 22, Name = "Roguelite" },
        new Genre { Id = 23, Name = "Tactical" },
        new Genre { Id = 24, Name = "Stealth" },
        new Genre { Id = 25, Name = "Hack and Slash" },
        new Genre { Id = 26, Name = "Beat 'em up" },
        new Genre { Id = 27, Name = "Music" },
        new Genre { Id = 28, Name = "Educational" },
        new Genre { Id = 29, Name = "Trivia" },
        new Genre { Id = 30, Name = "Party" },
        new Genre { Id = 31, Name = "Board"},
        new Genre { Id = 32, Name = "Card" },
        new Genre { Id = 33, Name = "Casino" },
        new Genre { Id = 34, Name = "Poker" },

};

    public Genre[] GetGenres() => genres;

}

