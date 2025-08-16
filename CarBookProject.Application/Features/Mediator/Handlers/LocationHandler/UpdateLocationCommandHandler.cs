﻿using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.LocationCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.LocationHandler
{
	public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
	{
		private readonly IRepository<Location> _repository;

		public UpdateLocationCommandHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.LocationID);
			values.LocationName = request.LocationName;
			await _repository.UpdateAsync(values);
		}
	}
}
