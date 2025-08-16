﻿using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.FeatureCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.FeatureHandler
{
	public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
	{
		private readonly IRepository<Feature> _repository;

		public RemoveFeatureCommandHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(values);
		}
	}
}
