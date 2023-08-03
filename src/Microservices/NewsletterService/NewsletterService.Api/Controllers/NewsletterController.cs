using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsletterService.Api.Application.Commands;
using NewsletterService.Api.Application.DTOs;
using NewsletterService.Api.Application.Queries;

namespace NewsletterService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsletterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody] SubscriptionDTO subscription)
        {
            try
            {
                var command = new SubscribeToNewsletterCommand
                {
                    Email = subscription.Email,
                    HowHeardUs = subscription.HowHeardUs,
                    Reason = subscription.Reason,
                };

                bool result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<List<SubscriptionDTO>> GetSubscribers()
        {
            var query = new GetNewsletterSubscribersQuery();
            return await _mediator.Send(query);
        }
    }

}
