namespace ICS.App.Messages;

public record StudentEditMessage
{
    public required Guid StudentId { get; init; }
}
