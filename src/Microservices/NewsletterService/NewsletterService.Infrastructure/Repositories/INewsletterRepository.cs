using NewsletterService.Domain.AggregateModels.NewsletterAggregate;
using NewsletterService.Domain.AggregateModels.SeedWork;

namespace NewsletterService.Infrastructure.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {
        private readonly NewsletterContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public NewsletterRepository(NewsletterContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IEnumerable<Newsletter>> GetSubscribersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailExistAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Newsletter> SubscribeAsync(string email, int howheard, string reason)
        {
            throw new NotImplementedException();
        }
    }
}