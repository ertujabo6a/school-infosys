namespace ICS.App.Messages;

public record EvaluationEditMessage
{
    public required Guid EvaluationId { get; init; }
}
