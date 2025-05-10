using DollarToSomConverter.Domain.Commons;

namespace DollarToSomConverter.Domain.Entities;

public class Conversion : Auditable
{
    public decimal DollarAmount { get; set; }
    public decimal SomAmount { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
