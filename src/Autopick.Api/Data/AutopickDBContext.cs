using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Autopick.Api.Data
{
    public class AutopickDBContext : DbContext
    {
        #region SQL Server
        public AutopickDBContext(DbContextOptions<AutopickDBContext> options)
            : base(options)
        {
        }
        #endregion

        #region SQLite
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(@"Data Source=..\..\db\Autopick.db");
        //}
        #endregion

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerOverall> PlayerOveralls { get; set; }
        public DbSet<PlayerSkillRating> PlayerRatings { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayerTeam> PlayersTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutopickDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
