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
	public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
	{
		private readonly IRepository<Feature> _repository;

		public GetFeatureQueryHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetFeatureQueryResult
			{
				FeatureID = x.FeatureID,
				FeatureName = x.FeatureName
			}).ToList();
		}
	}
}
