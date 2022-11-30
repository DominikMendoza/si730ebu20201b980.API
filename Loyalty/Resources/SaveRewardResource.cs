using System.ComponentModel.DataAnnotations;

namespace si730ebu20201b980.API.Loyalty.Resources;

public class SaveRewardResource
{
    [Required]
    public string name { get; set; }
    
    public string? description { get; set; }
    
    [Required]
    public decimal score { get; set; }
}