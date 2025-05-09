namespace DollarToSomConverter.Domain_folder;

public abstract class Auditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
