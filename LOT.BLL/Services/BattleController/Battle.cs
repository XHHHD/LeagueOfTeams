using LOT.BLL.Models.Teams;

namespace LOT.BLL.Services.BattleController
{
    internal static class Battle
    {
        /// <summary>
        /// Method checks if teams can play.
        /// </summary>
        /// <param name="firstTeam"></param>
        /// <param name="secondTeam"></param>
        /// <returns>TRUE if both teams has enaught energy to enjoy the match.</returns>
        public static bool CheckTeamsReadiness(TeamModel firstTeam, TeamModel secondTeam)
        {
            if (firstTeam.Energy > 50 && secondTeam.Energy > 50) return true;
            return false;
        }
    }
}
