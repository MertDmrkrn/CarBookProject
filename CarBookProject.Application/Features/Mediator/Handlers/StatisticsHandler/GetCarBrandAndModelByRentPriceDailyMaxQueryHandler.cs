using CarBookProject.Application.Features.Mediator.Queries.StatisticsQuery;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResult;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.StatisticsHandler
{
	public class GetCarBrandAndModelByRentPriceDailyMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMaxQuery, GetCarBrandAndModelByRentPriceDailyMaxQueryResult>
	{
		private readonly IStatisticsRepository _statisticsRepository;

		public GetCarBrandAndModelByRentPriceDailyMaxQueryHandler(IStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}

		public async Task<GetCarBrandAndModelByRentPriceDailyMaxQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMaxQuery request, CancellationToken cancellationToken)
		{
			var value = _statisticsRepository.GetCarBrandAndModelByRentPriceDailyMax();
			return new GetCarBrandAndModelByRentPriceDailyMaxQueryResult
			{
				CarBrandAndModelByRentPriceDailyMax = value,
			};
		}
	}
}
