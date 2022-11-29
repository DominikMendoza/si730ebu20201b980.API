using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Shared.Domain.Services.Communication;

namespace si730ebu20201b980.API.Loyalty.Domain.Services.Communication;

public class UrgencyResponse : BaseResponse<Urgency>
{
    public UrgencyResponse(string message) : base(message)
    {
    }

    public UrgencyResponse(Urgency resource) : base(resource)
    {
    }
}