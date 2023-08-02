using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsletterService.Api.Application.Commands;
using NewsletterService.Api.Application.DTOs;
using NewsletterService.Api.Application.Queries;

namespace NewsletterService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NewsletterService
    {
        private readonly IMediator _mediator;

        public NewsletterService(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Subscribe")]
        public async Task<bool> Subscribe(string email, HowHeardOptionDto howHeardUs, string reason)
        {
            var command = new SubscribeToNewsletterCommand
            {
                Email = email,
                HowHeardUs = howHeardUs,
                Reason = reason
            };

            return await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetSubscribers")]
        public async Task<List<SubscriptionDTO>> GetSubscribers()
        {
            var query = new GetNewsletterSubscribersQuery();
            return await _mediator.Send(query);
        }
    }

}
