namespace ITI.Baseline.Audit;

public class AuditPropertyDto
{
    public AuditPropertyDto(string name, string? from, string? to)
    {
        Name = name;
        From = from;
        To = to;

        while (Name.StartsWith("."))
            Name = Name[1..];
    }

    public string Name { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
}
