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
            CharacterDTO characterDTO = new CharacterDTO();
            characterDTO.ID = character.ID;
            characterDTO.user_id = character.user_id;
            characterDTO.name = character.name;
            characterDTO.str = character.str;
            characterDTO.dex = character.dex;
            characterDTO.con = character.con;
            characterDTO.intt = character.intt;
            characterDTO.wis = character.wis;
            characterDTO.cha = character.cha;
            characterDTO.level = character.level;
            characterDTO.speed = character.speed;


            ClassDTO classDTO = new ClassDTO();
            classDTO.ID = character.char_class.ID;
            classDTO.name = character.char_class.name;
            characterDTO.char_class = classDTO;

            RaceDTO raceDTO = new RaceDTO();
            raceDTO.ID = character.char_race.ID;
            raceDTO.name = character.char_race.name;
            characterDTO.char_race = raceDTO;

            return _Context.AddCharacter(characterDTO);
        }

        public void UpdateCharacter(Character character)
        {
            CharacterDTO characterDTO = new CharacterDTO();
            characterDTO.ID = character.ID;
            characterDTO.name = character.name;
            characterDTO.str = character.str;
            characterDTO.dex = character.dex;
            characterDTO.con = character.con;
            characterDTO.intt = character.intt;
            characterDTO.wis = character.wis;
            characterDTO.cha = character.cha;
            characterDTO.level = character.level;
            characterDTO.speed = character.speed;


            ClassDTO classDTO = new ClassDTO();
            classDTO.ID = character.char_class.ID;
            classDTO.name = character.char_class.name;
            characterDTO.char_class = classDTO;

            RaceDTO raceDTO = new RaceDTO();
            raceDTO.ID = character.char_race.ID;
            raceDTO.name = character.char_race.name;
            characterDTO.char_race = raceDTO;

            _Context.UpdateCharacter(characterDTO);
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
                list_Character.Add(new Character(item.ID, item.name, item.str, item.dex, item.con, item.intt, item.wis, item.cha, item.level, item.speed, new Class(item.char_class.ID, item.char_class.name), new Race(item.char_race.ID, item.char_race.name)));
            }

            return list_Character;
        }

        public List<Character> Getbyuser(int ID)
        {
            List<Character> list_Character = new List<Character>();

            foreach (var item in _Context.Getbyuser(ID))
            {
                list_Character.Add(new Character(item.ID, item.name, item.str, item.dex, item.con, item.intt, item.wis, item.cha, item.level, item.speed, new Class(item.char_class.ID, item.char_class.name), new Race(item.char_race.ID, item.char_race.name)));
            }

            return list_Character;
        }

        public Character Getbyid(int ID)
        {
            CharacterDTO DTO = _Context.Getbyid(ID);
            Character list_Character = new Character(DTO.ID, DTO.name, DTO.str, DTO.dex, DTO.con, DTO.intt, DTO.wis, DTO.cha, DTO.level, DTO.speed, new Class(DTO.char_class.ID, DTO.char_class.name), new Race(DTO.char_race.ID, DTO.char_race.name));

            return list_Character;
        }
    }
}
