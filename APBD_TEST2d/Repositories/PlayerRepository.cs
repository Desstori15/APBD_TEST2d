using APBD_TEST2d.Data;
using APBD_TEST2d.DTOs;
using APBD_TEST2d.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_TEST2d.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly AppDbContext _context;

    public PlayerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PlayerMatchesResponseDto?> GetPlayerMatchesAsync(int playerId)
    {
        var player = await _context.Players
            .Include(p => p.PlayerMatches)
                .ThenInclude(pm => pm.Match)
                    .ThenInclude(m => m.Tournament)
            .Include(p => p.PlayerMatches)
                .ThenInclude(pm => pm.Match)
                    .ThenInclude(m => m.Map)
            .FirstOrDefaultAsync(p => p.PlayerId == playerId);

        if (player == null) return null;

        var dto = new PlayerMatchesResponseDto
        {
            PlayerId = player.PlayerId,
            FirstName = player.FirstName,
            LastName = player.LastName,
            BirthDate = player.BirthDate,
            Matches = player.PlayerMatches.Select(pm => new MatchSummaryDto
            {
                Tournament = pm.Match.Tournament.Name,
                Map = pm.Match.Map.Name,
                Date = pm.Match.Date,
                MVPs = pm.MVPs,
                Rating = pm.Rating,
                Team1Score = pm.Match.Team1Score,
                Team2Score = pm.Match.Team2Score
            }).ToList()
        };

        return dto;
    }

    public async Task<string?> AddPlayerWithMatchesAsync(AddPlayerRequestDto dto)
    {
        // Проверка матчей
        foreach (var matchDto in dto.Matches)
        {
            var exists = await _context.Matches.AnyAsync(m => m.MatchId == matchDto.MatchId);
            if (!exists) return $"Match with ID {matchDto.MatchId} does not exist.";
        }

        var player = new Player
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BirthDate = dto.BirthDate
        };

        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync(); // Сохраняем для получения PlayerId

        foreach (var matchDto in dto.Matches)
        {
            var existing = await _context.PlayerMatches
                .FirstOrDefaultAsync(pm => pm.PlayerId == player.PlayerId && pm.MatchId == matchDto.MatchId);

            if (existing == null)
            {
                var newEntry = new PlayerMatch
                {
                    PlayerId = player.PlayerId,
                    MatchId = matchDto.MatchId,
                    MVPs = matchDto.MVPs,
                    Rating = matchDto.Rating
                };
                _context.PlayerMatches.Add(newEntry);
            }
            else if (matchDto.Rating > existing.Rating)
            {
                existing.Rating = matchDto.Rating;
                existing.MVPs = matchDto.MVPs;
            }
        }

        await _context.SaveChangesAsync();
        return null; 
    }
}
