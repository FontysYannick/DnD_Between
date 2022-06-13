using Logic_DnD.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest_DnD.Test
{
    [TestClass]
    public class CalculationTest
    {
        [TestMethod]
        public void DnD_Between_calculation_config_table()
        {
            // Arrange
            Calculations calculation = new Calculations();

            // Act
            int test1 = calculation.ConfigureByTable(10);
            int test2 = calculation.ConfigureByTable(20);
            int test3 = calculation.ConfigureByTable(17);

            // Assert
            Assert.AreEqual(0, test1);
            Assert.AreEqual(5, test2);
            Assert.AreEqual(3, test3);
        }

        [TestMethod]
        public void DnD_Between_calculation_config_prof()
        {
            // Arrange
            Calculations calculation = new Calculations();


            // Act
            int test1 = calculation.ConfigureProf(1);
            int test2 = calculation.ConfigureProf(6);
            int test3 = calculation.ConfigureProf(10);
            int test4 = calculation.ConfigureProf(15);
            int test5 = calculation.ConfigureProf(20);

            // Assert
            Assert.AreEqual(2, test1);
            Assert.AreEqual(3, test2);
            Assert.AreEqual(4, test3);
            Assert.AreEqual(5, test4);
            Assert.AreEqual(6, test5);
        }
    }
}
