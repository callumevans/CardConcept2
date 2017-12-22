using System;
using WebApplication5.Api.Interfaces;

namespace WebApplication5.Api.Services
{
    public class RandomNumberService : IRandomNumberProvider
    {
        private readonly Random random = new Random(
            Environment.CurrentManagedThreadId);

        public int GenerateRandomNumber(int from, int to)
        {
            return random.Next(from, to + 1);
        }
    }
}