using DAL_DnD.Context;
using Interface_DnD.DTO;
using Interface_DnD.Interface;
using Logic_DnD.Classes;
using System.Collections.Generic;

namespace Logic_DnD.Container
{
    public class Character_Container
    {
        ICharacter _Context;

        public Character_Container(ICharacter context)
        {
            this._Context = context;
        }

        public int AddCharacter(Character character)
        {
            return _Context.AddCharacter(character.ToDTO(character));
        }

        public void UpdateCharacter(Character character)
        {
            _Context.UpdateCharacter(character.ToDTO(character));
        }

        public void DeleteCharacter(int ID)
        {
            _Context.DeleteCharacter(ID);
        }

        public List<Character> Getall()
        {
            List<Character> list_Character = new List<Character>();
            Character character = new Character();

            foreach (CharacterDTO item in _Context.Getall())
            {
                list_Character.Add(character.FromDTO(item));
            }

            return list_Character;
        }

        public List<Character> Getbyuser(int ID)
        {
            List<Character> list_Character = new List<Character>();
            Character character = new Character();

            foreach (var item in _Context.Getbyuser(ID))
            {
                list_Character.Add(character.FromDTO(item));
            }

            return list_Character;
        }

        public Character Getbyid(int ID)
        {
            CharacterDTO DTO = _Context.Getbyid(ID);
            Character character = new Character();

            return character.FromDTO(DTO);
        }
    }
}
