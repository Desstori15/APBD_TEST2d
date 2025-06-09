namespace APBD_TEST2d.Models;

public class Player
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }

    public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();
}
