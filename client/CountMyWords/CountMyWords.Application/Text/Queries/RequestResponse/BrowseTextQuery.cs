using CountMyWords.Domain.Common;
using MediatR;

namespace CountMyWords.Application.Text.Queries.RequestResponse
{
    public class BrowseTextQuery : IRequest<BrowseTextQueryResponse>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public ReadTextFromType ReadFrom { get; set; }
    }
}
