using APBD_TEST2d.DTOs;

namespace APBD_TEST2d.Repositories;

public interface IPlayerRepository
{
    Task<PlayerMatchesResponseDto?> GetPlayerMatchesAsync(int playerId);
    Task<string?> AddPlayerWithMatchesAsync(AddPlayerRequestDto dto);
}