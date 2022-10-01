using Microsoft.EntityFrameworkCore;
using LOT.DAL.Entities;

namespace LOT.DAL
{
    internal class AppContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<TeamRank> TeamRanks => Set<TeamRank>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<MemberRank> MembersRanks => Set<MemberRank>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<TeamTrail> TeamTrails => Set<TeamTrail>();
        public DbSet<MemberTrail> MembersTrails => Set<MemberTrail>();
        public AppContext()
        {
            Database.EnsureCreated();
        }
        public AppContext(string connectionString) : base(GetOptions(connectionString)) => Database.EnsureCreated();
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>()
                .HasOne(m => m.Member)
                .WithMany(p => p.Positions);
            modelBuilder.Entity<Member>()
                .HasOne(tr => tr.MemberTrail)
                .WithMany(m => m.Member);
            modelBuilder.Entity<Member>()
                .HasOne(r => r.MemberRank)
                .WithMany(m => m.Members);
            modelBuilder.Entity<Member>()
                .HasOne(t => t.Team)
                .WithMany(m => m.Members);
            modelBuilder.Entity<Team>()
                .HasOne(tr => tr.TeamTrail)
                .WithMany(t => t.Teams);
            modelBuilder.Entity<Team>()
                .HasOne(r => r.TeamRank)
                .WithMany(t => t.Teams);
            modelBuilder.Entity<User>()
                .HasOne(t => t.Team)
                .WithOne(u => u.User);
        }
    }
}
