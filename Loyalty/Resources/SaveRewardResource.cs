using System.ComponentModel.DataAnnotations;

namespace si730ebu20201b980.API.Loyalty.Resources;

public class SaveRewardResource
{
    [Required]
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
    
    [Required]
    public decimal Score { get; set; }
}