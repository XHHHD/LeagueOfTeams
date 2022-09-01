using LeagueOfTeamsDataAccess.Entities;
using LeagueOfTeamsDataAccess.Repositories;
using LeagueOfTeamsDataAccess.Interfaces;
internal class Program
{
    private static void Main(string[] args)
    {
        var userRepo = new IUser();
        var memberRepo = new MemberRepository();
        //userRepo.AddUser(new User()
        //{
        //    Name = "Vasja",
        //    Age = 14
        //});
        var userFromDB = userRepo.GetAllUsers().FirstOrDefault();
        Console.WriteLine(userFromDB.Name);
        Console.WriteLine(userFromDB.Age);
        userRepo.RemoveUser(userFromDB);

        foreach (var item in )
        {
            Console.WriteLine(item);
        }
    }
}