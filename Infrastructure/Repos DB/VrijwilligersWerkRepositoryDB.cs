using System;
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
        

        string constring = "server=localhost;user=root;database=seniorconnect;port=3306;password=Devesh97!";
        

        public List<VrijwilligersWerkDTO> GetVrijwilligersWerk()
        {
            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();
            int i = 1;
            List<VrijwilligersWerkDTO> werkLijst = new List<VrijwilligersWerkDTO>();
            if (i == 1)
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
                        }
                    }
                    catch (Exception ex)
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


        public void SetVrijwilligerswerk(int id, string titel )
        {
            MySqlConnection connection = new MySqlConnection(constring);
            
            try
            {
                connection.Open();
                Console.Write("connecting");
                string query = "INSERT INTO volenteer_work (id, titel, omschrijving, max_volenteers) VALUES (@id, @titel, @omschrijving, @max_volenteers ) ";



            }
         
           



        }


    }
}
