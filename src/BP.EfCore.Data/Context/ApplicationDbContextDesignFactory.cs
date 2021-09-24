using Bp.EfCore.Data.Context;
using Microsoft.EntityFrameworkCore.Design;

namespace BP.EfCore.Data.Context
{
    public class ApplicationDbContextDesignFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var context = new ApplicationDbContext();
            return context;
        }
    }
}