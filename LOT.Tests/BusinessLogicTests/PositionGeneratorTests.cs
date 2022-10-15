using LOT.BLL.Services.Members;

namespace LOT.Tests.BusinessLogicTests
{
    [TestClass]
    internal class PositionGeneratorTests
    {
        [TestMethod]
        public void GetNewRandomPositionNameGeneratesPosition()
        {
            var positionGenerator = new PositionGenerator();
            var position = BLL.Enums.PositionsNames.Mid;

            var generatedPosition = positionGenerator.GetNewRandomPositionName(position);

            Assert.IsNotNull(generatedPosition);
            Assert.AreNotEqual(position, generatedPosition);
        }
    }
}
