namespace APBD_TEST2d.DTOs;

public class MatchSummaryDto
{
    public string Tournament { get; set; } = null!;
    public string Map { get; set; } = null!;
    public DateTime Date { get; set; }
    public int MVPs { get; set; }
    public double Rating { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
}
