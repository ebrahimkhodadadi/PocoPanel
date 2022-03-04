using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanel.Application.Interfaces
{
    public interface IGetInfo
    {
        public Task<IEnumerable<tblCountry>> GetAllCountryAsync();
        public Task<tblPriceKind> GetPriceKindByCountryId(int countryId);
    }
}
