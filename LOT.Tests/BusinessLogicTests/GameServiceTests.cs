using LOT.BLL.Services;
using LOT.DAL.Repositories;

namespace LOT.Tests.BusinessLogicTests
{
    [TestClass]
    public class GameServiceTests
    {
        //[DataRow]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(11)]
        [DataRow(99)]
        [TestMethod]
        public void GenerateGameEnvironmentIsGenerate(int count)
        {
            //arrange
            GameService gameService = new GameService();
            TeamRankRepository teamRankRepository = new TeamRankRepository();
            //act
            gameService.GenerateGameEnvironment(count);
            //assert
            Assert.IsNotNull(teamRankRepository.GetAll());
        }
    }
}
