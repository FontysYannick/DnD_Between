﻿namespace Interface_DnD.DTO
{
    public class CharacterDTO
    {
        public int ID { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public int str { get; set; }
        public int dex { get; set; }
        public int con { get; set; }
        public int intt { get; set; }
        public int wis { get; set; }
        public int cha { get; set; }
        public int level { get; set; }
        public int speed { get; set; }
        public BackgroundDTO char_back { get; set; }
        public ClassDTO char_class { get; set; }
        public RaceDTO char_race { get; set; }
    }
}