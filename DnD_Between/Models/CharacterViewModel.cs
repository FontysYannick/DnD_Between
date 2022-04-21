using System.ComponentModel.DataAnnotations;

namespace DnD_Between.Models
{
    public class CharacterViewModel
    {
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, Range(0,30)]
        public int Str { get; set; }
        [Required, Range(0, 30)]
        public int Dex { get; set; }
        [Required, Range(0, 30)]
        public int Con { get; set; }
        [Required, Range(0, 30)]
        public int Int { get; set; }
        [Required, Range(0, 30)]
        public int Wis { get; set; }
        [Required, Range(0, 30)]
        public int Cha { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int Speed { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
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
