using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanel.Application.Interfaces
{
    public interface IConvert
    {
        public decimal RoundNumber(decimal? number);
    }
}