using AutoMapper;
using si730ebu20201b980.API.Learning.Domain.Models;
using si730ebu20201b980.API.Learning.Resources;

namespace si730ebu20201b980.API.Learning.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveGuardianResource, Guardian>();
        CreateMap<SaveUrgencyResource, Urgency>();
    }
}