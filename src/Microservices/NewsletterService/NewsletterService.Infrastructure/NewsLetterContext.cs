using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsletterService.Domain.AggregateModels.NewsletterAggregate;
using NewsletterService.Domain.AggregateModels.SeedWork;
using NewsletterService.Infrastructure.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterService.Infrastructure
{
    public class NewsletterContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public const string DEFAULT_SCHEMA = "newsLetter";
        public NewsletterContext(DbContextOptions<NewsletterContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public DbSet<Newsletter> Newsletters { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Get all the entities that have state "Added" or "Modified"
            var domainEntities = ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
                .Select(x => x.Entity)
                .ToList();

            if (!domainEntities.Any())
            {
                // No domain events to dispatch, just save changes and return.
                await base.SaveChangesAsync(cancellationToken);
                return true;
            }

            // Dispatch domain events before saving changes
            foreach (var domainEntity in domainEntities)
            {
                var events = domainEntity.DomainEvents.ToList();
                domainEntity.ClearDomainEvents();

                foreach (var domainEvent in events)
                {
                    // Dispatch domain event using MediatR
                    await _mediator.Publish(domainEvent, cancellationToken);
                }
            }

            // Save changes after dispatching domain events
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NewsletterContext).Assembly);

            modelBuilder.ApplyConfiguration(new NewsletterEntityTypeConfiguration());
        }
    }
}
