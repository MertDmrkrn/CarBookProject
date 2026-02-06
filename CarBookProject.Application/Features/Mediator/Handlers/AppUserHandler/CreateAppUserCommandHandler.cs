using CarBook.Domain.Entities;
using CarBookProject.Application.Enums;
using CarBookProject.Application.Features.Mediator.Commands.RegisterCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.AppUserInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.AppUserHandler
{
	public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
	{
		private readonly IRepository<AppUser> _repository;

		public CreateAppUserCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new AppUser
			{
				Password = request.Password,
				UserName = request.Username,
				AppRoleId = (int)RolesType.Member,
				Email = request.Email,
				Name = request.Name,
				Surname = request.Surname
			});
		}
	}
}
