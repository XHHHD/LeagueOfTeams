using LOT.BLL.Models.Teams;
using LOT.DAL.Interfaces;

namespace LOT.BLL.Models.Ranks
{
    public class TeamRankModel : ITeamRank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeamModel> Teams { get; set; }
    }
}
