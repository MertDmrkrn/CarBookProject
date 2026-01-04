using CarBookProject.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBookProject.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarFeatureHandler
{
	public class UpdateCarFeatureAvailableChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChangeToTrueCommand>
	{
		private readonly ICarFeatureRepository _repository;

		public UpdateCarFeatureAvailableChangeToTrueCommandHandler(ICarFeatureRepository repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCarFeatureAvailableChangeToTrueCommand request, CancellationToken cancellationToken)
		{
			_repository.ChangCarFeatureAvailableToTrue(request.Id);
		}
	}
}
