using AutoMapper;
using LOT.BLL.Models.Teams;
using LOT.DAL.Entities;
using LOT.DAL.Interfaces;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Teams
{
    public class TeamService
    {
        private readonly IMapper mapper;
        private readonly TeamRepository repo = new();
        public TeamService()
        {
            mapper = MappingHelper.GetMapper();
        }
        public TeamModel Get(int id) => mapper.Map<TeamModel>(repo.GetTeamById(id));
    }
}
