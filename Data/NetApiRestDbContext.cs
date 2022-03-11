using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetApiRestExample.Models;

namespace NetApiRestExample.Data
{
    public class NetApiRestDbContext : DbContext
    {
        public NetApiRestDbContext (DbContextOptions<NetApiRestDbContext> options)
            : base(options)
        {
        }

        public DbSet<NetApiRestExample.Models.Book> Book { get; set; }
    }
}
