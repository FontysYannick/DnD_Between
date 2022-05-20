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
        public void DnD_Between_Add_Test()
        {
            // Arrange
            Class char_class = new Class(1);
            Race char_race = new Race(1);
            Character character = new Character(5, 1, "bob", 8, 8, 8, 8, 8, 8, 14, 30,char_class,char_race);

            Class character_class = new Class(2);
            Race character_race = new Race(2);
            Character _character = new Character(6, 2, "Name Is Wrong", 10, 10, 10, 10, 10, 10, 7, 30, character_class, character_race);

            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            int A = characterContainer.AddCharacter(character);
            int B = characterContainer.AddCharacter(_character);

            // Assert
            Assert.AreEqual(5, A);
            Assert.AreEqual(1, characterContainer.Getbyid(5).user_id);
            Assert.AreEqual("bob", characterContainer.Getbyid(5).name);
            Assert.AreEqual(8, characterContainer.Getbyid(5).str);
            Assert.AreEqual(1, characterContainer.Getbyid(5).char_class.ID);
            Assert.AreEqual(1, characterContainer.Getbyid(5).char_race.ID);

            Assert.AreEqual(6, B);
            Assert.AreEqual(2, characterContainer.Getbyid(6).user_id);
            Assert.AreEqual("Name Is Wrong", characterContainer.Getbyid(6).name);
            Assert.AreEqual(10, characterContainer.Getbyid(6).str);
            Assert.AreEqual(2, characterContainer.Getbyid(6).char_class.ID);
            Assert.AreEqual(2, characterContainer.Getbyid(6).char_race.ID);
        }

        [TestMethod]
        public void DnD_Between_Update_Test()
        {
            // Arrange
            Class character_class = new Class(2);
            Race character_race = new Race(2);
            Character _character = new Character(5, 2, "Name Is Wrong", 10, 10, 10, 10, 10, 10, 7, 30, character_class, character_race);

            Class char_class = new Class(1);
            Race char_race = new Race(1);
            Character character = new Character(5, 2, "Testing", 8, 8, 8, 8, 8, 8, 14, 30, char_class, char_race);
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            int A = characterContainer.AddCharacter(_character);
            characterContainer.UpdateCharacter(character);

            // Assert
            Assert.AreEqual(5, A);
            Assert.AreEqual(2, characterContainer.Getbyid(5).user_id);
            Assert.AreEqual("Testing", characterContainer.Getbyid(5).name);
            Assert.AreEqual(8, characterContainer.Getbyid(5).str);
            Assert.AreEqual(1, characterContainer.Getbyid(5).char_class.ID);
            Assert.AreEqual(1, characterContainer.Getbyid(5).char_race.ID);
        }

        [TestMethod]
        public void DnD_Between_Delete_Test()
        {
            // Arrange
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.DeleteCharacter(2);

            // Assert
            Assert.AreEqual(3, characterStub.Characterlist.Count);
            Assert.ThrowsException<NullReferenceException>(() => characterContainer.Getbyid(2).ID);
        }

        [TestMethod]
        public void DnD_Between_character_GetAll_Test()
        {
            // Arrange
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.Getall();

            // Assert
            Assert.AreEqual(4, characterContainer.Getall().Count);
        }

        [TestMethod]
        public void DnD_Between_character_GetByID_Test()
        {
            // Arrange
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.Getbyid(1);

            // Assert
            Assert.AreEqual(1, characterContainer.Getbyid(1).ID);
            Assert.AreEqual("Billy", characterContainer.Getbyid(1).name);
        }

        [TestMethod]
        public void DnD_Between_character_GetByUserID_Test()
        {
            // Arrange
            Character_Container characterContainer = new Character_Container(characterStub);

            // Act
            characterContainer.Getbyuser(1);

            // Assert
            Assert.AreEqual(3, characterContainer.Getbyuser(1).Count);
            Assert.AreEqual(1, characterContainer.Getbyuser(1)[0].ID);
            Assert.AreEqual(3, characterContainer.Getbyuser(1)[1].ID);
            Assert.AreEqual(4, characterContainer.Getbyuser(1)[2].ID);
        }
    }
}
