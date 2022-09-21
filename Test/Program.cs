using LeagueOfTeamsDataAccess.Entities;
using LeagueOfTeamsDataAccess.Repositories;
using LeagueOfTeamsDataAccess.Interfaces;
using LeagueOfTeamsDataAccess;
internal class Program
{
    private static void Main(string[] args)
    {
        var userRepo = new UserRepository();
        var teamRepo = new TeamRepository();
        var memberRepo = new MemberRepository();
        var positionRepo = new PositionRepository();
        var positionNameRepo = new PositionNameRepository();
        var teamsTrailsRepo = new TeamsTrailsRepository();
        var memberTrailRepo = new MembersTrailsRepository();
        var teamRankRepo = new TeamRankRepository();
        var memberRankRepo = new MemberRankRepository();



        //check users repo
        Console.WriteLine("\n\n\n           //check users repo");
        Console.WriteLine("adding");
        userRepo.AddUser(new User() { Name = "Adm", Password = "123" });
        Console.WriteLine("up from db");
        var userFromDB = userRepo.GetAllUsers().FirstOrDefault();
        Console.WriteLine("show result");
        if (userFromDB != null)
        {
            Console.WriteLine(userFromDB.Name);
            Console.WriteLine(userFromDB.Password);
            Console.WriteLine("successful");
        }
        else
            Console.WriteLine("failed");
        for (int i = 0; i < 10; i++) Console.Write("_");



        //check teams rank repo
        Console.WriteLine("\n\n\n           //check teams rank repo");
        Console.WriteLine("adding");
        teamRankRepo.AddNewRank(new TeamRank()
        {
            Name = "Dung 5"
        });
        Console.WriteLine("up from db");
        var teamRankFromDB = teamRankRepo.GetAllTeamRanks().FirstOrDefault();
        Console.WriteLine("show result");
        if (teamRankFromDB != null)
        {
            Console.WriteLine(teamRankFromDB.Name);
            Console.WriteLine("successful");
        }
        else Console.WriteLine("failed");
        for (int i = 0; i < 10; i++) Console.Write("_");



        //check team trails repo
        Console.WriteLine("\n\n\n           //check teams trails repo");
        Console.WriteLine("adding");
        teamsTrailsRepo.AddNewTrail(new TeamTrail()
        {
            Name = "Traitors",
            Description = "They use every chanse thay have, to trait u!"
        });
        for (int i = 0; i < 10; i++) Console.Write("_");



        //check member rank repo
        Console.WriteLine("\n\n\n           //check member rank repo");
        Console.WriteLine("adding");
        memberRankRepo.AddNewRank(new MemberRank()
        {
            Name = "Garbage 5"
        });
        Console.WriteLine("up from db");
        var memberRankFromDB = memberRankRepo.GetAllRanks().FirstOrDefault();
        Console.WriteLine("show result");
        if (memberRankFromDB != null)
        {
            Console.WriteLine(memberRankFromDB.Name);
            Console.WriteLine("successful");
        }
        else Console.WriteLine("failed");
        for (int i = 0; i < 10; i++) Console.Write("_");



        //check member trail repo
        Console.WriteLine("\n\n\n           //check member trail repo");
        Console.Write("adding  with");
        memberTrailRepo.AddMemberTrail(new MemberTrail()
        {
            Name = "Jerk",
            Description = "Member is a jerk"
        });
        Console.WriteLine("up from db");
        var memberTrailFromDB = memberTrailRepo.GetAllMembersTrails().FirstOrDefault();
        Console.WriteLine("show result");
        if (memberTrailFromDB != null)
        {
            Console.WriteLine(memberTrailFromDB.Id + "\n" + memberTrailFromDB.Name + "\n" + memberTrailFromDB.Description);
            Console.WriteLine("successful");
        }
        else Console.WriteLine("failed");
        for (int i = 0; i < 10; i++) Console.Write("_");



        //check member repo
        Console.WriteLine("\n\n\n           //check member repo");
        Console.Write("adding with");
        if (memberRankFromDB != null)
        {
            Console.WriteLine(" member rank");
            memberRepo.AddMember(new Member()
            {
                Name = "Neo",
                Age = 14,
                Energy = 100,
                MaxEnergy = 100,
                Expiriance = 0,
                FreeSkillPoints = 0,
                RankPoints = 0,
                CreationDate = DateTime.Now,
                LastChanges = DateTime.Now,
                MemberRank = memberRankFromDB
            });
        }
        else
        {
            Console.WriteLine("out member rank");
            memberRepo.AddMember(new Member()
            {
                Name = "Neo",
                Age = 14,
                Energy = 100,
                MaxEnergy = 100,
                Expiriance = 0,
                FreeSkillPoints = 0,
                RankPoints = 0,
                CreationDate= DateTime.Now,
                LastChanges= DateTime.Now
            });
        }
        Console.WriteLine("up from db");
        var memberFromDB = memberRepo.GetAllMembers().FirstOrDefault();
        Console.WriteLine("show result");
        if (memberFromDB != null)
        {
            Console.WriteLine(memberFromDB.Id);
            Console.WriteLine(memberFromDB.Name);
            Console.WriteLine(memberFromDB.Age);
            Console.WriteLine("successful");
        }
        else Console.WriteLine("failed");
        for (int i = 0; i < 10; i++) Console.Write("_");



        //check position name repo
        Console.WriteLine("\n\n\n           //check position name repo");
        for (int i = 0; i < 5; i++) Console.WriteLine(positionNameRepo.GetCurrentlyPosition(i) + "\n");
        Console.WriteLine("successful");
        for (int i = 0; i < 10; i++) Console.Write("_");



        //check position repo
        Console.WriteLine("\n\n\n           //check position repo");
        Console.Write("adding with");
        if (memberFromDB != null)
        {
            Console.WriteLine(" member");
            positionRepo.AddPosition(new Position()
            {
                Name = positionNameRepo.GetCurrentlyPosition(0),
                Expiriance = 0,
                Level = 1,
                Rank = 999,
                Power = 0,
                Favorite = 0,
                Defence = 0,
                Health = 0,
                Member = memberFromDB
            });
        }
        else
        {
            Console.WriteLine("out member");
            positionRepo.AddPosition(new Position()
            {
                Name = positionNameRepo.GetCurrentlyPosition(0),
                Expiriance = 0,
                Level = 1,
                Rank = 999,
                Power = 0,
                Favorite = 0,
                Defence = 0,
                Health = 0
            });
        }
        Console.WriteLine("up from db");
        var positionFromDB = positionRepo.GetAllPositions().FirstOrDefault();
        Console.WriteLine("show result");
        if (positionFromDB != null)
        {
            Console.WriteLine("Name " + positionFromDB.Name + "\nExpiriance " + positionFromDB.Expiriance + "\nLevel " +
            positionFromDB.Level + "\nRank " + positionFromDB.Rank + "\n Power " + positionFromDB.Power + "\nFavorite " +
            positionFromDB.Favorite + "\nDefence " + positionFromDB.Defence + "\nHealth " + positionFromDB.Health);
            Console.WriteLine("successful");
        }
        else Console.WriteLine("failed");
        for (int i = 0; i < 10; i++) Console.Write("_");



        //check teams repo
        Console.WriteLine("\n\n\n           //check repo");
        Console.Write("adding with");
        if(teamRankFromDB != null)
        {
            Console.WriteLine(" team rank");
            teamRepo.AddTeam(new Team()
            {
                Name = "Losers",
                ShortName = "LOS",
                Description = "Born to lose!",
                Expiriance = 0,
                Energy = 0,
                Power = 0,
                Health = 0,
                Teamplay = 0,
                LeaguePoints = 0,
                TeamRank = teamRankFromDB
            });
        }
        else
        {
            Console.WriteLine("out team rank");
            teamRepo.AddTeam(new Team()
            {
                Name = "Losers",
                ShortName = "LOS",
                Description = "Born to lose!",
                Expiriance = 0,
                Energy = 0,
                Power = 0,
                Health = 0,
                Teamplay = 0,
                LeaguePoints = 0
            });
        }
        Console.WriteLine("up from db");
        var teamFromDb = teamRepo.GetAllTeams().FirstOrDefault();
        Console.WriteLine("show result");
        if (teamFromDb != null)
        {
            Console.WriteLine(teamFromDb.Name + "\n" + teamFromDb.Description);
            Console.WriteLine("successful");
        }
        else Console.WriteLine("failed");
        for (int i = 0; i < 10; i++) Console.Write("_");
    }
}