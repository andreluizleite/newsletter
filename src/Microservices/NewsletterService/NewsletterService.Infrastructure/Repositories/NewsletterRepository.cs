using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Newsletter>> GetSubscribersAsync()
        {
            return await _context.Newsletters.ToListAsync();
        }

        public bool IsEmailExist(string email)
        {
           return _context.Newsletters.Where(x => x.Email == email).Any();
        }

        public Newsletter Subscribe(Newsletter newsletter)
        {
            return _context.Newsletters.Add(newsletter).Entity;
        }

    }
}