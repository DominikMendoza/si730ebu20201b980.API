using si730ebu20201b980.API.Learning.Domain.Models;

namespace si730ebu20201b980.API.Learning.Resources;

public class GuardianResource
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Gender { get; set; }
    public string? Address { get; set; }
    public IEnumerable<Urgency> Urgencies { get; set; }
}