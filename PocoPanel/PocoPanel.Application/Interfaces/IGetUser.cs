using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PocoPanel.Application.DTOs.Account;
using PocoPanel.Domain.Entities;

namespace PocoPanel.Application.Interfaces
{
    public interface IGetUser
    {
        public Task<string> GetUserID(string ApiToken);
        public Task<GetUserProfile> GetUserByToken(string ApiToken);
        public Task<GetUserProfile> GetUserByPublicCode(string publicCode);
    }
}