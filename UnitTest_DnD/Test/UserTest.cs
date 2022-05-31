using Logic_DnD.Classes;
using Logic_DnD.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stub_DnD.Stub;

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
            User user = new User(1, "Yannick", "Test123");

            // Act
            User tester = user_Container.attemptLogin(user);

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
            User user = new User(1, "Yannick", "test");

            // Act
            User tester = user_Container.attemptLogin(user);

            // Assert
            Assert.AreEqual(0, tester.Id);
            Assert.AreEqual("", tester.Username);
            Assert.AreEqual("", tester.Password);
        }

        [TestMethod]
        public void DnD_Between_User_Register_Test()
        {
            // Arrange
            User_Container user_Container = new User_Container(userStub);
            User user = new User(1, "Piet", "Test123");

            // Act
            bool test = user_Container.register(user);

            // Assert
            Assert.AreEqual(true, test);
        }

        [TestMethod]
        public void DnD_Between_User_Register_Wrong_Test()
        {
            // Arrange
            User_Container user_Container = new User_Container(userStub);
            User user = new User(1, "Yannick", "Test123");

            // Act
            bool tester = user_Container.register(user);

            // Assert
            Assert.AreEqual(false, tester);
        }
    }
}
