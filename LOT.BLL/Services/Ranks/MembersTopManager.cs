using AutoMapper;
using LOT.BLL.Models.Members;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Ranks
{
    internal static class MembersTopManager
    {
        private static readonly IMapper mapper;
        private static readonly MemberRepository repository = new();

        /// <summary>
        /// Get collection of members with highest rank.
        /// </summary>
        /// <returns>Members list or EMPTY members list.</returns>
        public static List<MemberModel> GetMembersTop()
        {
            var allMembers = repository.GetAll();
            if (allMembers == null)
                return new List<MemberModel>();
            else
            {
                var membersTop = mapper.Map<List<MemberModel>>(allMembers);
                membersTop.OrderBy(x => x.RankPoints).ToList();
                return membersTop;
            }
        }

        /// <summary>
        /// Get currently count collection of members with highest rank.
        /// Careful - list can be smaller than expected size!
        /// </summary>
        /// <param name="topCount">Size of collection.</param>
        /// <returns>Members list or EMPTY members list.</returns>
        public static List<MemberModel> GetMembersTop(int topCount)
        {
            var members = GetMembersTop();
            members.RemoveRange(topCount,members.Count);
            return members;
        }
    }
}
