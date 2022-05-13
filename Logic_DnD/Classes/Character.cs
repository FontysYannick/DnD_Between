using DAL_DnD;
using Interface_DnD.DTO;
using Interface_DnD.Interface;

namespace Logic_DnD.Classes
{
    public class Character
    {
        public int ID { get; private set; }
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
    }
}
