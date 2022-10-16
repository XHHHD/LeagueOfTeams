using LOT.BLL.Enums;
using LOT.BLL.Services.Members;

namespace LOT.Tests.BusinessLogicTests
{
    [TestClass]
    internal class PositionGeneratorTests
    {
        [DataRow(PositionsNames.Top)]
        [DataRow(PositionsNames.Jungler)]
        [DataRow(PositionsNames.Mid)]
        [DataRow(PositionsNames.Bot)]
        [DataRow(PositionsNames.Support)]
        [TestMethod]
        public void GetNewRandomPositionNameGeneratesPosition(PositionsNames exceptedPositionName)
        {
            //arrange
            var positionGenerator = new PositionGenerator();
            PositionsNames generatedPositionName;

            //act
            generatedPositionName = positionGenerator.GetNewRandomPositionName(exceptedPositionName);

            //assert
            Assert.IsNotNull(generatedPositionName);
            Assert.AreNotEqual(exceptedPositionName, generatedPositionName);
        }
    }
}
