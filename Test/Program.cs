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
        var positionRepo = new PositionsNamesRepository();
        var playerTrailRepo = new PlayerTrailsRepository();
        var memberTrailRepo = new MembersTrailsRepository();

        var userFromDB = userRepo.GetAllUsers().FirstOrDefault();
        Console.WriteLine(userFromDB.Name);
        Console.WriteLine(userFromDB.Age);

        memberRepo.AddMember(new Member()
        {
            MemberNick = "Neo",
            MemberAge = 14,
            MemberEnergy = 100,
            MemberMaxEnergy = 100,
            MemberMainExpiriance = 0,
            MemberFreeMainSkillPoints = 0,
            CurrentlyMemberMainPositionId = positionRepo.GetCurrentlyPosition(1),
            MemberPositionsId = new List<PositionsNames> { positionRepo.GetCurrentlyPosition(1) }

        });
        var member = memberRepo.GetAllMembers().FirstOrDefault();
        Console.WriteLine(member.Id);
        Console.WriteLine(member.MemberNick);
        Console.WriteLine(member.MemberAge);
    }
}