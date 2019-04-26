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
    public class CategorieContext : DBContext, ICategorie
    {
        CategorieReader categorieReader = new CategorieReader();

        public void AddCategorie(Categorie categorie)
        {
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec AddCategorie @Naam, @Soort", Connection);

                    cmd.Parameters.AddWithValue("@Naam", categorie.Naam);
                    cmd.Parameters.AddWithValue("@Soort", categorie.Soort);

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
        }
        public void DeleteCategorie(Categorie categorie)
        {
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec DeleteCategorie @CategorieId", Connection);

                    cmd.Parameters.AddWithValue("@CategorieId", categorie.categorieId);

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
        }
        public void UpdateCategorie(Categorie categorie)
        {
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec UpdateCategorie @CategorieId, @Naam, @Soort", Connection);

                    cmd.Parameters.AddWithValue("@CategorieId", categorie.categorieId);
                    cmd.Parameters.AddWithValue("@Naam", categorie.Naam);
                    cmd.Parameters.AddWithValue("@Soort", categorie.Soort);

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
        }

        public List<Categorie> CategorieenBijProduct(int productId)
        {
            List<Categorie> categorieen = new List<Categorie>();
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM GetCategorieenByProductId(@ProductId)", Connection);

                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categorieen.Add(categorieReader.createCategorieFromReader(reader));
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

            return categorieen;
        }
        public List<Categorie> AlleCategorieen()
        {
            List<Categorie> categorieen = new List<Categorie>();
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM vw_alleCategorieen", Connection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categorieen.Add(categorieReader.createCategorieFromReader(reader));
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

            return categorieen;
        }
    }
}
