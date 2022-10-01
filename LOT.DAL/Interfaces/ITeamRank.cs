using LOT.DAL.Entities;

namespace LOT.DAL.Interfaces
{
    public interface ITeamRank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Team> Teams { get; set; }
    }
}
