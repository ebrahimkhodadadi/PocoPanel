using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PocoPanel.Application.Interfaces;

namespace PocoPanel.Infrastructure.Shared.Services
{
    public class ConvertService : IConvert
    {
        public decimal RoundNumber(decimal number)
        {
            return Math.Round(number, MidpointRounding.AwayFromZero);
        }
    }
}