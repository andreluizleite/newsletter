using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NewsletterService.Domain.AggregateModels.NewsletterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterService.Infrastructure.EntityConfigurations
{
    public class NewsletterEntityTypeConfiguration : IEntityTypeConfiguration<Newsletter>
    {
        public void Configure(EntityTypeBuilder<Newsletter> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Email).HasMaxLength(100).IsRequired();

            builder.HasIndex(n => n.Email).IsUnique();
            builder.Property(n => n.HowHeardUs)
                   .HasConversion<int>();
        }
    }
}
