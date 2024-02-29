namespace ICS.DAL.Entities;
public record SubjectStudent
{
    public required Guid Id { get; set; }
    public required string Login;
    public required string Abr;
}
