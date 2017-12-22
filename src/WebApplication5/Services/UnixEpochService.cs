using System;
using WebApplication5.Api.Interfaces;

namespace WebApplication5.Api.Services
{
    public class UnixEpochService : IUnixEpochProvider
    {
        public long GetUnixEpoch()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}