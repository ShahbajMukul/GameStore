using Frontend.Models;

namespace Frontend.Clients;

public class GameReviewClient
{
    private List<GameReview> reviews = [
        new GameReview { Id = 1, UserName = "JohnDoe", Title = "Great Game", Review = "This game is awesome!", Rating = 5, Date = new DateTime(2021, 1, 1), GameId = "1", GameName = "Zelda", UserId = "1" },
        new GameReview { Id = 2, UserName = "JaneDoe", Title = "Good Game", Review = "This game is good!", Rating = 4, Date = new DateTime(2021, 1, 2), GameId = "2",GameName = "Subnautica", UserId = "2" },
        new GameReview { Id = 3, UserName = "JohnSmith", Title = "Bad Game", Review = "This game is bad!", Rating = 2, Date = new DateTime(2021, 1, 3), GameId = "3", GameName = "Spiderman", UserId = "3" }];


    public void AddReview(GameReview review)
    {
        reviews.Add(review);
    }

    public GameReview GetGameReview(int id)
    {
        var review = reviews.Find(review => review.Id == id);
        ArgumentNullException.ThrowIfNull(review);
        return review;
    }

    public List<GameReview> GetGameReviews()
    {
        return reviews;
    }

    public void UpdateReview(GameReview updatedReview)
    {
        GameReview existingReview = GetGameReview(updatedReview.Id);

        existingReview.UserName = updatedReview.UserName;
        existingReview.Title = updatedReview.Title;
        existingReview.Review = updatedReview.Review;
        existingReview.Rating = updatedReview.Rating;
        existingReview.Date = updatedReview.Date;
    }

    public void DeleteReview(int id)
    {
        GameReview review = GetGameReview(id);
        reviews.Remove(review);
    }

}
