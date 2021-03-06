﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using base_project.Validators;
using FluentValidation.Results;

namespace base_project.Entities.Request
{
	public class UsersEntity
	{
        public string Mail { get; set; }
        public string Password { get; set; }

        //Crear validaciones vía FluentValidation 

        public ValidationResult Validate()
        {
            return ((new UsersEntityValidators()).Validate(this));
        }

        //public ValidationResult Validate()
        //    {
        //        return ((new LoginReqValidators()).Validate(this));
        //    }
    }
}
