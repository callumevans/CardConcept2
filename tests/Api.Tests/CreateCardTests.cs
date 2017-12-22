using Moq;
using System;
using WebApplication5.Api.Exceptions;
using WebApplication5.Api.Interfaces;
using WebApplication5.Api.Services;
using WebApplication5.Cards;
using WebApplication5.Models;
using WebApplication5.Services;
using Xunit;

namespace Api.Tests
{
    public class CreateCardTests
    {
        private Mock<IRandomNumberProvider> randomNumberProviderMock = new Mock<IRandomNumberProvider>();
        private Mock<IUnixEpochProvider> unixEpochProviderMock = new Mock<IUnixEpochProvider>();

        private RarityService rarityService;
        private UniversalDateTimeService universalDateTimeService;
        private CardBuilderService cardBuilderService;

        public CreateCardTests()
        {
            randomNumberProviderMock
                .Setup(x => x.GenerateRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(50);

            rarityService = new RarityService(randomNumberProviderMock.Object);
            universalDateTimeService = new UniversalDateTimeService(unixEpochProviderMock.Object);
            cardBuilderService = new CardBuilderService(rarityService, universalDateTimeService);
        }

        [Fact]
        public void GenerateCard_ReturnsACard()
        {
            // Act
            Card output = cardBuilderService.GenerateCard(Faction.Evil);

            // Assert
            Assert.NotNull(output);
        }

        [Theory]
        [InlineData(Faction.Good)]
        [InlineData(Faction.Evil)]
        public void GenerateCard_ReturnsCardWithSpecifiedFaction(Faction faction)
        {
            // Act
            Card output = cardBuilderService.GenerateCard(faction);

            // Assert
            Assert.Equal(faction, output.Faction);
        }

        [Theory]
        [InlineData(1, Rarity.Common)]
        [InlineData(55, Rarity.Common)]
        [InlineData(56, Rarity.Uncommon)]
        [InlineData(80, Rarity.Uncommon)]
        [InlineData(81, Rarity.Rare)]
        [InlineData(95, Rarity.Rare)]
        [InlineData(96, Rarity.Epic)]
        [InlineData(100, Rarity.Epic)]
        public void GenerateCard_ReturnsCardWithRarityDependingOnChance(int randomNumber, Rarity expectedRarity)
        {
            // Arrange
            randomNumberProviderMock
                .Setup(x => x.GenerateRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(randomNumber);

            // Act
            Card output = cardBuilderService.GenerateCard(Faction.Evil);

            // Assert
            Assert.Equal(expectedRarity, output.Rarity);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(101)]
        public void GenerateCard_OutOfRangeRandomNumber_ThrowException(int randomNumber)
        {
            // Arrange
            randomNumberProviderMock
                .Setup(x => x.GenerateRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(randomNumber);

            // Act + Assert
            Assert.Throws<GeneratedNumberOutOfRangeException>(
                () => cardBuilderService.GenerateCard(Faction.Evil));
        }

        [Fact]
        public void GenerateCard_ReturnsCardWithCurrentDateTime()
        {
            // Arrange
            var date = new DateTime(1992, 10, 27);
            long epoch = 720144000;

            unixEpochProviderMock
                .Setup(x => x.GetUnixEpoch())
                .Returns(epoch);

            // Act
            Card output = cardBuilderService.GenerateCard(Faction.Evil);

            // Assert
            Assert.Equal(date, output.Created);
        }
    }
}
