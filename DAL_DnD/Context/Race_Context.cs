using Interface_DnD.DTO;
using Interface_DnD.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL_DnD.Context
{
    public class Race_Context : DB, IRace
    {
        public List<RaceDTO> Getall()
        {
            List<RaceDTO> RaceDTOlist = new List<RaceDTO>();

            string query = "SELECT * FROM Race";
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
                        var items = new RaceDTO()
                        {
                            ID = reader.GetInt32(0),
                            name = reader.GetString(1),

                        };
                        RaceDTOlist.Add(items);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Close();
            }

            return RaceDTOlist;
        }
    }
}