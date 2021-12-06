using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InlamningJeff;

namespace Web.Data
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext (DbContextOptions<SocialNetworkContext> options)
            : base(options)
        {
        }

        public DbSet<InlamningJeff.Post> Post { get; set; }
    }
}
