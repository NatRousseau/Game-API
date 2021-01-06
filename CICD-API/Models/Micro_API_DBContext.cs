using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CICD_API.Models
{
    public class Micro_API_DBContext : DbContext
    {
        public Micro_API_DBContext(DbContextOptions<Micro_API_DBContext> options)
            : base(options)
        {
        }

        protected Micro_API_DBContext()
        {
        }
        
        public DbSet<Game> Games { get; set; }
    }
}