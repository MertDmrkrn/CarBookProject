﻿using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ServiceCommand;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandler
{
	public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
	{
		private readonly IRepository<Service> _repository;

		public RemoveServiceCommandHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(values);
		}
	}
}
