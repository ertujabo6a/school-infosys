namespace ICS.DAL;

public record DALOptions
{
    public required string DataBaseDirectory { get; set; }
    public string DatabaseName { get; set; } = null!;
    public string DatabaseFilePath => Path.Combine(DataBaseDirectory, DatabaseName!);
    public bool SeedDemoData { get; set; } = false;
}
