using WebApplication5.Api.Services;
using WebApplication5.Cards;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class CardBuilderService
    {
        private readonly RarityService rarityService;
        private readonly UniversalDateTimeService universalDateTimeService;

        public CardBuilderService(
            RarityService rarityService,
            UniversalDateTimeService universalDateTimeService)
        {
            this.rarityService = rarityService;
            this.universalDateTimeService = universalDateTimeService;
        }

        public Card GenerateCard(Faction faction)
        {
            return new Card
            {
                Rarity = rarityService.PickRarity(),
                Faction = faction,
                Created = universalDateTimeService.GetUtcDateTime()
            };
        }
    }
}