using Logic_DnD.Classes;
using System.ComponentModel.DataAnnotations;

namespace DnD_Between.Models
{
    public class CharacterViewModel
    {
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Range(0, 30)]
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
        public string Back_name { get; set; }
        public string Back_Des { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Race { get; set; }

        public CharacterViewModel()
        {

        }

        public CharacterViewModel ToViewModel(Character character)
        {
            CharacterViewModel characterView = new CharacterViewModel();
            characterView.ID = character.ID;
            characterView.Name = character.name;
            characterView.Str = character.str;
            characterView.Dex = character.dex;
            characterView.Con = character.con;
            characterView.Int = character.intt;
            characterView.Wis = character.wis;
            characterView.Cha = character.cha;
            characterView.Level = character.level;
            characterView.Speed = character.speed;
            characterView.Back_name = character.char_back.Name;
            characterView.Back_Des = character.char_back.Description;
            characterView.Class = character.char_class.name;
            characterView.Race = character.char_race.name;

            return characterView;
        }

        public Character FromViewModel(CharacterViewModel charview, int User)
        {
            Background back = new Background(Int32.Parse(charview.Back_name));
            Class clss = new Class(Int32.Parse(charview.Class));
            Race race = new Race(Int32.Parse(charview.Race));
            Character character = new Character(charview.ID, User, charview.Name, charview.Str, charview.Dex, charview.Con, charview.Int, charview.Wis, charview.Cha, charview.Level, charview.Speed, back, clss, race);

            return character;
        }
    }
}
