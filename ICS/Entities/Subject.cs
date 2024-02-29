namespace ICS.DAL.Entities;
public record Subject
{
    public required string Abbreviature { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public int Year { get; set; }
    
    public int Points { get; set; }
    
    public bool Compulsorily { get; set; }
    
}
