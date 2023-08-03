using MediatR;
using Moq;
using NewsletterService.Api.Application.Commands;
using NewsletterService.Api.Application.DTOs;
using NewsletterService.Domain.AggregateModels.NewsletterAggregate;
using NewsletterService.Domain.AggregateModels.NewsletterDomain;
using NewsletterService.Domain.AggregateModels.SeedWork;
using Xunit;

namespace NewsletterService.UnitTests
{
    public class NewsletterServiceTests
    {
        [Fact]
        public async Task Handle_ValidRequest_AddsSubscriberAndReturnsTrue()
        {
            var mediatorMock = new Mock<IMediator>();
            var newsletterRepositoryMock = new Mock<INewsletterRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            newsletterRepositoryMock.Setup(repo => repo.IsEmailExist(It.IsAny<string>())).Returns(false);
            newsletterRepositoryMock.SetupGet(repo => repo.UnitOfWork).Returns(unitOfWorkMock.Object);

            var command = new SubscribeToNewsletterCommand
            {
                Email = "new@example.com",
                HowHeardUs = HowHeardOptionDto.Advert,
                Reason = "Test"
            };

            var handler = new SubscribeToNewsletterCommandHandler(mediatorMock.Object, newsletterRepositoryMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result, "The result should be true for a successful subscription.");
            newsletterRepositoryMock.Verify(repo => repo.Subscribe(It.IsAny<Newsletter>()), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveEntitiesAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Handle_EmailAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var newsletterRepositoryMock = new Mock<INewsletterRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            newsletterRepositoryMock.Setup(repo => repo.IsEmailExist(It.IsAny<string>())).Returns(true);
            newsletterRepositoryMock.SetupGet(repo => repo.UnitOfWork).Returns(unitOfWorkMock.Object);

            var existingEmail = "existing@example.com";
            var command = new SubscribeToNewsletterCommand
            {
                Email = existingEmail,
                HowHeardUs = HowHeardOptionDto.Advert,
                Reason = "Test"
            };

            var handler = new SubscribeToNewsletterCommandHandler(mediatorMock.Object, newsletterRepositoryMock.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await handler.Handle(command, CancellationToken.None);
            });

            Assert.NotEmpty(exception.Message);
            newsletterRepositoryMock.Verify(repo => repo.Subscribe(It.IsAny<Newsletter>()), Times.Never);
            unitOfWorkMock.Verify(uow => uow.SaveEntitiesAsync(CancellationToken.None), Times.Never);
        }
    }
}
