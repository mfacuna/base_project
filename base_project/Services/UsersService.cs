using base_project.Contracts;
using base_project.Entities.Request;
using base_project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace base_project.Services
{
	public class UsersService : IUsersService
	{
		public async Task<bool> CreateUsers(UsersEntity loginRequest)
		{
			bool successfullSave = false;

			

			using (var contextDB = new db_base_projectContext())
			{
				using (var transaction = contextDB.Database.BeginTransaction())
				{
					try
					{
						User newUser = new User
						{
							Mail = loginRequest.Mail,
							Password = loginRequest.Password
						};

						contextDB.User.Add(newUser);
						contextDB.SaveChanges();
						transaction.Commit();
						successfullSave = true;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						successfullSave = false;
						throw ex;
					}
				}
			}

			return successfullSave;

		}
	}
}
