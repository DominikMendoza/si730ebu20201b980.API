namespace si730ebu20201b980.API.Loyalty.Resources;

public class RewardResource
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Score { get; set; }
}