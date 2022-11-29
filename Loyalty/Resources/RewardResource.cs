namespace si730ebu20201b980.API.Loyalty.Resources;

public class RewardResource
{
    public int Id { get; set; }
    public int fleetId { get; set; }
    public string name { get; set; }
    public string? description { get; set; }
    public decimal score { get; set; }
}