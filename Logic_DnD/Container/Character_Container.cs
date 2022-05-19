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
            Character character1 = new Character();

            return _Context.AddCharacter(character1.ToDTO(character));
        }

        public void UpdateCharacter(Character character)
        {
            Character character1 = new Character();

            _Context.UpdateCharacter(character1.ToDTO(character));
        }

        public void DeleteCharacter(int ID)
        {
            _Context.DeleteCharacter(ID);
        }

        public List<Character> Getall()
        {
            List<Character> list_Character = new List<Character>();

            foreach (var item in _Context.Getall())
            {
                list_Character.Add(new Character(item.ID, item.user_id, item.name, item.str, item.dex, item.con, item.intt, item.wis, item.cha, item.level, item.speed, new Class(item.char_class.ID, item.char_class.name), new Race(item.char_race.ID, item.char_race.name)));
            }

            return list_Character;
        }

        public List<Character> Getbyuser(int ID)
        {
            List<Character> list_Character = new List<Character>();

            foreach (var item in _Context.Getbyuser(ID))
            {
                list_Character.Add(new Character(item.ID, item.user_id, item.name, item.str, item.dex, item.con, item.intt, item.wis, item.cha, item.level, item.speed, new Class(item.char_class.ID, item.char_class.name), new Race(item.char_race.ID, item.char_race.name)));
            }

            return list_Character;
        }

        public Character Getbyid(int ID)
        {
            CharacterDTO DTO = _Context.Getbyid(ID);
            Character list_Character = new Character(DTO.ID, DTO.user_id, DTO.name, DTO.str, DTO.dex, DTO.con, DTO.intt, DTO.wis, DTO.cha, DTO.level, DTO.speed, new Class(DTO.char_class.ID, DTO.char_class.name), new Race(DTO.char_race.ID, DTO.char_race.name));

            return list_Character;
        }
    }
}
