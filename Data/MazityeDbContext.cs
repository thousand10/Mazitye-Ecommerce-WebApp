using System;
using Microsoft.EntityFrameworkCore;
using mazitye.Models;

namespace mazitye.Data
{
    public class MazityeDbContext: DbContext
    {
        public MazityeDbContext(DbContextOptions<MazityeDbContext> opt): base(opt)
        {
            
        }

        public DbSet<Product> products { get;set; }
    }
}