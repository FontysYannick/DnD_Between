﻿using DAL_DnD;
using Interface_DnD.DTO;
using Interface_DnD.Interface;

namespace Logic_DnD.Classes
{
    public class Character
    {
        public int ID { get; private set; }
        public int user_id { get; private set; }
        public string name { get; private set; }
        public int str { get; private set; }
        public int dex { get; private set; }
        public int con { get; private set; }
        public int intt { get; private set; }
        public int wis { get; private set; }
        public int cha { get; private set; }
        public int level { get; private set; }
        public int speed { get; private set; }
        public Class char_class { get; private set; }
        public Race char_race { get; private set; }

        public Character()
        {
        }

        public Character(int id, int user_id,string name, int str, int dex, int con, int intt, int wis, int cha, int level, int speed, Class char_class, Race char_race)
        {
            this.ID = id;
            this.user_id = user_id;
            this.name = name;
            this.str = str;
            this.dex = dex;
            this.con = con;
            this.intt = intt;
            this.wis = wis;
            this.cha = cha;
            this.level = level;
            this.speed = speed;
            this.char_class = char_class;
            this.char_race = char_race;
        }

        public Character(int id, string name, int str, int dex, int con, int intt, int wis, int cha, int level, int speed, Class char_class, Race char_race)
        {
            this.ID = id;
            this.name = name;
            this.str = str;
            this.dex = dex;
            this.con = con;
            this.intt = intt;
            this.wis = wis;
            this.cha = cha;
            this.level = level;
            this.speed = speed;
            this.char_class = char_class;
            this.char_race = char_race;
        }


        public CharacterDTO ToDTO(Character character)
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

            return characterDTO;
        }
    }
}
