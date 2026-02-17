using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PATATAG_PINEZ_LOGIN.Models;

namespace PATATAG_PINEZ_LOGIN.Data
{
    // It acts as a bridge between your models and the database.
    public class PATATAG_PINEZ_LOGINContext : DbContext
    {
        // Constructor receives database configuration options
        public PATATAG_PINEZ_LOGINContext(
            DbContextOptions<PATATAG_PINEZ_LOGINContext> options)
            : base(options)
        {
        }

        // EF Core will create/manage this table based on the User model.
        public DbSet<User> User { get; set; } = default!;
    }
}