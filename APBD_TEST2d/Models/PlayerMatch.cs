namespace APBD_TEST2d.Models;

public class PlayerMatch
{
    public int PlayerId { get; set; }
    public Player Player { get; set; } = null!;

    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;

    public int MVPs { get; set; }
    public double Rating { get; set; }
}
