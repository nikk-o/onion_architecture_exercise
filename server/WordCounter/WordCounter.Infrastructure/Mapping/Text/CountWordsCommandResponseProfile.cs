using AutoMapper;
using WordCounter.Application.Text.Commands.RequestResponse;
using WordCounter.Domain.Text.ReadModels;

namespace WordCounter.Infrastructure.Mapping.Text
{
    public class CountWordsCommandResponseProfile : Profile
    {
        public CountWordsCommandResponseProfile()
        {
            CreateMap<WordsCounterResult, CountWordsCommandResponse>();
        }
    }
}
