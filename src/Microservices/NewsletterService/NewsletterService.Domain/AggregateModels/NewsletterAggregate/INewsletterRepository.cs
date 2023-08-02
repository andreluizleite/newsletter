﻿using NewsletterService.Domain.AggregateModels.NewsletterDomain;
using NewsletterService.Domain.AggregateModels.SeedWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterService.Domain.AggregateModels.NewsletterAggregate
{
    public interface INewsletterRepository : IRepository<Newsletter>
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        Task<Newsletter> SubscribeAsync(string email, int howheard, string reason);

        Task<bool> IsEmailExistAsync(string email);

        Task<IEnumerable<Newsletter>> GetSubscribersAsync();
    }
}