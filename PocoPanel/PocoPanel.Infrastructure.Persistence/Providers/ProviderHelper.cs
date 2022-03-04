using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Infrastructure.Persistence.Providers
{
    public static class ProviderHelper
    {
        public static IProviderAsync GetProvider(tblProvider tblProvider)
        {
            switch (tblProvider.Code)
            {
                case "instatell": //Instatell
                    return new InstatellProviderAsync(tblProvider);
                    break;
            }

            return null;
        }
    }
}
