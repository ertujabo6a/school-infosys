namespace ICS.DAL.Entities;
public abstract record User
{
    protected string Login { get; set; } = string.Empty;
    protected string Password { get; set; } = string.Empty;
    protected string FirstName { get; set; } = string.Empty;
    protected string LastName { get; set; } = string.Empty;
    public DateTime Birth { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;

}
