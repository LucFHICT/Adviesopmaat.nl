using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Contexten;
using AdviesOpMaatASP.NET.Contexten.Readers;

namespace AdviesOpMaatASP.NET.Readers
{
    public class ProductReader
    {
        public Product createProductFromReader(IDataReader reader)
        {
            Product product = new Product((int)(reader["ProductId"]), reader["Naam"].ToString(), Convert.ToDouble((reader["Prijs"])));
            return product;
        }
    }
}
