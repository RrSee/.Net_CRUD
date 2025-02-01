﻿using System.Collections.Generic;
using System.Linq;
using WebApplication1.Context;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly StoreDbContext _context;

		public ProductRepository(StoreDbContext context)
		{
			_context = context;
		}

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
			_context.SaveChanges();
		}
	}
}
