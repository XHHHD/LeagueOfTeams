using AutoMapper;
using LOT.BLL.Models.Members;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Members
{
    public class MemberService
    {
        private static readonly IMapper mapper;
        private static readonly MemberRepository repository = new();
        public static IEnumerable<MemberModel> GetAll()
        {
            if (repository.GetAllMembers() == null || repository.GetAllMembers().Count() == 0)
                return null;
            else
                return mapper.Map<IEnumerable<MemberModel>>(repository.GetAllMembers());
        }
        public static int GetFreeMemberId() =>
            repository.GetLast() != null ?
            ++repository.GetLast().Id
            : 1;
    }
}
