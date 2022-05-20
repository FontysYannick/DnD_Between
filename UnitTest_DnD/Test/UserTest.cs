using Interface_DnD.DTO;
using Logic_DnD.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stub_DnD.Stub;
using System;

namespace UnitTest_DnD.Test
{
    [TestClass]
    public class UserTest
    {
        UserStub userStub = new UserStub();

        [TestMethod]
        public void DnD_Between_User_Login_Test()
        {
            // Arrange
            User_Container user_Container = new User_Container(userStub);
            UserDTO userDTO = new UserDTO { Id = 1, Username = "Yannick", Password = "Test123" };

            // Act
            UserDTO tester = userStub.AttemptLogin(userDTO);

            // Assert
            Assert.AreEqual(1, tester.Id);
            Assert.AreEqual("Yannick", tester.Username);
            Assert.AreEqual("Test123", tester.Password);
        }

        [TestMethod]
        public void DnD_Between_User_Login_wrong_Test()
        {
            // Arrange
            User_Container user_Container = new User_Container(userStub);
            UserDTO userDTO = new UserDTO { Id = 1, Username = "Yannick", Password = "Test" };

            // Act
            UserDTO tester = userStub.AttemptLogin(userDTO);

            // Assert
            Assert.ThrowsException<NullReferenceException>(() => tester.Id);
        }

        [TestMethod]
        public void DnD_Between_User_Register_Test()
        {
            // Arrange
            User_Container user_Container = new User_Container(userStub);
            UserDTO user = new UserDTO { Id = 3, Username = "Piet", Password = "Test123" };

            // Act
            bool test = userStub.Register(user);

            // Assert
            Assert.AreEqual(true, test);
        }

        [TestMethod]
        public void DnD_Between_User_Register_Wrong_Test()
        {
            // Arrange
            User_Container user_Container = new User_Container(userStub);
            UserDTO userDTO = new UserDTO { Id = 1, Username = "Yannick", Password = "Test" };

            // Act
            bool tester = userStub.Register(userDTO);

            // Assert
            Assert.AreEqual(false, tester);
        }
    }
}
