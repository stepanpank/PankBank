using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PANKBANK.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<CreditTablModel> CreditTablModels { get; set; }
        public DbSet<DepositTablModel> DepositTablModels { get; set; }
        public DbSet<GetAppli> GepApplis { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
