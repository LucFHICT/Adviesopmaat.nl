using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Interfaces;
using AdviesOpMaatASP.NET.Classes;
using System.Data.SqlClient;
using AdviesOpMaatASP.NET.Readers;
using AdviesOpMaatASP.NET.Contexten.Readers;

namespace AdviesOpMaatASP.NET.Contexten
{
    public class ProductContext : DBContext, IProduct
    {
        readonly ProductReader productReader = new ProductReader();
        readonly CategorieReader categorieReader = new CategorieReader();

        public void AddProduct(Product product)
        {
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec AddProduct @Naam, @Prijs", Connection);

                    cmd.Parameters.AddWithValue("@Naam", product.Naam);
                    cmd.Parameters.AddWithValue("@Prijs", product.Prijs);

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
        public void DeleteProduct(Product product)
        {
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec DeleteProduct @ProductId", Connection);

                    cmd.Parameters.AddWithValue("@ProductId", product.id);

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
        public void UpdateProduct(Product product)
        {
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "exec UpdateProduct @ProductId, @Naam, @Prijs", Connection);

                    cmd.Parameters.AddWithValue("@ProductId", product.id);
                    cmd.Parameters.AddWithValue("@Naam", product.Naam);
                    cmd.Parameters.AddWithValue("@Prijs", product.Prijs);

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
        public List<Product> AlleProducten()
        {
            List<Product> producten = new List<Product>();
            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM vw_alleProducten", Connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                producten.Add(productReader.createProductFromReader(reader));
                            }
                        }
                    }

                    foreach (Product p in producten)
                    {
                        p.Categorieen = new List<Categorie>();
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM GetCategorieenByProductId (@ProductId)", Connection))
                        {
                            cmd.Parameters.AddWithValue("@ProductId", p.id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    p.Categorieen.Add(categorieReader.createCategorieFromReader(reader));
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
            return producten;
        }
    }
    
}
