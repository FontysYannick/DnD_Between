using Interface_DnD.DTO;

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
        public Background char_back { get; private set; }
        public Class char_class { get; private set; }
        public Race char_race { get; private set; }

        public Character()
        {
        }

        public Character(int id, int user_id, string name, int str, int dex, int con, int intt, int wis, int cha, int level, int speed, Background char_back, Class char_class, Race char_race)
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
            this.char_back = char_back;
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

            characterDTO.char_back = new BackgroundDTO() { ID = character.char_back.ID };
            characterDTO.char_class = new ClassDTO() { ID = character.char_class.ID };
            characterDTO.char_race = new RaceDTO() { ID = character.char_race.ID };

            return characterDTO;
        }

        public Character FromDTO(CharacterDTO characterDTO)
        {
            Character character = new Character();
            character.ID = characterDTO.ID;
            character.user_id = characterDTO.user_id;
            character.name = characterDTO.name;
            character.str = characterDTO.str;
            character.dex = characterDTO.dex;
            character.con = characterDTO.con;
            character.intt = characterDTO.intt;
            character.wis = characterDTO.wis;
            character.cha = characterDTO.cha;
            character.level = characterDTO.level;
            character.speed = characterDTO.speed;

            character.char_back = new Background(characterDTO.char_back.ID, characterDTO.char_back.Name, characterDTO.char_back.Description);
            character.char_class = new Class(characterDTO.char_class.ID, characterDTO.char_class.name, characterDTO.char_class.description);
            character.char_race = new Race(characterDTO.char_race.ID, characterDTO.char_race.name);

            return character;
        }
    }
}
