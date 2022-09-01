using Microsoft.EntityFrameworkCore;
using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess
{
    internal class AppContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<PlayerTrail> PlayerTrails => Set<PlayerTrail>();
        public DbSet<MemberTrail> MembersTrails => Set<MemberTrail>();
        public AppContext() => Database.EnsureCreated();
        public AppContext(string connectionString) : base(GetOptions(connectionString)) => Database.EnsureCreated();
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=helloapp.db");
        //}
    }
}
