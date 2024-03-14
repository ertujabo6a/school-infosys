﻿namespace ICS.DAL.Entities;

public record ActivityEntity
{
    public required Guid EntityId { get; set; }
    public required ActivityType Type { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public required string Description { get; set; } = string.Empty;

    public required Subject Subject { get; init; }
    public required string SubjectAbbr { get; set; } = string.Empty;

    public ICollection<Student> Students { get; set; } = new List<Student>();

    public required Room Room { get; init; }

    public ICollection<EvaluationEntity> Evaluations { get; set; } = new List<EvaluationEntity>();
}


