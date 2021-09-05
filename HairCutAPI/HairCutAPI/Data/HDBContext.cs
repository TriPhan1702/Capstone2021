using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCutAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HairCutAPI.Data
{
    public class HDBContext : DbContext
    {
        public HDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
