namespace ICS.DAL.Entities;

public record Room
{
    public required string RoomName { get; set; }
    public required int Capacity { get; set; }
    public required int Floor { get; set; }
    public string? Purpose { get; set; }
}
