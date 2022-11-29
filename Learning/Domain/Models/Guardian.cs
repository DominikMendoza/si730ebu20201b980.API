using System.Text.Json.Serialization;

namespace si730ebu20201b980.API.Learning.Domain.Models;

public class Guardian
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    [JsonIgnore]
    public IList<Urgency> Urgencies { get; set; }
}