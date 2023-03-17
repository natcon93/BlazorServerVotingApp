using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlazorServerVotingApp.Models;

namespace BlazorServerVotingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<Poll> Poll { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<PollVote> PollVote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
                optionsBuilder
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
                .LogTo(x => System.Diagnostics.Debug.WriteLine(x));
            }
        }
    }
}