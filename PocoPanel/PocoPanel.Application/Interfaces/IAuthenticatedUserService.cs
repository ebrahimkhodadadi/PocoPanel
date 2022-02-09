using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        string Currency { get; }
    }
}
