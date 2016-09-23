using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FamilyHelper.Data
{
    public class TemporaryDbContextFactory : IDbContextFactory<FamilyHelperContext>
    {
        public FamilyHelperContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<FamilyHelperContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FamilyHelper;Trusted_Connection=True;");
            return new FamilyHelperContext(builder.Options);
        }
    }
}
