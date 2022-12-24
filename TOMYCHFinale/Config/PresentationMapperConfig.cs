using AutoMapper;
using Services.BusinessObjects;
using TOMYCHFinale.Contracts.Request;
using TOMYCHFinale.Contracts.Response;

namespace TOMYCHFinale.Config
{
    public class PresentationMapperConfig : Profile
    {
        public PresentationMapperConfig() 
        {
            CreateMap<UserBO, UserResponse>()
                    .ForMember(d => d.Requests, o => o.MapFrom(s => s.Requests));
            CreateMap<SupportRequestBO, SupportRequestResponse>()
                .ForMember(d => d.Messages, o => o.MapFrom(s => s.Messages));
            CreateMap<SupportRequestMessagesBO, SupportRequestMessageResponse>();
            CreateMap<SupportRequestBO, SupportRequestCreateModel>().ReverseMap();
            CreateMap<UserRegistrationRequest, UserBO>();
        }
    }
}
