using System;
using WebApplication5.Api.Exceptions;
using WebApplication5.Api.Interfaces;
using WebApplication5.Cards;

namespace WebApplication5.Api.Services
{
    public class RarityService
    {
        private readonly IRandomNumberProvider randomNumberProvider;

        public RarityService(IRandomNumberProvider randomNumberProvider)
        {
            this.randomNumberProvider = randomNumberProvider;
        }

        public Rarity PickRarity()
        {
            int randomNumber = randomNumberProvider.GenerateRandomNumber(1, 100);

            if (randomNumber <= 0 || randomNumber > 100)
                throw new GeneratedNumberOutOfRangeException(randomNumber);

            if (randomNumber <= 55)
                return Rarity.Common;
            else if (randomNumber <= 80)
                return Rarity.Uncommon;
            else if (randomNumber <= 95)
                return Rarity.Rare;
            else if (randomNumber <= 100)
                return Rarity.Epic;
            else
                throw new InvalidOperationException("Unreachable code reached.");
        }
    }
}
