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

        private Newsletter() { }
        public Newsletter(string email, HowHeardOption howHeardUs, string reason)
        {
            var id = Guid.NewGuid();
            Email = email;
            HowHeardUs = howHeardUs;
            Reason = reason;
        }

    }
}
