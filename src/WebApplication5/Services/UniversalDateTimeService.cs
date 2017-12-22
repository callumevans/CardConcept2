using System;
using WebApplication5.Api.Interfaces;

namespace WebApplication5.Api.Services
{
    public class UniversalDateTimeService
    {
        private readonly IUnixEpochProvider unixEpochProvider;

        public UniversalDateTimeService(IUnixEpochProvider unixEpochProvider)
        {
            this.unixEpochProvider = unixEpochProvider;
        }

        public DateTime GetUtcDateTime()
        {
            return DateTimeOffset.FromUnixTimeSeconds(
                unixEpochProvider.GetUnixEpoch()).DateTime.ToUniversalTime();
        }
    }
}
