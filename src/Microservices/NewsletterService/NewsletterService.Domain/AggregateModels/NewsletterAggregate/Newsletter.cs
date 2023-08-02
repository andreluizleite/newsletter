using NewsletterService.Domain.AggregateModels.NewsletterDomain;
using NewsletterService.Domain.AggregateModels.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterService.Domain.AggregateModels.NewsletterAggregate
{
    public class Newsletter : Entity, IAggregateRoot
    {
        // Properties
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public HowHeardOption HowHeardUs { get; private set; }
        public string Reason { get; private set; }

        // Constructor
        private Newsletter(Guid id, string email, HowHeardOption howHeardUs, string reason)
        {
            Id = id;
            Email = email;
            HowHeardUs = howHeardUs;
            Reason = reason;
        }

        // Factory method for creating a new Newsletter entity
        public async Task<Newsletter> SubscribeAsync(string email, int howHeardUs, string reason)
        {
            var id = Guid.NewGuid();

            return new Newsletter(id, email, HowHeardOption.Other, reason);
        }
    }
}
