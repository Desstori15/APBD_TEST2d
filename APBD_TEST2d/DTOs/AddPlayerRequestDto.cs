namespace APBD_TEST2d.DTOs;

public class AddPlayerRequestDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public List<PlayerMatchInputDto> Matches { get; set; } = new();
}
