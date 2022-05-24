using Interface_DnD.DTO;
using Logic_DnD.Classes;
using Logic_DnD.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stub_DnD.Stub;
using System;
using System.Collections.Generic;

namespace UnitTest_DnD.Test
{
    [TestClass]
    public class BackgroundTest
    {
        [TestMethod]
        public void DnD_Between_Background_Getall_Test()
        {
            // Arrange
            BackgroundStub backgroundStub = new BackgroundStub();
            Background_Container background_Container = new Background_Container(backgroundStub);

            // Act
            List<Background> backgroundlist = background_Container.Getall();

            // Assert
            Assert.AreEqual(2, backgroundlist.Count);
        }

        [TestMethod]
        public void DnD_Between_Background_GetbyFiler_Test()
        {
            // Arrange
            BackgroundStub backgroundStub = new BackgroundStub();
            Background_Container background_Container = new Background_Container(backgroundStub);

            // Act
            List<Background> backgroundlist = background_Container.GetByFilter("Bard");

            // Assert
            Assert.AreEqual(1, backgroundlist.Count);
            Assert.AreEqual("Bard", backgroundlist[0].Class);
        }
    }
}
