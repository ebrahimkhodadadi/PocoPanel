using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PocoPanel.Application.Interfaces;

namespace PocoPanel.Infrastructure.Shared.Services
{
    public class ConvertService : IConvert
    {
        public decimal RoundNumber(decimal? number)
        {
            if (number.HasValue)
                return Math.Round(number.Value, MidpointRounding.AwayFromZero);
            else
                return 0;
        }
    }
}