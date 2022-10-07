using AutoMapper;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Teams;
using LOT.DAL.Entities;
using LOT.DAL.Interfaces;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Teams
{
    public class TeamService
    {
        private readonly IMapper mapper;
        private readonly TeamRepository repository = new();
        public TeamService()
        {
            mapper = MappingHelper.GetMapper();
        }
        public void AddTeam(TeamModel team)
        {
            if (team != null)
                repository.AddTeam(mapper.Map<Team>(team));
            else
                throw new TeamServicesException("Trying to create null team!");
        }
        public void UpdateTeame(TeamModel team)
        {
            if(team != null)
                repository.UpdateTeam(mapper.Map<Team>(team));
            else
                throw new TeamServicesException("Trying to update null team!");
        }
        public void RemoveTeam(TeamModel team)
        {
            if (repository.GetTeamById(team.Id) == null)
                throw new TeamServicesException("Removing team was failed! Can`t find current team in data.");
            else
                repository.RemoveTeam(mapper.Map<Team>(team));
        }
        public void RemoveTeamById(int id)
        {
            if(repository.GetTeamById(id) == null)
                throw new TeamServicesException("Removing team was failed! Can`t find current team in data.");
            else
                repository.RemoveTeamByIdAsync(id);
        }
        public TeamModel GetTeam(int id) => mapper.Map<TeamModel>(repository.GetTeamById(id));
        public IEnumerable<MemberModel> GetTeamMembers(int id) => mapper.Map<IEnumerable<MemberModel>>(repository.GetTeamMembers(id));
        public IEnumerable<TeamModel> GetAllTeams() => mapper.Map<IEnumerable<TeamModel>>(repository.GetAll());
    }
}
