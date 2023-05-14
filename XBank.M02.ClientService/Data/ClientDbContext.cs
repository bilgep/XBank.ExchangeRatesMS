using Microsoft.EntityFrameworkCore;
using XBank.M02.ClientService.Entities;

namespace XBank.M02.ClientService.Data
{
    public class ClientDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ClientDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(_configuration["ConnectionStrings:Sqlite"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(Seed.SeedClients);
            modelBuilder.Entity<Account>().HasData(Seed.SeedAccounts);
            modelBuilder.Entity<ClientAccounts>().HasData(Seed.SeedClientAccounts);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ClientAccounts> ClientAccounts { get; set; }

        
    }
}
