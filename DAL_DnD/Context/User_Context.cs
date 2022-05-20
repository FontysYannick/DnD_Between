using Interface_DnD.DTO;
using Interface_DnD.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DnD.Context
{
    public class User_Context : DB, IUser
    {
        public UserDTO AttemptLogin(UserDTO userDTO)
        {
            UserDTO user = new UserDTO();

            string username = userDTO.Username;
            string password = userDTO.Password;
            bool verified = false;

            string query = "SELECT * FROM [User] WHERE Username = (@Username)";
            using (SqlCommand commandDatabase = new SqlCommand(query, Connection()))
            {
                commandDatabase.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader;

                try
                {
                    Open();
                    reader = commandDatabase.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            verified = BCrypt.Net.BCrypt.Verify(password, reader["Password"].ToString().Trim());
                            if (verified)
                            {
                                // True, log in accepted
                                user = new UserDTO()
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Password = reader.GetString(2),
                                };

                            }
                            else
                            {
                                throw new Exception("Incorrect credentials");
                            }
                        }
                    }
                }
                catch
                {
                    Console.Write("Connection Error", "Information");
                }
                finally
                {
                    Close();
                }
            }
            return user;
        }

        public bool Register(UserDTO userDTO)
        {
            string passwordHashed;
            int userID = default;
            int inUse = 0;
            string sql = "";
            bool verified = false;

            try
            {
                if (Open())
                {
                    using (Connection())
                    {
                        // Make a sql query to retrieve all users where email is the same as what is filled in
                        sql = "SELECT COUNT(1) FROM [User] WHERE Username = @Username";
                        SqlCommand command = new SqlCommand(sql, Connection());
                        using (command = new SqlCommand(sql, Connection()))
                        {
                            command.Parameters.AddWithValue("@Username", userDTO.Username);
                            inUse = (int)command.ExecuteScalar();
                            command.Dispose();
                            Close();
                        }

                        if (inUse >= 1)
                        {
                            throw new Exception("Username is already in use");
                        }

                        // Hash the password
                        passwordHashed = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

                        // Store the user in the database
                        sql = "INSERT INTO [User] (Username, Password) VALUES (@Username, @Password)";
                        using (command = new SqlCommand(sql, Connection()))
                        {
                            command.Parameters.AddWithValue("@Username", userDTO.Username);
                            command.Parameters.AddWithValue("@Password", passwordHashed);

                            try
                            {
                                Open();
                                command.ExecuteScalar();
                                command.Dispose();
                            }
                            catch
                            {
                                throw new Exception("Couldn't register user");
                            }
                            finally
                            {
                                Close();
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Couldn't connect");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
            return true;
        }
    }
}
