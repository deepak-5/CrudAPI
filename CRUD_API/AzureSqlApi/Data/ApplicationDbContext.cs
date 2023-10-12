// AzureSqlApi/Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using AzureSqlApi.Models;
using System.Collections.Generic;

namespace AzureSqlApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        // Add other DbSet properties for additional entities, if needed.
    }
}
