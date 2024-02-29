namespace ICS.DAL.Entities;
public abstract record User
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime Birth { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;

}
