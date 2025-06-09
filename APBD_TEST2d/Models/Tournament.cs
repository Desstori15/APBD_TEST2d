namespace APBD_TEST2d.Models;

public class Tournament
{
    public int TournamentId { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Match> Matches { get; set; } = new List<Match>();
}
