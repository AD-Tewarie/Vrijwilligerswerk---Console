﻿using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace Infrastructure.Repos_DB
{
    public class VrijwilligersWerkRepositoryDB
    {


        private string conString = "server=localhost;user=root;database=seniorconnect;port=3306;password=Devesh97!";
        private MySqlConnection connection = null;



        private bool IsConnect()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(conString);
                connection.Open();
            }
            return true;
        }


        //Ophalen

        public List<VrijwilligersWerkDTO> GetVrijwilligersWerk()
        {
            List<VrijwilligersWerkDTO> werkLijst = new List<VrijwilligersWerkDTO>();

            if (IsConnect())
            {
                string query = "SELECT * FROM volenteer_work";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string titel = reader.GetString("title");
                                string beschrijving = reader.GetString("description");
                                int maxCapaciteit = reader.GetInt32("max_volenteers");


                                VrijwilligersWerkDTO vrijwilligersWerk = new VrijwilligersWerkDTO(id, titel, beschrijving, maxCapaciteit);
                                werkLijst.Add(vrijwilligersWerk);
                            }
                            reader.Close();
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"Query execution failed: {ex.Message}");
                    }
                    finally
                    {
                        if (connection != null)
                        {
                            connection.Close();
                            connection = null;

                        }
                    }
                }
            }
            return werkLijst;
        }



        public VrijwilligersWerkDTO GetWerkOnId(int id)
        {

            VrijwilligersWerkDTO vrijwilligersWerk = null;

            if (IsConnect())
            {
                string query = "SELECT * FROM volenteer_work WHERE id = @id";

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {

                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                string titel = reader.GetString("title");
                                string beschrijving = reader.GetString("description");
                                int maxCapaciteit = reader.GetInt32("max_volenteers");

                                vrijwilligersWerk = new VrijwilligersWerkDTO(id, titel, beschrijving, maxCapaciteit);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Query execution failed: {ex.Message}");
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                        connection = null;
                    }
                }
            }

            return vrijwilligersWerk;


        }




        // Toevoegen

        public void AddVrijwilligersWerk(VrijwilligersWerkDTO werkDTO)
        {

            VrijwilligersWerkDTO werk = null;

            if (IsConnect())
            {
                string query = @"INSERT INTO volenteer_work(id, title, description, max_volenteers)
                                VALUES (@id, @title, @description, @max_volenteers)";

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {

                        

                        cmd.Parameters.AddWithValue("@id", werkDTO.WerkId);
                        cmd.Parameters.AddWithValue("@title", werkDTO.Titel);
                        cmd.Parameters.AddWithValue("@description", werkDTO.Omschrijving);
                        cmd.Parameters.AddWithValue("@max_volenteers", werkDTO.MaxCapaciteit);


                        cmd.ExecuteNonQuery();

                    }


                }

                catch (MySqlException ex)
                {
                    Console.WriteLine($"Query execution failed: {ex.Message}");

                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                        connection = null;
                    }

                }

            }

        }




        //Bewerken
        public bool BewerkVrijwilligersWerk(VrijwilligersWerkDTO updatedWerk)
        {
            if (!IsConnect())
                return false;

            string query = @"UPDATE volenteer_work 
                            SET title = @title, description = @description, max_volenteers = @max_volenteers 
                            WHERE id = @id";


            try
            {
                using (var cmd = new MySqlCommand(query, connection))
                {
                    
                    cmd.Parameters.AddWithValue("@title", updatedWerk.Titel);
                    cmd.Parameters.AddWithValue("@description", updatedWerk.Omschrijving);
                    cmd.Parameters.AddWithValue("@max_volenteers", updatedWerk.MaxCapaciteit);

                   
                    int rowsAffected = cmd.ExecuteNonQuery();

                   
                    return rowsAffected > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Query execution failed: {ex.Message}");
                return false;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }

        // Verhoog/verlaag aantal registraties
        public bool BewerkAantalRegistraties (int werkId, int wijziging) 
        {
            if (!IsConnect())
                return false;

            string query = @"UPDATE volenteer_work 
                            SET reg_count = reg_count + @wijziging
                            WHERE id = @id";


            try
            {
                using (var cmd = new MySqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@id", werkId);
                    cmd.Parameters.AddWithValue("@wijziging", wijziging);



                    int rowsAffected = cmd.ExecuteNonQuery();


                    return rowsAffected > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Query execution failed: {ex.Message}");
                return false;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
            }

        }




        //Verwijderen

        public bool VerwijderVrijwilligersWerk(int werkId)
        {
            if (!IsConnect())
                return false;

            const string query = "DELETE FROM volenteer_work WHERE id = @id";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    
                    cmd.Parameters.AddWithValue("@id", werkId);

                    
                    int rowsAffected = cmd.ExecuteNonQuery();

                    
                    return rowsAffected > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Query execution failed: {ex.Message}");
                return false;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }








    }
}