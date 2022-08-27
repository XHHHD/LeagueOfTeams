using LeagueOfTeamsModel.Models.Member;
using LeagueOfTeamsModel.Interfaces;
using System;

namespace LeagueOfTeamsModel.Models.Team
{
    internal class Team
    {
        private readonly int _teamID;
        private string _teamName = "";
        private string _teamDisplayName;
        private string? _teamDescription;
        private IMember[] _Members;
        private PlayerTrail[] _playerTrails;


        public int TeamId { get => _teamID; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public string TeamDisplayName { get => _teamDisplayName; set => _teamDisplayName = value; }
        public string? TeamDescription { get => _teamDescription; set => _teamDescription = value; }
        public IMember[] Members { get => _Members; }
        public PlayerTrail[] PlayerTrails { get => _playerTrails; }

    }
}
