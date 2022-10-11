using AutoMapper;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Teams;
using LOT.DAL.Entities;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Teams
{
    public static class TeamService
    {
        private static readonly IMapper mapper;
        private static readonly TeamRepository repository = new();
        public static void AddTeam(TeamModel team)
        {
            if (team != null)
                repository.Add(mapper.Map<Team>(team));
            else
                throw new TeamServicesException("Trying to create null team!");
        }
        public static void UpdateTeame(TeamModel team)
        {
            if(team != null)
                repository.UpdateTeam(mapper.Map<Team>(team));
            else
                throw new TeamServicesException("Trying to update null team!");
        }
        public static void RemoveTeam(int id)
        {
            var teamToRemove = repository.GetTeam(id);
            if (teamToRemove == null)
                throw new TeamServicesException("Removing team was failed! Can`t find current team in data.");
            else
                repository.RemoveTeam(teamToRemove.Id);
        }
        public static void RemoveTeamById(int id)
        {
            if(repository.GetTeam(id) == null)
                throw new TeamServicesException("Removing team was failed! Can`t find current team in data.");
            else
                repository.RemoveAsync(id);
        }
        public static TeamModel GetTeam(int id) =>
            mapper.Map<TeamModel>(repository.GetTeam(id));
        public static IEnumerable<MemberModel> GetTeamMembers(int id) =>
            mapper.Map<IEnumerable<MemberModel>>(repository.GetTeamMembers(id));
        public static IEnumerable<TeamModel> GetAllTeams() =>
            mapper.Map<IEnumerable<TeamModel>>(repository.GetAll());
    }
}
