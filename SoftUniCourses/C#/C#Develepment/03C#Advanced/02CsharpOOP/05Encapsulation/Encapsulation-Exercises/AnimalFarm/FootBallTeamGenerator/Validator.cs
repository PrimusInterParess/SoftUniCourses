using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallTeamGenerator
{
    public class Validator
    {
        public static void ThrowIfNameIsInvalid(string value, string massege)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException(massege);
            }
        }

        public static void ThrowIfStatsIsInvalid(int value, int min, int max, string massage)
        {
            if (value < min || value > max)
            {
                throw new InvalidOperationException(massage);
            }

        }
    }
}
