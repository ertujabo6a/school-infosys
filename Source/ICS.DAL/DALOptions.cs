namespace ICS.DAL;

public record DALOptions
{
    public required string DataBaseDirectory { get; init; }
    public string DatabaseName { get; init; } = null!;
    public string DatabaseFilePath => Path.Combine(DataBaseDirectory, DatabaseName!);
    public bool RecreateDatabaseEachTime { get; init; } = false;
    public bool SeedDemoData { get; init; } = false;
}
