using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess.Repositories
{
    public class PositionNameRepository
    {
        internal readonly List<string> positions = new() { "Topline", "Jungley", "Midline", "Botline", "Support" };
        public string GetCurrentlyPosition(int posotionIndex)
        {
            return positions[posotionIndex];
        }
    }
}
