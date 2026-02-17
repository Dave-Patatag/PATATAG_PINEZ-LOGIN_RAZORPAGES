using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PATATAG_PINEZ_LOGIN.Models;

namespace PATATAG_PINEZ_LOGIN.Data
{
    public class DELACERNA_LOMERA_LAB_ACT_3_PROEL4W1Context : DbContext
    {
        public DELACERNA_LOMERA_LAB_ACT_3_PROEL4W1Context(
            DbContextOptions<DELACERNA_LOMERA_LAB_ACT_3_PROEL4W1Context> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;
    }
}
