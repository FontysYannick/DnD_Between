using DAL_DnD;
using System;
using System.Data.SqlClient;

namespace Logic_DnD.Classes
{
    public class Character : DB
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

        public void UpdateCharacter(Character character)
        {
            string cmd = ("UPDATE Character " +
                "SET [name]         = (@name)," +
                " [strength]        = (@str)," +
                " [dexterity]       = (@dex)," +
                " [constitution]    = (@con)," +
                " [intelligence]    = (@int)," +
                " [wisdom]          = (@wis)," +
                " [charisma]        = (@cha)," +
                " [level]           = (@level)," +
                " [speed]           = (@speed)," +
                " [class_id]        = (@class_id)," +
                " [race_id]         = (@race_id)" +
                "WHERE id           = (@ID)");

            using (SqlCommand characterCmd = new SqlCommand(cmd, Connection()))
            {
                characterCmd.Parameters.AddWithValue("@ID", character.ID);
                characterCmd.Parameters.AddWithValue("@name", character.name);
                characterCmd.Parameters.AddWithValue("@str", character.str);
                characterCmd.Parameters.AddWithValue("@dex", character.dex);
                characterCmd.Parameters.AddWithValue("@con", character.con);
                characterCmd.Parameters.AddWithValue("@int", character.intt);
                characterCmd.Parameters.AddWithValue("@wis", character.wis);
                characterCmd.Parameters.AddWithValue("@cha", character.cha);
                characterCmd.Parameters.AddWithValue("@level", character.level);
                characterCmd.Parameters.AddWithValue("@speed", character.speed);
                characterCmd.Parameters.AddWithValue("@class_id", character.char_class.ID);
                characterCmd.Parameters.AddWithValue("@race_id", character.char_race.ID);

                try
                {
                    Open();
                    characterCmd.ExecuteScalar();
                    Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
