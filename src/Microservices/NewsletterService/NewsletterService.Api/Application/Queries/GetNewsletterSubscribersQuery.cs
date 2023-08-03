using MediatR;
using NewsletterService.Api.Application.DTOs;

namespace NewsletterService.Api.Application.Queries
{
    public class GetNewsletterSubscribersQuery : IRequest<List<SubscriptionDTO>>
    {
    }
}
