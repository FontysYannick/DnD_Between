using Logic_DnD.Classes;
using Logic_DnD.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stub_DnD.Stub;
using System;

namespace UnitTest_DnD.Test
{
    [TestClass]
    public class CharacterTest
    {
        CharacterStub characterStub = new CharacterStub();

        [TestMethod]
        public void TestAdd1()
        {
            // Arrange
            Class char_class = new Class(1, "barb");
            Race char_race = new Race(1, "elf");
            Character character = new Character(5, "bob", 8,8,8,8,8,8,14,30,char_class,char_race);
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.AddCharacter(character);

            // Assert
            Assert.AreEqual(character.ID, characterStub.Characterlist[characterStub.Characterlist.Count - 1].ID);
        }

        [TestMethod]
        public void TestAdd2()
        {
            // Arrange
            Class char_class = new Class(1, "barb");
            Race char_race = new Race(1, "elf");
            Character character = new Character(5, "Name Is Wrong", 8, 8, 8, 8, 8, 8, 14, 30, char_class, char_race);
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.AddCharacter(character);

            // Assert
            Assert.AreEqual(character.name, "Name Is Wrong");
        }

        [TestMethod]
        public void TestDelete()
        {
            // Arrange
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.DeleteCharacter(1);

            // Assert
            Assert.AreEqual(3, characterStub.Characterlist.Count);
        }

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.Getall();

            // Assert
            Assert.AreEqual(4, characterContainer.Getall().Count);
        }

        [TestMethod]
        public void TestGetOne()
        {
            // Arrange
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.Getbyid(1);

            // Assert
            Assert.AreEqual(1, characterContainer.Getbyid(1).ID);
        }

        [TestMethod]
        public void TestUpdate1()
        {
            // Arrange
            Class char_class = new Class(1, "barb");
            Race char_race = new Race(1, "elf");
            Character character = new Character(1, "Testing", 8, 8, 8, 8, 8, 8, 14, 30, char_class, char_race);
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.UpdateCharacter(character);

            // Assert
            Assert.AreEqual(character.name, "Testing");
        }

        [TestMethod]
        public void TestUpdate2()
        {
            // Arrange
            Class char_class = new Class(1, "barb");
            Race char_race = new Race(1, "elf");
            Character character = new Character(1, "Name Is Wrong", 8, 8, 8, 8, 8, 8, 14, 30, char_class, char_race);
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.UpdateCharacter(character);

            // Assert
            Assert.AreNotEqual(character.name, "Testing");
        }
    }
}
