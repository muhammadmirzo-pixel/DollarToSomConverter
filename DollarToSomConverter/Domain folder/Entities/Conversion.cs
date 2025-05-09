namespace DollarToSomConverter.Domain_folder.Entities;

public class Conversion : Auditable
{
    public Guid UserId { get; set; }
    public decimal DollarAmount { get; set; }
    public decimal SomAmount { get; set; }
}