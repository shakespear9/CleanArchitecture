using Application.Common.Interfaces;
using Domain.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<AppSetting>? AppSettings { get; set; }   

        public Task<int> SaveChangeAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
