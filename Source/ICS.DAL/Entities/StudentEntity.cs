namespace ICS.DAL.Entities;

public record StudentEntity : IEntity
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? ImageUrl { get; set; }

    public ICollection<SubjectEntity> Subjects { get; init; } = [];
    public ICollection<EvaluationEntity> Evaluations { get; init; } = [];

    public required Guid Id { get; set; }
}
