using MediatR;
using NewsletterService.Api.Application.Commands;
using NewsletterService.Api.Application.DTOs;
using NewsletterService.Domain.AggregateModels.NewsletterAggregate;

namespace NewsletterService.Api.Application.Queries
{
    public class GetNewsletterSubscribersQueryHandler : IRequestHandler<GetNewsletterSubscribersQuery, IEnumerable<SubscriptionDTO>>
    {
        private readonly IMediator _mediator;
        private readonly INewsletterRepository _newsletterRepository;


        public GetNewsletterSubscribersQueryHandler(IMediator mediator, INewsletterRepository newsletterRepository)
        {
            _mediator = mediator;
            _newsletterRepository = newsletterRepository;
        }

        public async Task<IEnumerable<SubscriptionDTO>> Handle(GetNewsletterSubscribersQuery request, CancellationToken cancellationToken)
        {
            var subscribers = await _newsletterRepository.GetSubscribersAsync();
            return subscribers.ToList().Select(x => x.ToDto());
        }
    }
}
