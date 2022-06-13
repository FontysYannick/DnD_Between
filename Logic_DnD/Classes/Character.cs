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

        public CharacterDTO ToDTO()
        {
            CharacterDTO characterDTO = new CharacterDTO
            {
                ID = this.ID,
                user_id = this.user_id,
                name = this.name,
                str = this.str,
                dex = this.dex,
                con = this.con,
                intt = this.intt,
                wis = this.wis,
                cha = this.cha,
                level = this.level,
                speed = this.speed,

                char_back = new BackgroundDTO() { ID = this.char_back.ID },
                char_class = new ClassDTO() { ID = this.char_class.ID },
                char_race = new RaceDTO() { ID = this.char_race.ID }
            };

            return characterDTO;
        }

        public Character FromDTO(CharacterDTO characterDTO)
        {

            this.ID = characterDTO.ID;
            this.user_id = characterDTO.user_id;
            this.name = characterDTO.name;
            this.str = characterDTO.str;
            this.dex = characterDTO.dex;
            this.con = characterDTO.con;
            this.intt = characterDTO.intt;
            this.wis = characterDTO.wis;
            this.cha = characterDTO.cha;
            this.level = characterDTO.level;
            this.speed = characterDTO.speed;

            this.char_back = new Background(characterDTO.char_back.ID, characterDTO.char_back.Name, characterDTO.char_back.Description);
            this.char_class = new Class(characterDTO.char_class.ID, characterDTO.char_class.name, characterDTO.char_class.description);
            this.char_race = new Race(characterDTO.char_race.ID, characterDTO.char_race.name);


            return this;
        }
    }
}
