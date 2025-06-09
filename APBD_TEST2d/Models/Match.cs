namespace APBD_TEST2d.Models;

public class Match
{
    public int MatchId { get; set; }
    public DateTime Date { get; set; }

    public int MapId { get; set; }
    public Map Map { get; set; } = null!;

    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; } = null!;

    public int Team1Score { get; set; }
    public int Team2Score { get; set; }

    public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();
}
