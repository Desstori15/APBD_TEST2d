using APBD_TEST2d.Models;

namespace APBD_TEST2d.Data;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Players.Any()) return; 

        // Tournaments 
        var tournament = new Tournament { Name = "CS2 Summer Cup" };
        context.Tournaments.Add(tournament);

        // It's our map 
        var inferno = new Map { Name = "Inferno" };
        var mirage = new Map { Name = "Mirage" };
        context.Maps.AddRange(inferno, mirage);

        context.SaveChanges();

        // here match
        var match1 = new Match
        {
            TournamentId = tournament.TournamentId,
            MapId = inferno.MapId,
            Date = new DateTime(2025, 7, 2, 15, 0, 0),
            Team1Score = 16,
            Team2Score = 12
        };
        var match2 = new Match
        {
            TournamentId = tournament.TournamentId,
            MapId = mirage.MapId,
            Date = new DateTime(2025, 7, 3, 18, 0, 0),
            Team1Score = 10,
            Team2Score = 16
        };
        context.Matches.AddRange(match1, match2);
        context.SaveChanges();

        // our player
        var player = new Player
        {
            FirstName = "Alex",
            LastName = "Smith",
            BirthDate = new DateTime(2000, 5, 20)
        };
        context.Players.Add(player);
        context.SaveChanges();

        // player which be in match
        var pm1 = new PlayerMatch
        {
            PlayerId = player.PlayerId,
            MatchId = match1.MatchId,
            MVPs = 3,
            Rating = 1.25
        };
        var pm2 = new PlayerMatch
        {
            PlayerId = player.PlayerId,
            MatchId = match2.MatchId,
            MVPs = 2,
            Rating = 1.10
        };
        context.PlayerMatches.AddRange(pm1, pm2);
        context.SaveChanges();
    }
}