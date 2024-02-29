namespace ICS.DAL.Entities;
public record SubjectTeacher
{
    public Guid ID {get; set; }
    public required string Login;
    public required string Abr; 
}
