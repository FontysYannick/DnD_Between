using Logic_DnD.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stub_DnD.Stub;
namespace UnitTest_DnD.Test
{
    [TestClass]
    public class RaceTest
    {
        RaceStub raceStub = new RaceStub();

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            Race_Container race_Container = new Race_Container(raceStub);

            // Act
            race_Container.Getall();

            // Assert
            Assert.AreEqual(2, race_Container.Getall().Count);
        }
    }
}
