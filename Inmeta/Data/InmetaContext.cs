using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inmeta.Data;

namespace Inmeta.Models
{
    public class InmetaContext : DbContext
    {
        public InmetaContext (DbContextOptions<InmetaContext> options)
            : base(options)
        {
        }

        public DbSet<Inmeta.Data.Customer> Customer { get; set; }
    }
}
