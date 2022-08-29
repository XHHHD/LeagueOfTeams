using LeagueOfTeamsBusinessLogic.Models.Members;
using LeagueOfTeamsBusinessLogic.Interfaces;
using LeagueOfTeamsBusinessLogic.Models.Top;
using LeagueOfTeamsBusinessLogic.Models.DTO;
using LeagueOfTeamsBusinessLogic.Exceptions;
using System;
using System.Collections.Generic;

namespace LeagueOfTeamsBusinessLogic.Models.Teams
{
    internal class Team
    {
        private readonly int _teamID;
        private string _teamName = "";
        private string _teamShortName = "";
        private string _teamDescription = "There are no description here.";
        private uint _playerExpiriance = 0;
        private int _teamPower = 0;
        private int _teamHealth = 0;
        private int _teamCooperation = 0;
        private List<IMember> _members;
        private List<PlayerTrail> _playerTrails;

        public int TeamID { get => _teamID; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public string TeamDisplayName
        {
            get => _teamShortName;
            set
            {
                if (value == null) _teamShortName = _teamName;
                else _teamShortName = value;
            }
        }
        public string? TeamDescription
        {
            get => _teamDescription;
            set
            {
                if (value != null) _teamDescription = value;
            }
        }
        public List<IMember> Members { get => _members; }
        public List<PlayerTrail> PlayerTrails { get => _playerTrails; }
        public uint PlayerExpiriance { get => _playerExpiriance%1000; }
        public uint PlayerLevel { get => _playerExpiriance/1000 + 1; }
        public int TeamPower { get => _teamPower; }
        public int TeamHealth { get => _teamHealth; }
        public int TeamCooperation { get => _teamCooperation; }

        
        public Team(TeamRegistrationDTO newTeam)
        {
            _members = new List<IMember>();
            _playerTrails = new List<PlayerTrail>();
            if (newTeam.Name != null && TeamsTopManager.IsThisNamespaceFree(newTeam.Name)) _teamName = newTeam.Name;
            string teamShortName;
            if (newTeam.ShortName == null)
            {
                teamShortName = _teamName.Remove(2, _teamName.Length - 1).ToUpper();
                if (TeamsTopManager.IsThisNamespaceFree(teamShortName)) _teamName = teamShortName;
                else throw new TeamRegistrationException("Auto generated TeamShortName is already taken.");
            }
            else
            {
                if (TeamsTopManager.IsThisNamespaceFree(newTeam.ShortName)) _teamName = newTeam.ShortName.ToUpper();
                else throw new TeamRegistrationException("TeamShortName provided by User is already taken.");
            }
            if (newTeam.Description != null) _teamDescription = newTeam.Description;

        }
    }
}
