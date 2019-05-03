using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Interfaces;
using AdviesOpMaatASP.NET.Classes;
using System.Data.SqlClient;
using AdviesOpMaatASP.NET.Contexten.Readers;

namespace AdviesOpMaatASP.NET.Contexten
{
    public class IntakeContext: DBContext, IIntake
    {
        readonly IntakeReader intakeReader = new IntakeReader();

        public List<Vraag> AlleVragen()
        {
            List<Vraag> vragen = new List<Vraag>();
            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM vw_alleVragen", Connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {        
                                vragen.Add(intakeReader.createVraagFromReader(reader));
                            }
                        }
                    }

                    foreach (Vraag vraag in vragen)
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM GetAntwoordopties (@VraagId)", Connection))
                        {
                            cmd.Parameters.AddWithValue("@VraagId", vraag.VraagId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    vraag.Antwoordopties.Add(intakeReader.createAntwoordoptieFromReader(reader));
                                }
                            }
                        }
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

            return vragen;
        }
    }
}
