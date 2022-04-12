namespace DnD_Between.Models
{
    public class CharacterViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }
        public int Level { get; set; }
        public int Speed { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }

        public CharacterViewModel()
        {

        }

        public CharacterViewModel(int id, string name, int str, int dex, int con, int intt, int wis, int cha, int level, int speed, string class_, string race)
        {
            this.ID = id;
            this.Name = name;
            this.Str = str;
            this.Dex = dex;
            this.Con = con;
            this.Int = intt;
            this.Wis = wis;
            this.Cha = cha;
            this.Level = level;
            this.Speed = speed;
            this.Class = class_;
            this.Race = race;
        }
    }
}
