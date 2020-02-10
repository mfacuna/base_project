using base_project.Entities.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace base_project.Contracts
{
	public interface IUsersService
	{
		Task<bool> CreateUsers(UsersEntity loginRequest);
	}
}
