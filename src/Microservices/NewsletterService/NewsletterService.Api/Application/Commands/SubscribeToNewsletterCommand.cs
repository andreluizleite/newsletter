using MediatR;
using NewsletterService.Api.Application.DTOs;
using NewsletterService.Domain.AggregateModels.NewsletterAggregate;

namespace NewsletterService.Api.Application.Commands
{
    public class SubscribeToNewsletterCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public HowHeardOptionDto HowHeardUs { get; set; }
        public string Reason { get; set; }
    }
}
