using MediatR;
using NewsletterService.Domain.AggregateModels.NewsletterAggregate;

namespace NewsletterService.Api.Application.Commands
{
    public class SubscribeToNewsletterCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public int HowHeardUs { get; set; }
        public string Reason { get; set; }
    }
}
