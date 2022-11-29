using System.Text.Json.Serialization;

namespace si730ebu20201b980.API.Learning.Domain.Models;

public class Urgency
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string ReportedAt { get; set; }
    public int GuardianId { get; set; }
    [JsonIgnore]
    public Guardian Guardian { get; set; }
}