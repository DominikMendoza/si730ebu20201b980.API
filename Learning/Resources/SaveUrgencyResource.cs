using System.ComponentModel.DataAnnotations;

namespace si730ebu20201b980.API.Learning.Resources;

public class SaveUrgencyResource
{
    [Required]
    public string Title { get; set; }
    
    public string Summary { get; set; }

    [Required] public string Latitude { get; set; }
    [Required] public string Longitude { get; set; }
    [Required] public string ReportedAt { get; set; }
}