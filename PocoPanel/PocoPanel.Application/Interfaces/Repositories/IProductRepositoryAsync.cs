using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanel.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<tblProduct>
    {
        public Task<bool> IsExistProductKindId(int tblProductKindId);
        public Task<bool> IsExistProviderId(int tblProviderId);
        
    }
}
