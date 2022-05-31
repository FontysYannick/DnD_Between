using Logic_DnD.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stub_DnD.Stub;

namespace UnitTest_DnD.Test
{
    [TestClass]
    public class ClassTest
    {
        ClassStub classStub = new ClassStub();

        [TestMethod]
        public void DnD_Between_class_GetAll_Test()
        {
            // Arrange
            Class_Container class_Container = new Class_Container(classStub);

            // Act
            class_Container.Getall();

            // Assert
            Assert.AreEqual(2, class_Container.Getall().Count);
            Assert.AreEqual(1, class_Container.Getall()[0].ID);
            Assert.AreEqual("Barb", class_Container.Getall()[0].name);
            Assert.AreEqual("Barb go brr", class_Container.Getall()[0].description);

            Assert.AreEqual(2, class_Container.Getall()[1].ID);
            Assert.AreEqual("Bard", class_Container.Getall()[1].name);

        }
    }
}
