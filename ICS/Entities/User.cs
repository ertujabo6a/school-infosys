namespace ICS.DAL.Entities;
public record User
{
    public required string Login { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
    public required string FirstName { get; set; } = string.Empty;
    public required string LastName { get; set; } = string.Empty;
    public DateTime Birth { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;

    public Student? Student { get; set; }
    public Teacher? Teacher { get; set; }
    public Admin? Admin { get; set; }

}
