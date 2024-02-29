namespace ICS.DAL.Entities;
public record Subject
{
    public required string Abbr { get; set; } = string.Empty;
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public int Year { get; set; }
    
    public int Points { get; set; }
    
    public bool Compulsorily { get; set; }
    
}
