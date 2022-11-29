using AutoMapper;
using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Loyalty.Resources;

namespace si730ebu20201b980.API.Loyalty.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveGuardianResource, Guardian>();
        CreateMap<SaveUrgencyResource, Urgency>();
        CreateMap<SaveRewardResource, Reward>();
    }
}