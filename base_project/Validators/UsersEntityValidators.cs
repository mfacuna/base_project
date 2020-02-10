using base_project.Entities.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace base_project.Validators
{
	public class UsersEntityValidators : AbstractValidator<UsersEntity>
	{
		public UsersEntityValidators()
		{
			RuleFor(x => x.Mail).NotNull().WithMessage("El campo 'Mail' es requerido.")
												.NotEmpty().WithMessage("El campo 'Mail' no puede estar vacío.");
			RuleFor(x => x.Password).NotNull().WithMessage("El campo 'Password' es requerido.")
												.NotEmpty().WithMessage("El campo 'Password' no puede estar vacío.");

			//EJEMPLO!!!!
			//Validación en caso sea list.
			//RuleForEach(x => x.ListBillingReqEntity).SetValidator(new ListBillingReqEntityValidator());
		}

		//public class ListBillingReqEntityValidator : AbstractValidator<OperationBillingRequest>
		//{
		//	///<summary> 
		//	///  
		//	///</summary> 
		//	public ListBillingReqEntityValidator()
		//	{
		//		RuleFor(x => x.ClientDealerId).NotNull().WithMessage("El campo 'Dealer' es requerido.")
		//									  .NotEmpty().WithMessage("El campo 'Dealer' no puede estar vacío.");

		//		RuleFor(x => x.ListOperations).NotNull().WithMessage("El campo 'Lista de Operaciones' es requerida.");

		//		RuleFor(x => x.ListOperations.Count).NotEqual(0).WithMessage("El campo 'Lista de Operaciones' no puede estar vacía.");
		//	}
		//}
	}
}
