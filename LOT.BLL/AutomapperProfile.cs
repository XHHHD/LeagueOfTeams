using LOT.DAL.Entities;
using LOT.BLL.Models;
using AutoMapper;
using LOT.BLL.Models.Teams;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Trails;
using LOT.BLL.Models.Ranks;
using LOT.BLL.Models.Positions;

namespace LOT.BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Team, TeamModel>().ReverseMap();
            CreateMap<Member, MemberModel>().ReverseMap();
            CreateMap<Position, PositionModel>().ReverseMap();
            CreateMap<TeamRank, TeamRankModel>().ReverseMap();
            CreateMap<TeamTrail, TeamTrailModel>().ReverseMap();
            CreateMap<MemberRank, MemberRankModel>().ReverseMap();
            CreateMap<MemberTrail, MemberTrailModel>().ReverseMap();
        }
    }
}
