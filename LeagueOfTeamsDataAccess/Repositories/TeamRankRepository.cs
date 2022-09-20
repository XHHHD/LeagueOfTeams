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
    }
}
