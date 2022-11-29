using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Shared.Domain.Services.Communication;

namespace si730ebu20201b980.API.Loyalty.Domain.Services.Communication;

public class GuardianResponse : BaseResponse<Guardian>
{
    public GuardianResponse(string message) : base(message)
    {
    }

    public GuardianResponse(Guardian resource) : base(resource)
    {
    }
}