﻿using System.Collections.Generic;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
	public interface IUserRepository
	{
		void Add(User user);
		void Delete(int id);
		void Update(User user);
		User GetById(int id);
		List<User> GetAll();
	}
}
