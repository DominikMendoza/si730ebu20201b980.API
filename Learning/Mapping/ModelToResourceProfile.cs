using AutoMapper;
using si730ebu20201b980.API.Learning.Domain.Models;
using si730ebu20201b980.API.Learning.Resources;

namespace si730ebu20201b980.API.Learning.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Guardian, GuardianResource>();
        CreateMap<Urgency, UrgencyResource>();
    }
}