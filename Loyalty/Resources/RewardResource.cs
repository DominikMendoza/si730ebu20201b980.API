namespace si730ebu20201b980.API.Loyalty.Resources;

public class RewardResource
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public string? description { get; set; }
    public decimal score { get; set; }
}