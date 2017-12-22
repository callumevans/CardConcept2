using System;

namespace WebApplication5.Api.Exceptions
{
    public class GeneratedNumberOutOfRangeException : Exception
    {
        public GeneratedNumberOutOfRangeException(int number)
            : base($"Generated random number {number} is out of accepted range.")
        {
        }
    }
}
