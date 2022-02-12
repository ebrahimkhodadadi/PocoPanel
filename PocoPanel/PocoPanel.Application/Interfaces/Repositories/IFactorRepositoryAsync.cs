using System.Collections;
using PocoPanel.Application.DTOs.Account;
using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PocoPanel.Application.Features.Factors.Commands.CreateFactor;
using PocoPanel.Application.Wrappers;

namespace PocoPanel.Application.Interfaces.Repositories
{
    public interface IFactorRepositoryAsync
    {
        public Task<tblOrder> CreateFactor(CreateFactorCommand CreateFactorCommand);
        public Task<bool> IsExistProductId(int ServiceId);
        public Task<Response<bool>> AcceptFactor(int orderDetailID);
        public Task<Response<bool>> RejectFactor(int orderDetailID, string reason);
    }
}
