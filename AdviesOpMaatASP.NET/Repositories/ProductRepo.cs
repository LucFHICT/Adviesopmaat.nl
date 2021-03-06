﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Interfaces;

namespace AdviesOpMaatASP.NET.Repositories
{
    public class ProductRepo
    {
        readonly IProduct _context;
        public ProductRepo(IProduct context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.AddProduct(product);
        }
        public void DeleteProduct(Product product)
        {
            _context.DeleteProduct(product);
        }
        public void UpdateProduct(Product product)
        {
            _context.UpdateProduct(product);
        }

        public List<Product> AlleProducten()
        {
            return _context.AlleProducten();
        }
    }
}
