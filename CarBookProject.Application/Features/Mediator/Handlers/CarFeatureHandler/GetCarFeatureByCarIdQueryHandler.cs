using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.CarFeatureQuery;
using CarBookProject.Application.Features.Mediator.Results.CarFeatureResult;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarFeatureHandler
{
	public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
	{
		private readonly ICarFeatureRepository _repository;

		public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarFeaturesByCarID(request.Id);
			return values.Select(x => new GetCarFeatureByCarIdQueryResult
			{
				Available = x.Available,
				CarFeatureID = x.CarFeatureID,
				FeatureID = x.FeatureID,
				FeatureName = x.Feature.FeatureName
			}).ToList();
		}
	}
}
