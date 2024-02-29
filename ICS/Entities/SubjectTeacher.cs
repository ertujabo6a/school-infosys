namespace ICS.DAL.Entities;
public record SubjectTeacher
{
    public required Guid Id {get; set; }
    public required string Login;
    public required string Abbr; 
}
