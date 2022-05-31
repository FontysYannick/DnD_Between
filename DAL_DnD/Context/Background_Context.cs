using Interface_DnD.DTO;
using Interface_DnD.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL_DnD.Context
{
    public class Background_Context : DB, IBackground
    {
        public List<BackgroundDTO> Getall()
        {
            List<BackgroundDTO> BackgroundDTOList = new List<BackgroundDTO>();

            string query = "SELECT * FROM Background";
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
                        var items = new BackgroundDTO()
                        {
                            ID = reader.GetInt32(0),
                            Class = reader.GetString(1),
                            Name = reader.GetString(2),
                            Description = reader.GetString(3),

                        };
                        BackgroundDTOList.Add(items);
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

            return BackgroundDTOList;
        }


        public List<BackgroundDTO> Getbyfilter(string filter)
        {
            List<BackgroundDTO> BackgroundDTOList = new List<BackgroundDTO>();

            string query = "SELECT * FROM Background WHERE Class = (@filter)";
            SqlCommand commandDatabase = new SqlCommand(query, Connection());
            commandDatabase.Parameters.AddWithValue("@filter", filter);
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
                        var items = new BackgroundDTO()
                        {
                            ID = reader.GetInt32(0),
                            Class = reader.GetString(1),
                            Name = reader.GetString(2),
                            Description = reader.GetString(3),

                        };
                        BackgroundDTOList.Add(items);
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

            return BackgroundDTOList;
        }
    }
}