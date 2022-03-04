using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PocoPanel.Domain.Entities;
using PocoPanel.Infrastructure.Persistence.Contexts;

namespace PocoPanel.Infrastructure.Persistence.Seeds
{
    public static class Defualt
    {
        public static async Task SeedAsync(ApplicationDbContext applicationDbContext)
        {

            //await applicationDbContext.AddRangeAsync(new List<tblBlaBla>()
            //{
            //});

            //await applicationDbContext.SaveChangesAsync();
        }
    }
}