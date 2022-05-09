using Logic_DnD.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stub_DnD.Stub;
using System;

namespace UnitTest_DnD.Test
{
    [TestClass]
    public class ClassTest
    {
        ClassStub classStub = new ClassStub();

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            Class_Container class_Container = new Class_Container(classStub);

            // Act
            class_Container.Getall();

            // Assert
            Assert.AreEqual(2, class_Container.Getall().Count);
        }
    }
}
