using CarBook.Domain.Entities;
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
	public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
	{
		private readonly ICarFeatureRepository _carFeatureRepository;

		public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository carFeatureRepository)
		{
			_carFeatureRepository = carFeatureRepository;
		}

		public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
		{
			_carFeatureRepository.CreateCarFeatureByCar(new CarFeature
			{
				FeatureID = request.FeatureID,
				Available = false,
				CarID = request.CarID
			});
		}
	}
}
