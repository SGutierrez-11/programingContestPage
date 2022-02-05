#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using programingContestPage.Models;

namespace programingContestPage.Data
{
    public class programingContestPageContext : DbContext
    {
        public programingContestPageContext (DbContextOptions<programingContestPageContext> options)
            : base(options)
        {
        }

        public DbSet<programingContestPage.Models.User> User { get; set; }
    }
}
