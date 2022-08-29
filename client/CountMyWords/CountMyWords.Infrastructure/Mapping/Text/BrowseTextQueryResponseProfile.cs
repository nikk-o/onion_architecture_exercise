using AutoMapper;
using CountMyWords.Application.Text.Queries.RequestResponse;
using CountMyWords.Domain.Text.Read;

namespace CountMyWords.Infrastructure.Mapping.Text
{
    public class BrowseTextQueryResponseProfile : Profile
    {
        public BrowseTextQueryResponseProfile()
        {
            CreateMap<IEnumerable<TextReadModel>, BrowseTextQueryResponse>()
                .ForMember(dest => dest.Texts, opt => opt.MapFrom(src => src));

            CreateMap<TextReadModel, SingleTextResponse>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Value));
        }
    }
}
