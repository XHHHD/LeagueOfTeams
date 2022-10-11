using AutoMapper;
using LOT.BLL.Models.Members;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Members
{
    public class MemberService
    {
        private static readonly IMapper mapper;
        private static readonly MemberRepository repository = new();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return members collection or NULL.</returns>
        public static IEnumerable<MemberModel> GetAll()
        {
            if (repository.GetAll() == null || repository.GetAll().Count() == 0)
                return null;
            else
                return mapper.Map<IEnumerable<MemberModel>>(repository.GetAll());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns>Return members collection by currently team or NULL.</returns>
        public static IEnumerable<MemberModel> GetMembersOfTeam(int teamId)
        {
            if (repository.GetMembersByTeam(teamId) == null || repository.GetMembersByTeam(teamId).Count() == 0)
                return null;
            else
                return mapper.Map<IEnumerable<MemberModel>>(repository.GetMembersByTeam(teamId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return member from data or NULL.</returns>
        public static MemberModel GetMember(int id)
        {
            if (repository.GetMemberById(id) == null)
                return null;
            else
                return mapper.Map<MemberModel>(repository.GetMemberById(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return free id to use, starting from 1.</returns>
        public static int GetFreeMemberId() =>
            repository.GetLast() != null ?
            ++repository.GetLast().Id
            : 1;
    }
}
