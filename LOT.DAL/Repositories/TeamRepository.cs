﻿using LOT.DAL.Entities;
using LOT.DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LOT.DAL.Repositories
{
    public class TeamRepository
    {
        AppContext _db;
        public TeamRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }

        /// <summary>
        /// Adding new team in data base.
        /// </summary>
        /// <param name="team">The entity Team, wich must be added.</param>
        public void Add(Team team)
        {
            _db.Teams.Add(team);
            _db.SaveChanges();
        }

        /// <summary>
        /// Update currently team in data base.
        /// </summary>
        /// <param name="team">The entity Team, wich must be updated.</param>
        public void UpdateTeam(Team team)
        {
            if (GetTeam(team.Id) is null)
                throw new TeamDataException("Didn`t find team for updating!");
            else
            {
                _db.Update(team);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Searcing in database entity`s of team rank and team bythey ID.
        /// Adding team entity in list of teams of the team rank entity.
        /// Save change`s and return refreshed team model.
        /// </summary>
        /// <param name="rankID">ID of team rank.</param>
        /// <param name="teamID">ID of team.</param>
        /// <returns>Actual team model.</returns>
        /// <exception cref="TeamDataException"></exception>
        public Team AddTeamInRank(int rankID, int teamID)
        {
            var rank = _db.TeamRanks.FirstOrDefault(r => r.Id == rankID);
            var team = _db.Teams.FirstOrDefault(t => t.Id == teamID);
            if (rank is null)
                throw new TeamDataException("Didn`t find rank in data!");
            else if (team is null)
                throw new TeamDataException("Didn`t find team in data!");
            else
            {
                //rank.Teams.Add(team);
                team.TeamRank = rank;
                _db.SaveChanges();
                return team;
            }
        }

        public Team AddMemberToTheTeam(int teamID, int memberID)
        {
            var team = GetTeam(teamID);
            var member = _db.Members.FirstOrDefault(m => m.Id == memberID);
            if (team is null)
                throw new TeamDataException("Didn`t find team in data!");
            else if (member is null)
                throw new TeamDataException("Didn`t find member in data!");
            else
            {
                team.Members.Add(member);
                _db.SaveChanges();
                return team;
            }
        }

        /// <summary>
        /// Remove currently team from data base.
        /// </summary>
        /// <param name="id">Id of the team, wich must be removed.</param>
        public void RemoveTeam(int id)
        {
            var teamToRemove = _db.Teams.FirstOrDefault(x => x.Id == id);
            if (teamToRemove != null)
            {
                _db.Teams.Remove(teamToRemove);
                _db.SaveChanges();
            }
            else
                throw new TeamDataException("Didn`t find currently team in data base, to remove.");
        }

        /// <summary>
        /// Remove currently team from data base.
        /// </summary>
        /// <param name="id">Id of the team, wich must be removed.</param>
        /// <exception cref="TeamDataException"></exception>
        public async void RemoveAsync(int id)
        {
            var teamToRemove = await _db.Teams.FindAsync(id);
            if (teamToRemove != null)
            {
                await Task.Run(() => _db.Teams.Remove(teamToRemove));
                _db.SaveChanges();
            }
            else
                throw new TeamDataException("Didn`t find currently team in data base, to remove.");
        }

        /// <summary>
        /// Get all teams from data base.
        /// </summary>
        /// <returns>Collection of the Teams entities.</returns>
        public IEnumerable<Team> GetAll() => _db.Teams;

        public bool IsThisNamespaceFree(string name)
        {
            //var searchingResult = _db.Teams.Select(n => n.Name).FirstOrDefault(name);
            var searchingResult = _db.Teams.FirstOrDefault(x => x.Name == name);
            string searchingResultName = "";
            if (searchingResult != null)
                searchingResultName = searchingResult.Name;
            if ( searchingResultName != null || searchingResultName == "")
                return false;
            else
                return true;
        }

        public bool IsThisShortNameFree(string shortName)
        {
            var searchingResult = _db.Teams.Select(n => n.ShortName).FirstOrDefault(shortName);
            if (searchingResult is null)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Get from data base team with currently Id.
        /// </summary>
        /// <param name="id">Id of the team you lookig for.</param>
        /// <returns>Entity Team.</returns>
        /// <exception cref="TeamDataException"></exception>
        public Team GetTeam(int id)
        {
            var team = _db.Teams.FirstOrDefault(t => t.Id == id);
            if (team != null)
                return team;
            else
                throw new TeamDataException("Didn`t find currently team.");
        }

        /// <summary>
        /// Find members from currently team.
        /// </summary>
        /// <param name="id">Id of the team, whose members are to be found.</param>
        /// <returns>Collection of the Members entities.</returns>
        public IEnumerable<Member> GetTeamMembers(int id) => _db.Members.Where(m => m.TeamId == id);
    }
}
