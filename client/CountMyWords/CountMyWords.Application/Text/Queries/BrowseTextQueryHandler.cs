using AutoMapper;
using MediatR;
using CountMyWords.Application.Text.Queries.RequestResponse;
using CountMyWords.Domain.Text;
using CountMyWords.Domain.Text.Read;

namespace CountMyWords.Application.Text.Queries
{
    // Used for listing through the texts from the database/file
    // Supports pagination
    public class BrowseTextQueryHandler : IRequestHandler<BrowseTextQuery, BrowseTextQueryResponse>
    {
        private IMapper mapper;

        private ITextRepositoryResolver textRepositoryResolver;

        public BrowseTextQueryHandler(IMapper mapper, ITextRepositoryResolver textRepositoryResolver)
        {
            this.mapper = mapper;
            this.textRepositoryResolver = textRepositoryResolver;
        }

        public async Task<BrowseTextQueryResponse> Handle(BrowseTextQuery request, CancellationToken cancellationToken)
        {
            var textReadonlyRepository = textRepositoryResolver.ResolveReadonlyRepository(request.ReadFrom);

            var textReadModels = await textReadonlyRepository.BrowseTextReadModelsAsync(request.Page, request.PageSize);

            return mapper.Map<IEnumerable<TextReadModel>, BrowseTextQueryResponse>(textReadModels);
        }
    }
}
