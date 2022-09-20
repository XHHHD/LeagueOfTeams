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
        var positionRepo = new PositionNameRepository();
        var playerTrailRepo = new TeamsTrailsRepository();
        var memberTrailRepo = new MembersTrailsRepository();

        var userFromDB = userRepo.GetAllUsers().FirstOrDefault();
        Console.WriteLine(userFromDB.Name);
        Console.WriteLine(userFromDB.Password);

        memberRepo.AddMember(new Member()
        {
            Name = "Neo",
            Age = 14,
            Energy = 100,
            MaxEnergy = 100,
            Expiriance = 0,
            FreeSkillPoints = 0,
            MainPosition = positionRepo.GetCurrentlyPosition(1),
            MemberPositionsId = new List<PositionsNames> { positionRepo.GetCurrentlyPosition(1) }

        });
        var member = memberRepo.GetAllMembers().FirstOrDefault();
        Console.WriteLine(member.Id);
        Console.WriteLine(member.Name);
        Console.WriteLine(member.Age);
    }
}