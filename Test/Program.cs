using LOT.DAL.Entities;
using LOT.DAL.Repositories;
using LOT.DAL.Interfaces;
using LOT.DAL;
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
        Console.WriteLine("\n\n\n           ======check users repo======");
        Console.WriteLine("---adding");
        userRepo.AddUser(new User()
        {
            Name = "Adm",
            Password = "123"
        });
        Console.WriteLine("---up from db");
        var userFromDB = userRepo.GetAllUsers().FirstOrDefault();
        Console.WriteLine("---show result");
        if (userFromDB != null)
        {
            Console.WriteLine(userFromDB.Name);
            Console.WriteLine(userFromDB.Password);
            Console.WriteLine("+++successful");
        }
        else
            Console.WriteLine("---failed");
        for (int i = 0; i < 20; i++) Console.Write("_");



        //check teams rank repo
        Console.WriteLine("\n\n\n           ======check teams rank repo======");
        Console.WriteLine("---adding");
        teamRankRepo.Add(new TeamRank()
        {
            Name = "Dung 5"
        });
        Console.WriteLine("---up from db");
        var teamRankFromDB = teamRankRepo.GetAll().FirstOrDefault();
        Console.WriteLine("---show result");
        if (teamRankFromDB != null)
        {
            Console.WriteLine(teamRankFromDB.Name);
            Console.WriteLine("+++successful");
        }
        else Console.WriteLine("---failed");
        for (int i = 0; i < 20; i++) Console.Write("_");



        //check team trails repo
        Console.WriteLine("\n\n\n           ======check teams trails repo======");
        Console.WriteLine("---adding");
        teamsTrailsRepo.AddNewTrail(new TeamTrail()
        {
            Name = "Traitors",
            Description = "They use every chanse thay have, to trait u!"
        });
        Console.WriteLine("---up from db");
        var teamTrailFromDB = teamsTrailsRepo.GetAllTrails().FirstOrDefault();
        if (teamTrailFromDB != null)
        {
            Console.WriteLine(teamTrailFromDB.Name + "\n" + teamTrailFromDB.Description);
            Console.WriteLine("+++successful");
        }
        else Console.WriteLine("---failed");
        for (int i = 0; i < 20; i++) Console.Write("_");



        //check member rank repo
        Console.WriteLine("\n\n\n           ======check member rank repo======");
        Console.WriteLine("---adding");
        memberRankRepo.Add(new MemberRank()
        {
            Name = "Garbage 5"
        });
        Console.WriteLine("---up from db");
        var memberRankFromDB = memberRankRepo.GetAllRanks().FirstOrDefault();
        Console.WriteLine("---show result");
        if (memberRankFromDB != null)
        {
            Console.WriteLine(memberRankFromDB.Name);
            Console.WriteLine("+++successful");
        }
        else Console.WriteLine("---failed");
        for (int i = 0; i < 20; i++) Console.Write("_");



        //check member trail repo
        Console.WriteLine("\n\n\n           ======check member trail repo======");
        Console.WriteLine("---adding");
        memberTrailRepo.AddMemberTrail(new MemberTrail()
        {
            Name = "Jerk",
            Description = "Member is a jerk"
        });
        Console.WriteLine("---up from db");
        var memberTrailFromDB = memberTrailRepo.GetAllMembersTrails().FirstOrDefault();
        Console.WriteLine("---show result");
        if (memberTrailFromDB != null)
        {
            Console.WriteLine(memberTrailFromDB.Name + "\n" + memberTrailFromDB.Description);
            Console.WriteLine("+++successful");
        }
        else Console.WriteLine("---failed");
        for (int i = 0; i < 20; i++) Console.Write("_");



        //check member repo
        Console.WriteLine("\n\n\n           ======check member repo======");
        Console.Write("---adding with");
        if (memberRankFromDB != null && memberTrailFromDB != null)
        {
            Console.WriteLine(" member rank and trail");
            memberRepo.AddMember(new Member()
            {
                Name = "Neo",
                Age = 14,
                Energy = 100,
                MaxEnergy = 100,
                Expiriance = 0,
                SkillPoints = 0,
                RankPoints = 0,
                CreationDate = DateTime.Now,
                LastChanges = DateTime.Now,
                MemberRankId = memberRankFromDB.Id,
                MemberTrailId = memberTrailFromDB.Id
            });
        }
        else
        {
            Console.WriteLine("out member rank and trail");
            memberRepo.AddMember(new Member()
            {
                Name = "Neo",
                Age = 14,
                Energy = 100,
                MaxEnergy = 100,
                Expiriance = 0,
                SkillPoints = 0,
                RankPoints = 0,
                CreationDate = DateTime.Now,
                LastChanges = DateTime.Now
            });
        }
        Console.WriteLine("---up from db");
        var memberFromDB = memberRepo.GetAll().FirstOrDefault();
        Console.WriteLine("---show result");
        if (memberFromDB != null)
        {
            Console.WriteLine(memberFromDB.Id);
            Console.WriteLine(memberFromDB.Name);
            Console.WriteLine(memberFromDB.Age);
            Console.WriteLine("+++successful");
        }
        else Console.WriteLine("---failed");
        for (int i = 0; i < 20; i++) Console.Write("_");



        //check position name repo
        Console.WriteLine("\n\n\n           ======check position name repo======");
        for (int i = 0; i < 5; i++) Console.WriteLine(positionNameRepo.GetCurrentlyPositionName(i) + "\n");
        Console.WriteLine("+++successful");
        for (int i = 0; i < 20; i++) Console.Write("_");



        //check position repo
        Console.WriteLine("\n\n\n           //======check position repo======");
        Console.Write("adding with");
        if (memberFromDB != null)
        {
            Console.WriteLine(" member");
            positionRepo.AddPosition(new Position()
            {
                Name = positionNameRepo.GetCurrentlyPositionName(0),
                Expiriance = 0,
                Level = 1,
                Rank = 999,
                Power = 0,
                Favorite = 0,
                Defence = 0,
                Health = 0,
                MemberId = memberFromDB.Id
            });
        }
        else
        {
            Console.WriteLine("out member");
            positionRepo.AddPosition(new Position()
            {
                Name = positionNameRepo.GetCurrentlyPositionName(0),
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
        for (int i = 0; i < 20; i++) Console.Write("_");



        //check teams repo
        Console.WriteLine("\n\n\n           //======check team repo======");
        Console.Write("adding with");
        if(teamRankFromDB != null && teamTrailFromDB != null && userFromDB != null)
        {
            Console.WriteLine(" team rank, trail");
            teamRepo.Add(new Team()
            {
                Name = "Losers",
                ShortName = "LOS",
                Description = "Born to lose!",
                Expiriance = 0,
                Energy = 0,
                Power = 0,
                Health = 0,
                Teamplay = 0,
                RankPoints = 0,
                TeamTrailId = teamTrailFromDB.Id,
                TeamRankId = teamRankFromDB.Id
            });
        }
        else
        {
            Console.WriteLine("out team rank, trail and user");
            teamRepo.Add(new Team()
            {
                Name = "Losers",
                ShortName = "LOS",
                Description = "Born to lose!",
                Expiriance = 0,
                Energy = 0,
                Power = 0,
                Health = 0,
                Teamplay = 0,
                RankPoints = 0
            });
        }
        Console.WriteLine("up from db");
        var teamFromDb = teamRepo.GetAll().FirstOrDefault();
        Console.WriteLine("show result");
        if (teamFromDb != null)
        {
            Console.WriteLine(teamFromDb.Name + "\n" + teamFromDb.Description);
            Console.WriteLine("successful");
        }
        else Console.WriteLine("failed");
        for (int i = 0; i < 20; i++) Console.Write("_");
    }
}