using Microsoft.EntityFrameworkCore;
using MlgStore.WebUI.Models.Entities;

namespace MlgStore.WebUI.Models.Contexts
{
    public class MlgStoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-NU8CUCN;database=ConsumerDb;trusted_connection=true;");
        }

        public DbSet<UsersAdmin> UsersAdmins { get; set; }




    }
}
