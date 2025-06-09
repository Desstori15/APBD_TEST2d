namespace APBD_TEST2d.DTOs;

public class PlayerMatchesResponseDto
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public List<MatchSummaryDto> Matches { get; set; } = new();
}
