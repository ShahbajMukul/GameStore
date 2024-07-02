namespace Frontend.Models;

public class GameReview
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Title { get; set; }
    public string Review { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }
    public string GameId { get; set; }
    public string GameName { get; set; }
    public string UserId { get; set; }

}
