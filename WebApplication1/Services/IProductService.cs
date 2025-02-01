using System.Collections.Generic;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
	public interface IProductService
	{
		void Add(Product product);
		void Delete(int id);
		void Update(Product product);
		Product GetById(int id);
		List<Product> GetAll();
	}
}
