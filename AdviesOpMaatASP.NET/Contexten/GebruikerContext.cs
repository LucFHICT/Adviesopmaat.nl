using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Contexten;
using AdviesOpMaatASP.NET.Interfaces;
using System.Data.SqlClient;
using AdviesOpMaatASP.NET.Readers;

namespace AdviesOpMaatASP.NET.Contexten
{
    public class GebruikerContext : DBContext, IGebruiker
    {
        GebruikerReader gebruikerReader = new GebruikerReader();

        public Gebruiker CreateGebruiker(string gebruikersnaam, string wachtwoord)
        {
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec CreateGebruiker @Gebruikersnaam, @Wachtwoord, @RolInt", Connection);

                    cmd.Parameters.AddWithValue("@Gebruikersnaam", gebruikersnaam);
                    cmd.Parameters.AddWithValue("@Wachtwoord", wachtwoord);
                    cmd.Parameters.AddWithValue("@RolId", 2);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }
            finally
            {
                CloseConnection();
                
            }

            return Login(gebruikersnaam , wachtwoord);
        }

        public Gebruiker Login(string gebruikersnaam, string wachtwoord)
        {
            Gebruiker gebruiker = new Gebruiker();
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM GetGebruiker(@Gebruikersnaam, @Wachtwoord)", Connection);

                    cmd.Parameters.AddWithValue("@Gebruikersnaam", gebruikersnaam);
                    cmd.Parameters.AddWithValue("@Wachtwoord", wachtwoord);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        gebruiker = gebruikerReader.createGebruikerFromReader(reader);
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return gebruiker;
        }
    }
}
