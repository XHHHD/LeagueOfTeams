using LOT.DAL.Interfaces;

namespace LOT.DAL.Entities
{
    public class TeamRank : ITeamRank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}
