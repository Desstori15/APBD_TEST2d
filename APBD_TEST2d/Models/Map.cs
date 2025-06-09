namespace APBD_TEST2d.Models;

public class Map
{
    public int MapId { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Match> Matches { get; set; } = new List<Match>();
}
