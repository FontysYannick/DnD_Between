﻿using Interface_DnD.DTO;
using Interface_DnD.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL_DnD.Context
{
    public class Character_Context : DB, ICharacter
    {
        public int AddCharacter(CharacterDTO character)
        {
            string sqlCharacter = "INSERT INTO Character ([name], [User_ID],[strength],[dexterity],[constitution],[intelligence],[wisdom],[charisma],[level],[speed],[class_id],[race_id]) " +
                "OUTPUT INSERTED.id VALUES (@name, @User_ID,@str,@dex,@con,@intt,@wis,@cha,@level,@speed,@class_id,@race_id)";
            int ID = 1;

            using (SqlCommand characterCmd = new SqlCommand(sqlCharacter, Connection()))
            {
                characterCmd.Parameters.AddWithValue("@name", character.name);
                characterCmd.Parameters.AddWithValue("@User_ID", 1);
                characterCmd.Parameters.AddWithValue("@str", character.str);
                characterCmd.Parameters.AddWithValue("@dex", character.dex);
                characterCmd.Parameters.AddWithValue("@con", character.con);
                characterCmd.Parameters.AddWithValue("@intt", character.intt);
                characterCmd.Parameters.AddWithValue("@wis", character.wis);
                characterCmd.Parameters.AddWithValue("@cha", character.cha);
                characterCmd.Parameters.AddWithValue("@level", character.level);
                characterCmd.Parameters.AddWithValue("@speed", character.speed);
                characterCmd.Parameters.AddWithValue("@class_id", character.char_class.ID);
                characterCmd.Parameters.AddWithValue("@race_id", character.char_race.ID);

                try
                {
                    Open();
                    ID = (int)characterCmd.ExecuteScalar();
                    Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return ID;
        }

        public void UpdateCharacter(CharacterDTO character)
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

        public void DeleteCharacter(int ID)
        {
            SqlCommand cmd = new SqlCommand("Delete from Character Where id =" + ID, Connection());

            try
            {
                Open();
                cmd.ExecuteNonQuery();
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<CharacterDTO> Getall()
        {
            List<CharacterDTO> CharacterDTOList = new List<CharacterDTO>();

            string query = "SELECT Character.*, Class.class, Race.race FROM Character JOIN Class on Character.class_id = Class.Id JOIN Race on Character.race_id = Race.id";
            SqlCommand commandDatabase = new SqlCommand(query, Connection());
            commandDatabase.CommandTimeout = 60;
            SqlDataReader reader;

            try
            {
                Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var items = new CharacterDTO()
                        {
                            ID = reader.GetInt32(0),
                            name = reader.GetString(1),
                            str = reader.GetInt32(2),
                            dex = reader.GetInt32(3),
                            con = reader.GetInt32(4),
                            intt = reader.GetInt32(5),
                            wis = reader.GetInt32(6),
                            cha = reader.GetInt32(7),
                            level = reader.GetInt32(8),
                            speed = reader.GetInt32(9),
                            char_class = new ClassDTO() { ID = reader.GetInt32(10), name = reader.GetString(12) },
                            char_race = new RaceDTO() { ID = reader.GetInt32(11), name = reader.GetString(13) }
                        };
                        CharacterDTOList.Add(items);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CharacterDTOList;
        }

        public CharacterDTO Getbyid(int id)
        {
            CharacterDTO CharacterDto = new CharacterDTO();
            string query = "SELECT Character.*, Class.class, Race.race FROM Character JOIN Class on Character.class_id = Class.Id JOIN Race on Character.race_id = Race.id WHERE Character.id = " + id;

            SqlCommand commandDatabase = new SqlCommand(query, Connection());
            commandDatabase.CommandTimeout = 60;
            SqlDataReader reader;

            try
            {
                Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CharacterDto = new CharacterDTO()
                        {
                            ID = reader.GetInt32(0),
                            name = reader.GetString(1),
                            str = reader.GetInt32(2),
                            dex = reader.GetInt32(3),
                            con = reader.GetInt32(4),
                            intt = reader.GetInt32(5),
                            wis = reader.GetInt32(6),
                            cha = reader.GetInt32(7),
                            level = reader.GetInt32(8),
                            speed = reader.GetInt32(9),
                            char_class = new ClassDTO() { ID = reader.GetInt32(10), name = reader.GetString(12) },
                            char_race = new RaceDTO() { ID = reader.GetInt32(11), name = reader.GetString(13) }
                        };
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CharacterDto;
        }
    }
}

