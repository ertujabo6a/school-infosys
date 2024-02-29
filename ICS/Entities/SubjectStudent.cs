namespace ICS.DAL.Entities;
public record SubjectStudent
{
    public Guid ID {get; set; }
    public required string Login;
    public required string Abr;
}
