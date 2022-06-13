using Interface_DnD.DTO;
using Interface_DnD.Interface;
using Logic_DnD.Classes;
using System.Collections.Generic;

namespace Logic_DnD.Container
{
    public class Character_Container
    {
        readonly ICharacter _Context;

        public Character_Container(ICharacter context)
        {
            this._Context = context;
        }

        public int AddCharacter(Character character)
        {
            return _Context.AddCharacter(character.ToDTO());
        }

        public void UpdateCharacter(Character character)
        {
            _Context.UpdateCharacter(character.ToDTO());
        }

        public void DeleteCharacter(int ID)
        {
            _Context.DeleteCharacter(ID);
        }

        public List<Character> Getall()
        {
            List<Character> list_Character = new List<Character>();

            foreach (CharacterDTO item in _Context.Getall())
            {
                Character character = new Character();
                list_Character.Add(character.FromDTO(item));
            }

            return list_Character;
        }

        public List<Character> Getbyuser(int ID)
        {
            List<Character> list_Character = new List<Character>();

            foreach (var item in _Context.Getbyuser(ID))
            {
                Character character = new Character();
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
