namespace si730ebu20201b980.API.Loyalty.Domain.Models;

public class Reward
{
    public int Id { get; set; }
    public int fleetId { get; set; }
    public string name { get; set; }
    public string? description { get; set; }
    public decimal score { get; set; }
}