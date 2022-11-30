namespace si730ebu20201b980.API.Loyalty.Domain.Models;

public class Reward
{
    public int Id { get; set; }
    public int FleetId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Score { get; set; }
}