using LeagueOfTeamsDataAccess.Entities;
using LeagueOfTeamsDataAccess.Repositories;
using LeagueOfTeamsDataAccess.Interfaces;
using LeagueOfTeamsDataAccess;
internal class Program
{
    private static void Main(string[] args)
    {
        var userRepo = new UserRepository();
        var memberRepo = new MemberRepository();
        var teamRepo = new TeamRepository();
        var positionRepo = new PositionRepository();
        var playerTrailRepo = new PlayerTrailsRepository();
        var memberTrailRepo = new MembersTrailsRepository();

        var userFromDB = userRepo.GetAllUsers().FirstOrDefault();
        Console.WriteLine(userFromDB.Name);
        Console.WriteLine(userFromDB.Age);

        memberRepo.AddMember(new Member()
        {
            _memberNick = "Neo",
            _memberAge = 14,
            _memberEnergy = 100,
            _memberMaxEnergy = 100,
            _memberMainExpiriance = 0,
            _memberFreeMainSkillPoints = 0,
            _currentlyMemberMainPosition = positionRepo.GetCurrentlyPosition(1),
            _memberPositions = new List<Position> { positionRepo.GetCurrentlyPosition(1) }

        });
        var member = memberRepo.GetAllMembers().FirstOrDefault();
        Console.WriteLine(member.Id);
        Console.WriteLine(member._memberNick);
        Console.WriteLine(member._memberAge);
    }
}