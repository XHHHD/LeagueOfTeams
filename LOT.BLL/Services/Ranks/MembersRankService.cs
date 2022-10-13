using AutoMapper;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Ranks;
using LOT.DAL.Entities;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Ranks
{
    internal static class MembersRankService
    {
        private static readonly IMapper mapper;
        private static readonly MemberRankRepository rankRepo = new();
        private static readonly MemberRepository memberRepo = new();

        public static void Add(MemberRankModel rankModel) => rankRepo.Add(mapper.Map<MemberRank>(rankModel));
        public static void Remove(MemberRankModel rankModel) => rankRepo.Remove(rankModel.Id);
        public static void Update(MemberRankModel rankModel) => rankRepo.Update(mapper.Map<MemberRank>(rankModel));

        /// <summary>
        /// Get Member rank model by ID.
        /// </summary>
        /// <param name="id">Member rank ID.</param>
        /// <returns>MemberRankModel.</returns>
        /// <exception cref="MemberRankServicesException"></exception>
        public static MemberRankModel GetRank(int id)
        {
            var entity = rankRepo.GetRank(id);
            if (entity is null)
                throw new MemberRankServicesException("There is no member rank with this ID in database!");
            else
                return mapper.Map<MemberRankModel>(entity);
        }

        /// <summary>
        /// Get member rank model by name.
        /// </summary>
        /// <param name="name">Member rank name.</param>
        /// <returns>MemberRankModel.</returns>
        /// <exception cref="MemberRankServicesException"></exception>
        public static MemberRankModel GetRank(string name)
        {
            var entity = rankRepo.GetRank(name);
            if (entity is null)
                throw new MemberRankServicesException("There is no team rank with this name in database!");
            else
                return mapper.Map<MemberRankModel>(entity);
        }

        /// <summary>
        /// Get all member ranks from database.
        /// </summary>
        /// <returns>MemberRanks collection.</returns>
        /// <exception cref="MemberRankServicesException"></exception>
        public static IEnumerable<MemberRankModel> GetAllRanks()
        {
            var allRanks = rankRepo.GetAll();
            if (allRanks != null)
            {
                var rankModels = mapper.Map<IEnumerable<MemberRankModel>>(allRanks);
                return rankModels;
            }
            else
                throw new MemberRankServicesException("MemberRanks data is empty!");
        }

        /// <summary>
        /// Get collection of members with highest rank.
        /// </summary>
        /// <returns>Members list or EMPTY members list.</returns>
        public static List<MemberModel> GetMembersTop()
        {
            var allMembers = memberRepo.GetAll();
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
