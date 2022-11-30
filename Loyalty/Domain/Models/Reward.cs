namespace si730ebu20201b980.API.Loyalty.Domain.Models;

public class Reward
{
    /* Remember that...
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    So for this case I'm using lower camel case
    */
    
    public int id { get; set; }
    public int fleetId { get; set; }
    public string name { get; set; } = null!;
    public string? description { get; set; }
    public decimal score { get; set; }
}