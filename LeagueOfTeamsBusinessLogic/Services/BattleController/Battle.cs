using LeagueOfTeamsBusinessLogic.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfTeamsBusinessLogic.Services.BattleController
{
    internal static class Battle
    {
        /// <summary>
        /// Method checks if teams can play.
        /// </summary>
        /// <param name="firstTeam"></param>
        /// <param name="secondTeam"></param>
        /// <returns>TRUE if both teams has enaught energy to enjoy the match.</returns>
        public static bool CheckTeamsReadiness(Team firstTeam, Team secondTeam)
        {
            if (firstTeam.TeamEnergy > 50 && secondTeam.TeamEnergy > 50) return true;
            return false;
        }

    }
}
