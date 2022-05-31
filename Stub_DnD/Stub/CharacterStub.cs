using Interface_DnD.DTO;
using Interface_DnD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub_DnD.Stub
{
    public class CharacterStub : ICharacter
    {
        public List<CharacterDTO> Characterlist { get; set; }

        public CharacterStub()
        {
            this.Characterlist = new List<CharacterDTO>()
            {
                new CharacterDTO{ID = 1, user_id = 1, name = "Billy", str = 10, dex = 10, con = 10, intt = 10, wis = 10, cha = 10, level = 1, speed = 30, char_back = new BackgroundDTO(){ID = 1, Name = "test", Description = "test"},   char_class = new ClassDTO(){ID = 1, name = "barb" }, char_race = new RaceDTO(){ID = 1, name = "elf" } },
                new CharacterDTO{ID = 2, user_id = 2, name = "Bobby", str = 5, dex = 5, con = 5, intt = 5, wis = 5, cha = 5, level = 3, speed = 30,       char_back = new BackgroundDTO(){ID = 1, Name = "test", Description = "test"},   char_class = new ClassDTO(){ID = 1, name = "barb" }, char_race = new RaceDTO(){ID = 1, name = "elf" } },
                new CharacterDTO{ID = 3, user_id = 1, name = "Jonny", str = 15, dex = 15, con = 15, intt = 15, wis = 15, cha = 15, level = 1, speed = 30, char_back = new BackgroundDTO(){ID = 1, Name = "test", Description = "test"},   char_class = new ClassDTO(){ID = 1, name = "barb" }, char_race = new RaceDTO(){ID = 1, name = "elf" } },
                new CharacterDTO{ID = 4, user_id = 1, name = "bert", str = 7, dex = 7, con = 7, intt = 7, wis = 7, cha = 7, level = 1, speed = 30,        char_back = new BackgroundDTO(){ID = 1, Name = "test", Description = "test"},   char_class = new ClassDTO(){ID = 1, name = "barb" }, char_race = new RaceDTO(){ID = 1, name = "elf" } }
            };
        }

        public int AddCharacter(CharacterDTO character)
        {
            Characterlist.Add(character);
            return character.ID;
        }

        public void DeleteCharacter(int ID)
        {
            int i = 0;
            while (i < Characterlist.Count && Characterlist[i].ID != ID)
            {
                i++;
            }

            if (i != Characterlist.Count)
            {
                Characterlist.Remove(Characterlist[i]);
            }
        }

        public List<CharacterDTO> Getall()
        {
            return Characterlist;
        }

        public CharacterDTO Getbyid(int ID)
        {
            CharacterDTO D = default;

            int i = 0;
            while (i < Characterlist.Count && Characterlist[i].ID != ID)
            {
                i++;
            }

            if (i != Characterlist.Count)
            {
                D = Characterlist[i];
            }
            return D;
        }

        public void UpdateCharacter(CharacterDTO character)
        {
            for (var i = 0; i < Characterlist.Count; i++)
            {
                if (Characterlist[i].ID == character.ID)
                {
                     (Characterlist[i]) = character;
                }
            }
        }

        public List<CharacterDTO> Getbyuser(int User_ID)
        {
            List<CharacterDTO> list = new List<CharacterDTO>();
            for (var i = 0; i < Characterlist.Count; i++)
            {
                if (Characterlist[i].user_id == User_ID)
                {
                    list.Add(Characterlist[i]);
                }
            }

            return list;
        }
    }
}
