using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Shared.Domain.Services.Communication;

namespace si730ebu20201b980.API.Loyalty.Domain.Services.Communication;

public class RewardResponse : BaseResponse<Reward>
{
    public RewardResponse(Reward reward) : base(reward)
    {
    }
    
    public RewardResponse(string message) : base(message)
    {
    }
}