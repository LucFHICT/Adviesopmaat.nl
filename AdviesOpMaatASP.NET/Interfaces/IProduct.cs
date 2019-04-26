using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Interfaces;

namespace AdviesOpMaatASP.NET.Interfaces
{
    public interface IProduct
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        List<Product> AlleProducten();
    }
}
