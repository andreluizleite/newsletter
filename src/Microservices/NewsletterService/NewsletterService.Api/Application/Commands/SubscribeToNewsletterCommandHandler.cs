using MediatR;
using NewsletterService.Api.Application.DTOs;
using NewsletterService.Domain.AggregateModels.NewsletterAggregate;
using NewsletterService.Infrastructure.Repositories;

namespace NewsletterService.Api.Application.Commands
{
    public class SubscribeToNewsletterCommandHandler : IRequestHandler<SubscribeToNewsletterCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly INewsletterRepository _newsletterRepository;

        public SubscribeToNewsletterCommandHandler(IMediator mediator, INewsletterRepository newsletterRepository)
        {
            _mediator = mediator;
            _newsletterRepository = newsletterRepository;
        }

        public async Task<bool> Handle(SubscribeToNewsletterCommand request, CancellationToken cancellationToken)
        {
            if (await _newsletterRepository.IsEmailExistAsync(request.Email))
            {
                throw new ArgumentException("The email has already been registered in the system.");
            }

            Newsletter newsletter = new Newsletter(request.Email, request.HowHeardUs.ToDto(), request.Reason);

            _newsletterRepository.Subscribe(newsletter);
            _newsletterRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;

        }
    }
}
