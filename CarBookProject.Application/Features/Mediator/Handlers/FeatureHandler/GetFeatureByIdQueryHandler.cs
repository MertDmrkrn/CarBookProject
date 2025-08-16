using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.FeatureQuery;
using CarBookProject.Application.Features.Mediator.Results.FeatureResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.FeatureHandler
{
	public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
	{
		private readonly IRepository<Feature> _repository;

		public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}

		public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetFeatureByIdQueryResult
			{
				FeatureID = values.FeatureID,
				FeatureName = values.FeatureName
			};
		}
	}
}
