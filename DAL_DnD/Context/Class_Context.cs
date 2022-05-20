using Interface_DnD.DTO;
using Interface_DnD.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL_DnD.Context
{
    public class Class_Context : DB, IClass
    {
        public List<ClassDTO> Getall()
        {
            List<ClassDTO> ClassDTOList = new List<ClassDTO>();

            string query = "SELECT * FROM Class";
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
                        var items = new ClassDTO()
                        {
                            ID = reader.GetInt32(0),
                            name = reader.GetString(1),
                            description = reader.GetString(2),

                        };
                        ClassDTOList.Add(items);
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

            return ClassDTOList;
        }
    }
}
