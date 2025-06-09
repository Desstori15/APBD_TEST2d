using APBD_TEST2d.DTOs;
using APBD_TEST2d.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APBD_TEST2d.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerRepository _repository;

    public PlayersController(IPlayerRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// GET: /api/players/{id}/matches
    /// </summary>
    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayerMatches(int id)
    {
        var result = await _repository.GetPlayerMatchesAsync(id);
        if (result == null)
            return NotFound($"Player with ID {id} not found.");

        return Ok(result);
    }

    /// <summary>
    /// POST: /api/players
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> AddPlayerWithMatches([FromBody] AddPlayerRequestDto dto)
    {
        var error = await _repository.AddPlayerWithMatchesAsync(dto);
        if (error != null)
            return BadRequest(error);

        return Created("", "Player added successfully.");
    }
}