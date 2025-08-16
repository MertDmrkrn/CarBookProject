using CarBook.Domain.Entities;
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
	public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
	{
		private readonly IRepository<Feature> _repository;

		public CreateFeatureCommandHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Feature
			{
				FeatureName = request.FeatureName
			});
		}
	}
}
