using LOT.BLL.Services.Teams;

namespace LOT.Tests.BusinessLogicTests
{
    [TestClass]
    public class NamesServiceTest
    {
        [TestMethod]
        public void GetNewTeamNameReturnName()
        {
            string name;
            TeamsNamesService service = new();

            name = service.GetNewTeamName();

            Console.WriteLine(name);
            Assert.IsNotNull(name);
        }
    }
}
