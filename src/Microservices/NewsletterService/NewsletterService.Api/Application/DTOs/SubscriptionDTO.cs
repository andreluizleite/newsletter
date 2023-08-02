using NewsletterService.Domain.AggregateModels.NewsletterAggregate;
using NewsletterService.Domain.AggregateModels.NewsletterDomain;

namespace NewsletterService.Api.Application.DTOs
{
    public enum HowHeardOptionDto
    {
        Advert = 1,
        WordOfMouth = 2,
        Other = 3
    }

    public class SubscriptionDTO
    {
        public string Email { get; set; }
        public HowHeardOptionDto HowHeardUs { get; set; }
        public string Reason { get; set; }
    }

    public static class SubscriptionDTOExtension
    {
        public static SubscriptionDTO ToDto(this Newsletter entity)
        {
            return new SubscriptionDTO
            {
                Email = entity.Email,
                HowHeardUs = entity.HowHeardUs.ToDto(),
                Reason = entity.Reason
            };
        }
    }

    public static class HowHeardUsOptionExtensions
    {
        public static HowHeardOptionDto ToDto(this HowHeardOption optionDto)
        {
            switch (optionDto)
            {
                case HowHeardOption.Advert:
                    return HowHeardOptionDto.Advert;
                case HowHeardOption.WordOfMouth:
                    return HowHeardOptionDto.WordOfMouth;
                case HowHeardOption.Other:
                    return HowHeardOptionDto.Other;
                default:
                    throw new ArgumentOutOfRangeException(nameof(optionDto), "Invalid HowHeardUsOptionDTO value.");
            }
        }
    }

}
