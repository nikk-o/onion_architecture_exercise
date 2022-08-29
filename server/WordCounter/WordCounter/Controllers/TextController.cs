using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WordCounter.Application.Text.Commands.RequestResponse;

namespace WordCounter.Web.Controllers
{
    [Route("text")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly IMediator mediator;

        public TextController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("count-words")]
        public async Task<ActionResult<CountWordsCommandResponse>> CountWords(CountWordsCommand request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
