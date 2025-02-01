using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly StoreDbContext _dbContext;

		public UserRepository(StoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Add(User user)
		{
			_dbContext.Users.Add(user);
			_dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var user = _dbContext.Users.Find(id);
			if(user != null)
			{
				_dbContext.Users.Remove(user);
				_dbContext.SaveChanges();
			}
		}

		public List<User> GetAll()
		{
			return _dbContext.Users.ToList();
		}

		public User GetById(int id)
		{
			return _dbContext.Users.Find(id);
		}

		public void Update(User user)
		{
			_dbContext.Users.Update(user);
			_dbContext.SaveChanges();
		}
	}
}
