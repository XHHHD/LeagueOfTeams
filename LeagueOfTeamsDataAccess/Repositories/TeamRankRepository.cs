using LeagueOfTeamsDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfTeamsDataAccess.Repositories
{
    public class TeamRankRepository
    {
        AppContext _db;
        public TeamRankRepository()
        {
            string dbConnectionString = "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }
        public void AddNewRank(TeamRank newRank)
        {
            _db.TeamRanks.Add(newRank);
            _db.SaveChanges();
        }
        public void RemoveRank(TeamRank rank)
        {
            _db?.TeamRanks.Remove(rank);
            _db?.SaveChanges();
        }
        public List<TeamRank> GetAllTeamRanks() => _db.TeamRanks.ToList();
    }
}
